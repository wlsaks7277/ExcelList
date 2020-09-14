using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LineList
{
    public partial class Save_Record : Form
    {
        DataTable table = new DataTable();  //테이블 생성
        public Save_Record()
        {
            InitializeComponent();

            save_record_view.RowHeadersVisible = false; // 첫번째 콜롬 안보이게
            save_record_view.ReadOnly = true;   // 값들 편집 불가능하게
            save_record_view.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;   // 콜롬 이름 중앙 정렬
            save_record_view.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;    // 셀 값들 중앙 정렬

            // 열 생성
            table.Columns.Add(new DataColumn("Set", typeof(string)));
            table.Columns.Add(new DataColumn("Name", typeof(string)));
            table.Columns.Add(new DataColumn("Date", typeof(string)));
            table.Columns.Add(new DataColumn("Comment", typeof(string)));

            // 데이터 가져오기
            Linelist_WCF.Service1Client client = new Linelist_WCF.Service1Client();
            int redordsLength = client.Load_DB_Record().Length;
            string[] data = new string[redordsLength];
            data = client.Load_DB_Record();
            int col = 4;
            int row = redordsLength / 4;
            string[,] records = new string[row, col];
            int index = 0;
            for (int r = 0; r < row; r++) {
                for (int c = 0; c < col; c++) {
                    records[r, c] = data[index];
                    index++;
                }
            }

            // 데이터 테이블에 값 넣기
            DataRow dataRow = null;
            for (int r = 0; r < row; r++)
            {
                dataRow = table.Rows.Add();
                for (int c = 0; c < col; c++)
                {
                    dataRow[c] = records[r, c];
                }
            }

            save_record_view.DataSource = table;    // grid view 에 데이터 불러옴
            //save_record_view.CurrentCell = null; // 선택 해제
        }

        private void save_records_close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
