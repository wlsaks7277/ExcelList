using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace LineList
{
    public partial class DB_Load : Form
    {
        public static bool load_clicked = false;
        public static string selected_setNumber;
        public DB_Load()
        {
            InitializeComponent();
            load_clicked = false;

            // combo box에 띄울 set, 이름, comment 불러오기
            Linelist_WCF.Service1Client client = new Linelist_WCF.Service1Client();
            int recordsLength = client.Load_DB_Record().Length;
            string[] data = new string[recordsLength];
            data = client.Load_DB_Record();
            int col = 4;
            int row = recordsLength / 4;
            string[,] records = new string[row, col];
            int index = 0;
            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < col; c++)
                {
                    records[r, c] = data[index];
                    index++;
                }
            }
            index = 0;
            string[] str = new string[row];
            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < col; c++)
                {
                    if (c == 0 || c == 1) { str[index] += (records[r, c].Replace("\n", string.Empty) + " / "); }
                    else if (c == 3) { str[index] += records[r, c].Replace("\n", string.Empty); }
                }
                index++;
            }
            load_data_select_combobox.Items.AddRange(str);  // combo box에 값 추가
        }

        // 불러오기 버튼 - data 불러옴
        private void Load_Data_Button_Click(object sender, EventArgs e)
        {
            load_clicked = true;

            Linelist_WCF.Service1Client client = new Linelist_WCF.Service1Client();

            // combo box 값 선택 되었는지
            string selected_item = load_data_select_combobox.SelectedItem as String;
            if (selected_item != null)
            {
                string searchText = " ";
                selected_setNumber = selected_item.Substring(0, selected_item.IndexOf(searchText));
            }
            else { selected_setNumber = ""; }
            Debug.WriteLine("Selected Number: " + selected_setNumber);
            if (selected_setNumber == "" || selected_setNumber == null) { load_clicked = false; Close(); }  // combo box 값 선택되지 않음
            else {  // combo box 값 선택 되었다면
                int arrSize = client.Load_data_from_DB(selected_setNumber).Length;
                int col = 19;
                int row = arrSize / col;
                string[][] dataArr = new string[arrSize][];
                dataArr = client.Load_data_from_DB(selected_setNumber);

                string[,] data = new string[row, col];
                //int index = 0;
                for (int r = 0; r < row; r++)
                {
                    for (int c = 0; c < col; c++)
                    {
                        data[r, c] = dataArr[r][c];
                        //index++;
                    }
                }
                LineListForm.table.Clear();
                DataRow dataRow = null;

                for (int r = 0; r < row; r++)
                {
                    dataRow = LineListForm.table.Rows.Add();
                    for (int c = 0; c < col; c++)
                    {
                        dataRow[c] = data[r, c];
                    }
                }
            }
            
            Close();
        }

        private void load_set_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
