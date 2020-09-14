using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Oracle.ManagedDataAccess.Client;
using System.Diagnostics;

namespace LineList
{
    public partial class LineListForm : Form
    {
        public static DataTable table = new DataTable();  //테이블 생성
        Excel.Range range;
        
        int rowCounts;
        int colCounts;

        int newRow;
        int newCol;
        object[] arr;

        public LineListForm()
        {
            InitializeComponent();
            show_loaded_data.RowHeadersVisible = false; // 첫번째 콜롬 안보이게
            show_loaded_data.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; //콜롬 이름 중앙 정렬
            show_loaded_data.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;    // 셀 값들 중앙 정렬

            //테이블 콜롬 추가
            table.Columns.Add(new DataColumn("LINESIZE", typeof(string)));
            table.Columns.Add(new DataColumn("UNIT", typeof(string)));
            table.Columns.Add(new DataColumn("FLUID", typeof(string)));
            table.Columns.Add(new DataColumn("SEQUENCE NUMBER", typeof(string)));
            table.Columns.Add(new DataColumn("PIPING SPEC.", typeof(string)));
            table.Columns.Add(new DataColumn("INSULATION", typeof(string)));
            table.Columns.Add(new DataColumn("INSULATION THK.", typeof(string)));
            table.Columns.Add(new DataColumn("HYDRO TEST MEDIUM", typeof(string)));
            table.Columns.Add(new DataColumn("HYDRO TEST PRESS.", typeof(string)));
            table.Columns.Add(new DataColumn("PAINT CODE", typeof(string)));
            table.Columns.Add(new DataColumn("DESIGN TEMP ºC", typeof(string)));
            table.Columns.Add(new DataColumn("DESIGN PRESS barg", typeof(string)));
            table.Columns.Add(new DataColumn("OPER TEMP ºC", typeof(string)));
            table.Columns.Add(new DataColumn("OPER PRESS barg", typeof(string)));
            table.Columns.Add(new DataColumn("RT FIELD", typeof(string)));
            table.Columns.Add(new DataColumn("RT SHOP", typeof(string)));
            table.Columns.Add(new DataColumn("PWHT", typeof(string)));
            table.Columns.Add(new DataColumn("GAD NO.", typeof(string)));
            table.Columns.Add(new DataColumn("P&ID NO.", typeof(string)));


            for (int i = 0; i < 20; i++) { table.Rows.Add(table.NewRow()); }    // 빈 row 생성
            show_loaded_data.DataSource = table;    // 테이블 불러옴 (Column 이름 보여주기)
        }

        #region 2020-04-07 jinman DB_Load Form 띄우기
        private void Load_DB_Click(object sender, EventArgs e)
        {
            DB_Load db_Load = new DB_Load();
            db_Load.ShowDialog();

            if (DB_Load.load_clicked)
            {
                data_set_label.Text = " Set " + DB_Load.selected_setNumber; // 선택 된 set
                show_loaded_data.DataSource = table;    // 테이블 불러옴
            }
            else { }
            
        }

        private void Save_Record_Button_Click(object sender, EventArgs e)
        {
            Save_Record save_Record = new Save_Record();
            save_Record.ShowDialog();
        }

        #endregion

        private void Compare_DB_Click(object sender, EventArgs e)
        {
            Show_two_setsTest show_Two_Sets = new Show_two_setsTest();
            show_Two_Sets.ShowDialog();
        }

