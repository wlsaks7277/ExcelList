using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LineList
{

    public partial class Show_two_sets : Form
    {
        DataSet ds = new DataSet();

        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();

        public Show_two_sets()
        {
            InitializeComponent();


            comp_data1_combobox.Sorted = false;
            comp_data2_combobox.Sorted = false;

            dataGridView1.RowHeadersVisible = false;
            dataGridView2.RowHeadersVisible = false;


            comp_data1_combobox.DropDownStyle = ComboBoxStyle.DropDownList;
            comp_data2_combobox.DropDownStyle = ComboBoxStyle.DropDownList;

            //setNumber 가져오기
            setNumber();

            colName(dt1, dataGridView1);
            colName(dt2, dataGridView2);


        }

        private void setNumber()
        {
            Linelist_WCF.Service1Client client = new Linelist_WCF.Service1Client();
            int setNumCounts = client.Load_setNumbers().Length;
            string[] setNumbers = new string[setNumCounts];
            setNumbers = client.Load_setNumbers();

            comp_data1_combobox.Items.AddRange(setNumbers);
            comp_data2_combobox.Items.AddRange(setNumbers);

            client.Close();
        }

        private void colName(DataTable dt, DataGridView dgv)
        {
            Linelist_WCF.Service1Client client = new Linelist_WCF.Service1Client();
            int columnCounts = client.Load_column_name().Length; //컬럼 개수
            string[] columnName = new string[columnCounts];//컬럼명 들어있는 string[]
            columnName = client.Load_column_name();//컬럼이름 넣기

            for (int i = 0; i < columnName.Length; i++)
            {
                dt.Columns.Add(columnName[i]);
            }

            dgv.DataSource = dt;
            client.Close();
        }

        private void db_com_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        //데이터 넣기
        private void store(string item = "", DataTable dt = null, DataGridView dgv = null)
        {

            dt.Clear();
            Linelist_WCF.Service1Client client = new Linelist_WCF.Service1Client();
            int columnCounts = client.Load_data_from_DB(item).Length;

            string[] dataArr = new string[columnCounts];
            dataArr = client.Load_data_from_DB(item);

            int col = client.Load_column_name().Length - 1;
            int row = columnCounts / col;

            string[,] data = new string[row, col];
            for (int r = 0, index = 0; r < row; r++)
            {
                for (int c = 0; c < col; c++)
                {
                    data[r, c] = dataArr[index];
                    index++;
                }
            }

            DataRow dr = null;

            for (int r = 0; r < row; r++)
            {
                dr = dt.Rows.Add();

                for (int c = 0; c < col; c++)
                {
                    dr[c + 1] = data[r, c];

                }
            }



            client.Close();
        }

        private void comp_data1_combobox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Linelist_WCF.Service1Client client = new Linelist_WCF.Service1Client();

            string setNumber = comp_data1_combobox.SelectedItem as string;

            
            dataGridView1.NewRowNeeded +=
                new DataGridViewRowEventHandler(dataGridView1_NewRowNeeded);
            dataGridView1.RowsAdded +=
                new DataGridViewRowsAddedEventHandler(dataGridView1_RowsAdded);
            dataGridView1.CellValueNeeded +=
                new DataGridViewCellValueEventHandler(dataGridView1_CellValueNeeded);


            
            //Controls.Add(dataGridView1);
            dataGridView1.VirtualMode = true;
            dataGridView1.AllowUserToDeleteRows = false;
            dt1.Rows.Add();

            DataRow workRow = dt1.NewRow();

            var dt = dataGridView1.DataSource;

            int i = dataGridView1.Rows.Add();
            //dataGridView1.Rows.AddCopies(0,numberOfRows);
            //BindingSource bindingSource = new BindingSource();

            //bindingSource.Add(new VirtualData(setNumber));

//            dataGridView1.DataSource = bindingSource;


        }


        private void comp_data2_combobox_SelectionChangeCommitted(object sender, EventArgs e)
        {


        }


        private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            dataGridView1.Rows[0].Cells[0].Style.BackColor = System.Drawing.Color.Yellow;
        }

        bool newRowNeeded;
        private void dataGridView1_NewRowNeeded(object sender,
            DataGridViewRowEventArgs e)
        {
            newRowNeeded = true;
        }

        const int initialSize = 10;
        int numberOfRows = initialSize;

        private void dataGridView1_RowsAdded(object sender,
             DataGridViewRowsAddedEventArgs e)
        {
            if (newRowNeeded)
            {
                newRowNeeded = false;
                numberOfRows = numberOfRows + 1;

            }
        }
        private void dataGridView1_CellValueNeeded(object sender,
        DataGridViewCellValueEventArgs e)
        {
            Linelist_WCF.Service1Client client = new Linelist_WCF.Service1Client();

            string setNumber = comp_data1_combobox.SelectedItem as string;
   
            if (newRowNeeded && e.RowIndex == numberOfRows)
            {
                e.Value = setNumber;
            }
        }
        
    }

}