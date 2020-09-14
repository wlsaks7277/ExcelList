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


    public partial class Show_two_setsTest : Form
    {

        string[][] strarr1 = null;
        string[][] strarr2 = null;

        bool click1 = false;
        bool click2 = false;

        public Show_two_setsTest()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form1_Load);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comp_data1_combobox.Sorted = false;
            comp_data2_combobox.Sorted = false;

            dataGridView1.RowHeadersVisible = false;
            dataGridView2.RowHeadersVisible = false;

            this.dataGridView1.VirtualMode = true;

            comp_data1_combobox.DropDownStyle = ComboBoxStyle.DropDownList;
            comp_data2_combobox.DropDownStyle = ComboBoxStyle.DropDownList;

            //setNumber 가져오기 ---------------------
            setNumber();

            addColum(dataGridView1);
            addColum(dataGridView2);
            
            // Set the row count, including the row for new records.
            this.dataGridView1.RowCount = 1;
            this.dataGridView2.RowCount = 1;
            this.dataGridView1.CellValueNeeded += new DataGridViewCellValueEventHandler(dataGridView1_CellValueNeeded);
            this.dataGridView2.CellValueNeeded += new DataGridViewCellValueEventHandler(dataGridView2_CellValueNeeded);
        }

       

        private void addColum(DataGridView dgv)
        {

            Linelist_WCF.Service1Client client = new Linelist_WCF.Service1Client();
            int columnCounts = client.Load_column_name().Length; //컬럼 개수
            string[] columnName = new string[columnCounts];//컬럼명 들어있는 string[]
            columnName = client.Load_column_name();//컬럼이름 넣기

            for (int i = 0; i < columnName.Length; i++)
            {
                DataGridViewTextBoxColumn Column = new DataGridViewTextBoxColumn();
                Column.HeaderText = columnName[i].ToString();
                Column.Name = columnName[i].ToString();

                dgv.Columns.Add(Column);
            }

            client.Close();
        }

        private void setNumber()
        {
            Linelist_WCF.Service1Client client = new Linelist_WCF.Service1Client();

            int setNumCounts = client.Record().Length;
            string[] setNumbers = new string[setNumCounts];
            setNumbers = client.Record();

            comp_data1_combobox.Items.AddRange(setNumbers);
            comp_data2_combobox.Items.AddRange(setNumbers);

            client.Close();
        }

        private void db_com_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comp_data1_combobox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            Linelist_WCF.Service1Client client = new Linelist_WCF.Service1Client();
            this.dataGridView1.VirtualMode = true;
            click1 = true;

            string setNumber1 = comp_data1_combobox.SelectedItem as string;
            int count1 = comp_data1_combobox.Items.Count;
            string[] set1 = new string[count1];
            set1=setNumber1.Split('/');
            strarr1 = client.Load_data_from_DB(set1[0]);
            this.dataGridView1.RowCount = strarr1.GetLength(0) + 1;

            if (click2 == true && click1 == true)
            {
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    foreach (DataGridViewColumn col in dataGridView2.Columns)
                    {
                        dataGridView2.Rows[row.Index].Cells[col.Index].Style.BackColor = Color.White;
                    }
                }
                compare(strarr1, strarr2, 0, dataGridView1,dataGridView2);
                compare(strarr1, strarr2, 1, dataGridView2, dataGridView1);
                //dataGridView2.Refresh();
            }
            
            client.Close();

        }
        private void comp_data2_combobox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            Linelist_WCF.Service1Client client = new Linelist_WCF.Service1Client();
            this.dataGridView2.VirtualMode = true;
            click2 = true;

            string setNumber2 = comp_data2_combobox.SelectedItem as string;
            int count2 = comp_data2_combobox.Items.Count;
            string[] set2 = new string[count2];
            set2 = setNumber2.Split('/');
            strarr2 = client.Load_data_from_DB(set2[0]);
            this.dataGridView2.RowCount = strarr2.GetLength(0)+1;

            if (click1 == true && click2 == true)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    foreach (DataGridViewColumn col in dataGridView1.Columns)
                    {
                        dataGridView1.Rows[row.Index].Cells[col.Index].Style.BackColor = Color.White;
                    }
                }
                compare(strarr1, strarr2, 1, dataGridView2, dataGridView1);
                compare(strarr1, strarr2, 0, dataGridView1, dataGridView2);
                dataGridView1.Refresh();
            }

            client.Close();
        }

        private void dataGridView1_CellValueNeeded(object sender,
    System.Windows.Forms.DataGridViewCellValueEventArgs e)
        {
            // If this is the row for new records, no values are needed.
            if (e.RowIndex == this.dataGridView1.RowCount-1) return;

            // Set the cell value to paint using the Customer object retrieved.
            if (strarr1[e.RowIndex] != null)
            {
                e.Value = strarr1[e.RowIndex][e.ColumnIndex];
            }
        }
        private void dataGridView2_CellValueNeeded(object sender,
    System.Windows.Forms.DataGridViewCellValueEventArgs e)
        {
            // If this is the row for new records, no values are needed.
            if (e.RowIndex == this.dataGridView2.RowCount - 1) return;

            // Set the cell value to paint using the Customer object retrieved.
            if (strarr2[e.RowIndex] != null)
            {
                e.Value = strarr2[e.RowIndex][e.ColumnIndex];
                
            }
        }

        private void compare(string[][] str0, string[][] str1, int a,DataGridView dgv1,DataGridView dgv2)
        {
            List<string[]> except = new List<string[]>();
            List<string> pk0 = new List<string>();//a
            List<string> pk1 = new List<string>();//b
            List<string> pkExcept = new List<string>();

            int count0=0, count1 = 0;

            if (a == 0)
            {
                except = str0.Except(str1).ToList();//a=0 a-b
                count0 = str0.Count();
                count1 = str1.Count();
                for (int i = 0; i < count0; i++)//a, b
                {
                    string temp = "";

                    temp = str0[i][2].ToString() + str0[i][3].ToString() + str0[i][4].ToString() + str0[i][5].ToString();
                    pk0.Add(temp);
                }

                for (int i = 0; i < count1; i++)//b, a
                {
                    string temp = "";
                    temp = str1[i][2].ToString() + str1[i][3].ToString() + str1[i][4].ToString() + str1[i][5].ToString();
                    pk1.Add(temp);
                }


            }
            else
            {
                except = str1.Except(str0).ToList();//a=1 b-a
                count0 = str0.Count();
                count1 = str1.Count();

                for (int i = 0; i < count0; i++)//a, b
                {
                    string temp = "";

                    temp = str0[i][2].ToString() + str0[i][3].ToString() + str0[i][4].ToString() + str0[i][5].ToString();
                    pk1.Add(temp);
                }

                for (int i = 0; i < count1; i++)//b, a
                {
                    string temp = "";
                    temp = str1[i][2].ToString() + str1[i][3].ToString() + str1[i][4].ToString() + str1[i][5].ToString();
                    pk0.Add(temp);
                }
                string[][] strTemp = str0;
                str0 = str1;
                str1 = strTemp;
            }
            

            for (int i = 0; i < except.Count(); i++)//a-b, b-a
            {
                string temp = "";
                temp = except[i][2].ToString() + except[i][3].ToString() + except[i][4].ToString() + except[i][5].ToString();
                pkExcept.Add(temp);
            }


            
            for (int i = 0; i < except.Count(); i++)
            {
                bool c = false;
                c = pk1.Exists(element => element.Equals(pkExcept[i]));// b , a
                if(c)// same pk
                {
                    int x = -1;
                    x = pk0.FindIndex(element => element.Equals(pkExcept[i]));// a , b
                    int y = -1;
                    y = pk1.FindIndex(element => element.Equals(pkExcept[i]));// b , a

                    if (x > -1 && y > -1)
                    {
                        for (int j = 1; j < dgv1.ColumnCount; j++)//gird1 , grid2
                        {
                            if (str0[x][j] != str1[y][j])//a!=b, b!=a
                            {
                                dgv1.Rows[x].Cells[j].Style.BackColor = Color.Yellow;// grid1 ,grid2
                                dgv1.Rows[x].Cells[0].Style.BackColor = Color.YellowGreen;

                                dgv2.Rows[y].Cells[j].Style.BackColor = Color.Yellow;//grdi2, grid1
                                dgv2.Rows[y].Cells[0].Style.BackColor = Color.YellowGreen;
                            }
                        }
                        
                    }
                }

                else // differ pk
                {
                    int x = -1;
                    x = pk0.FindIndex(element => element.Equals(pkExcept[i]));// a ,b

                    if (x > -1)
                    {
                        for (int j = 0; j < dgv1.ColumnCount; j++)
                        {
                            dgv1.Rows[x].Cells[j].Style.BackColor = Color.LightBlue;
                        }
                    }
                }
            }
        }
    }
}