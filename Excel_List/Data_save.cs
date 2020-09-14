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
    public partial class Data_save : Form
    {
        public static string user_name_input;
        public static string date_input;
        public static string comment_input;
        public static bool save_btn_clicked = false;

        public Data_save()
        {
            save_btn_clicked = false;
            InitializeComponent();
            date_label.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            save_btn_clicked = true;
            user_name_input = user_name_textbox.Text;
            date_input = date_label.Text;
            comment_input = comment_textbox.Text;

            Close();
        }
    }

}