        private void Store_DB_Click(object sender, EventArgs e)
        {
            newRow = show_loaded_data.RowCount - 1;
            newCol = show_loaded_data.ColumnCount;
            int dataCounts = newCol * newRow;
            object[] data = new object[dataCounts];

            Data_save.save_btn_clicked = false;
            bool PK_value_check = true;
            newRow = show_loaded_data.RowCount - 1;
            newCol = show_loaded_data.ColumnCount;
            int Counts = newCol * newRow;
            object[] inputs = new object[Counts];
            int index = 0;
            //PK 값들 다 채워져 있는지 체크
            for (int r = 0; r < newRow; r++)
            {
                for (int c = 0; c < newCol; c++)
                {
                    inputs[index] = show_loaded_data.Rows[r].Cells[c].Value;
                    if (c > 0 && c < 5) { if (inputs[index] == null || inputs[index].ToString() == "") { PK_value_check = false; } }
                    index++;
                }
            }
            if (PK_value_check == false) { MessageBox.Show($"UNIT, FLUID, SEQUENCE NUMBER, PIPING SPEC. 열을 채워야 합니다."); }
            else {
                
                object[,] data2 = new object[newRow, newCol];
                index = 0;
                for (int r = 0; r < newRow; r++)
                {
                    for (int c = 0; c < newCol; c++)
                    {
                        data[index] = show_loaded_data.Rows[r].Cells[c].Value;
                        data2[r, c] = show_loaded_data.Rows[r].Cells[c].Value;
                        //Debug.WriteLine("data[" + r + "," + c + "] = " + data2[r, c]);
                        index++;
                    }
                }
                List<int> pickedRows = dataCheck(data2, newRow);

                if (pickedRows.Count == 0)  // 겹치는 PK 값이 없다면
                {
                    Data_save save = new Data_save();
                    save.ShowDialog();
                }
                else {  // 겹치는 PK 값이 있다면
                    foreach (int r in pickedRows) {
                        for (int c = 1; c < 5; c++) {
                            show_loaded_data.Rows[r].Cells[c].Style.BackColor = System.Drawing.Color.Pink;
                        }
                    }
                    MessageBox.Show("값이 겹치는 행이 있습니다.");
                }
            }

            // PK값 체크를 통과하고 저장 버튼이 눌리면
            if (Data_save.save_btn_clicked)
            {
                bool success = false;
                Linelist_WCF.Service1Client client = new Linelist_WCF.Service1Client();
                success = client.Put_data_into_DB(data, newRow, newCol, Data_save.user_name_input, Data_save.date_input, Data_save.comment_input);
                if (success) { MessageBox.Show($"데이터를 성공적으로 저장했습니다."); }
                else { MessageBox.Show($"DB 연결 실패"); }
            }
            else { Debug.WriteLine("저장 안됌"); }

        }

        private List<int> dataCheck(object[,] data, int row)
        {
            // string 1,2,3,4열 합침
            string[] dataStrings = new string[row];
            for (int r = 0; r < row; r++)
            {
                for (int c = 1; c < 5; c++)
                {
                    if (data[r, c] == null) { data[r, c] = ""; }
                    dataStrings[r] += data[r, c].ToString();
                    //Debug.WriteLine("dataStrings: " + dataStrings[r]);
                }
            }

            List<int> list = new List<int>();   // 값이 겹치는 행
            // 값 비교
            bool flag = false;
            for (int pick = 0; pick < row; pick++)
            {
                flag = false;
                for (int anotherPick = pick + 1; anotherPick < row; anotherPick++)
                {
                    // 값이 같다면
                    if (dataStrings[pick].Equals(dataStrings[anotherPick]))
                    {
                        flag = true; //값이 동일하다
                        list.Add(anotherPick);
                    }
                }
                if (flag)
                {
                    list.Add(pick);
                }
            }
            list.Sort();

            return list;
        }


