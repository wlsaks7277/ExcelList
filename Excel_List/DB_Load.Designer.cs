namespace LineList
{
    partial class DB_Load
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Load_Selected_Data_Button = new System.Windows.Forms.Button();
            this.load_data_select_combobox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(103, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Data";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(72, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(454, 50);
            this.label2.TabIndex = 2;
            this.label2.Text = "불러오기 할 data 선택";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Load_Selected_Data_Button
            // 
            this.Load_Selected_Data_Button.Location = new System.Drawing.Point(224, 353);
            this.Load_Selected_Data_Button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Load_Selected_Data_Button.Name = "Load_Selected_Data_Button";
            this.Load_Selected_Data_Button.Size = new System.Drawing.Size(132, 35);
            this.Load_Selected_Data_Button.TabIndex = 3;
            this.Load_Selected_Data_Button.Text = "불러오기";
            this.Load_Selected_Data_Button.UseVisualStyleBackColor = true;
            this.Load_Selected_Data_Button.Click += new System.EventHandler(this.Load_Data_Button_Click);
            // 
            // load_data_select_combobox
            // 
            this.load_data_select_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.load_data_select_combobox.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.load_data_select_combobox.FormattingEnabled = true;
            this.load_data_select_combobox.Location = new System.Drawing.Point(186, 103);
            this.load_data_select_combobox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.load_data_select_combobox.Name = "load_data_select_combobox";
            this.load_data_select_combobox.Size = new System.Drawing.Size(282, 28);
            this.load_data_select_combobox.TabIndex = 4;
            this.load_data_select_combobox.SelectedIndexChanged += new System.EventHandler(this.load_set_SelectedIndexChanged);
            // 
            // DB_Load
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 401);
            this.Controls.Add(this.load_data_select_combobox);
            this.Controls.Add(this.Load_Selected_Data_Button);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DB_Load";
            this.Text = "DB 불러오기";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Load_Selected_Data_Button;
        private System.Windows.Forms.ComboBox load_data_select_combobox;
    }
}