        private void Excel_Button_Click(object sender, EventArgs e)
        {
            //엑셀 변수 선언
            Excel.Application xlApp = null;
            Excel.Workbook xlWorkbook = null;
            Excel.Worksheet xlWorksheet = null;
            object[,] data;
            //파일 선택
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "엑셀 파일 (*.xlsx)|*.xlsx|엑셀 파일 (*.xls)|*.xls";

            //파일을 열수 있는지 확인
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    xlApp = new Excel.Application();
                    xlWorkbook = xlApp.Workbooks.Open(ofd.FileName);// 엑셀 파일 가져오기
                    xlWorksheet = (Excel.Worksheet)xlWorkbook.Worksheets.get_Item(1);

                    range = xlWorksheet.UsedRange;//엑셀 시트범위 설정

                    data = range.Value; // 지정된 시트 2차원 배열에 담기
                    rowCounts = range.Rows.Count; // 행 개수
                    colCounts = range.Columns.Count; //열 개수

                    //Debug.WriteLine("col counts: " + colCounts);

                    int dataStartRow = 1;
                    int dataStartCol = 1;
                    int dataEndRow = 0;
                    int dataEndCol = 0;

                    for (int r = 1; r < rowCounts; r ++) {
                        for (int c = 1; c < colCounts; c++) {
                            Debug.WriteLine("row, col: " + r + ", " + c);
                            if (data[r, c] != null) {
                                Debug.WriteLine("data[r, c]: " + data[r, c]);
                                if (data[r, c].ToString().Equals("P&ID NO."))
                                {
                                    dataEndRow = r;
                                    dataEndCol = c;
                                    break;
                                }
                                else if (data[r, c].ToString().Equals("LINE INFORMATION"))
                                {
                                    dataStartRow = r + 1;
                                    dataStartCol = c;
                                    break;
                                }
                            }
                        }
                        if (dataEndRow != 0) { break; }
                    }
                    Debug.WriteLine("data start row: " + dataStartRow);
                    Debug.WriteLine("data start col: " + dataStartCol);
                    Debug.WriteLine("data end row: " + dataEndRow);


                    if ((dataEndCol - dataStartCol + 1) != 19)
                    {    // 콜롬 개수가 지정된 19개가 아니라면 경고 창 띄움
                        MessageBox.Show("정의된 열 개수를 벗어났습니다.\n 데이터를 저장하지 않았습니다.");
                    }
                    else {
                        newRow = rowCounts - dataStartRow;
                        newCol = colCounts - dataStartCol;  //19
                        int newArrayCounts = newRow * newCol;
                        arr = new object[newArrayCounts];
                        int index = 0;

                        for (int r = dataStartRow + 1; r <= rowCounts; r++) {
                            if (index > newArrayCounts) break;
                            for (int c = dataStartCol; c < colCounts; c++) {
                                arr[index] = data[r, c];
                                index++;
                                //Debug.WriteLine("data[" + r + ", " + c + "] = " + data[r, c]);
                            }
                        }
                        bool success = false;
                        Linelist_WCF.Service1Client client = new Linelist_WCF.Service1Client();
                        success = client.Put_data_into_DB(arr, newRow, newCol, "", "", "");
                        if (success) { MessageBox.Show($"데이터를 성공적으로 저장했습니다."); }
                        else { MessageBox.Show($"DB 연결 실패"); }
                    }
                    xlWorkbook.Close(true);
                    xlApp.Quit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    ReleaseExcelObject(xlWorksheet);
                    ReleaseExcelObject(xlWorkbook);
                    ReleaseExcelObject(xlApp);
                }
            }
            else { MessageBox.Show($"저장 할 파일이 선택 되지 않았습니다."); }

        }

        private void ReleaseExcelObject(object obj)
        {
            try
            {
                if (obj != null)
                {
                    Marshal.ReleaseComObject(obj);
                    obj = null;
                }
            }
            catch (Exception ex)
            {
                obj = null;
                throw ex;
            }

            finally
            {
                GC.Collect();
            }
        }

        private string oldValue;
        private string newValue;
        private void Loaded_data_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            oldValue = show_loaded_data[e.ColumnIndex, e.RowIndex].Value.ToString();
            Debug.WriteLine("old value: " + oldValue);
        }

        private void Loaded_data_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            newValue = show_loaded_data[e.ColumnIndex, e.RowIndex].Value.ToString();
            Debug.WriteLine("new value: " + newValue);

            if (oldValue != newValue) { show_loaded_data.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = System.Drawing.Color.Yellow; }
        }
    }
}
