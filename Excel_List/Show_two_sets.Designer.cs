namespace LineList
{
    partial class Show_two_sets
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.set2_label = new System.Windows.Forms.Label();
            this.set1_label = new System.Windows.Forms.Label();
            this.comp_data1_combobox = new System.Windows.Forms.ComboBox();
            this.comp_data2_combobox = new System.Windows.Forms.ComboBox();
            this.com_data_close = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(26, 87);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(583, 610);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dataGridView1_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(514, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 22);
            this.label1.TabIndex = 4;
            this.label1.Text = "비교 할 data 선택";
            // 
            // set2_label
            // 
            this.set2_label.AutoSize = true;
            this.set2_label.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.set2_label.Location = new System.Drawing.Point(796, 54);
            this.set2_label.Name = "set2_label";
            this.set2_label.Size = new System.Drawing.Size(113, 19);
            this.set2_label.TabIndex = 1;
            this.set2_label.Text = "두 번째 data";
            // 
            // set1_label
            // 
            this.set1_label.AutoSize = true;
            this.set1_label.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.set1_label.Location = new System.Drawing.Point(215, 54);
            this.set1_label.Name = "set1_label";
            this.set1_label.Size = new System.Drawing.Size(113, 19);
            this.set1_label.TabIndex = 0;
            this.set1_label.Text = "첫 번째 data";
            // 
            // comp_data1_combobox
            // 
            this.comp_data1_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comp_data1_combobox.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.comp_data1_combobox.FormattingEnabled = true;
            this.comp_data1_combobox.Location = new System.Drawing.Point(346, 50);
            this.comp_data1_combobox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comp_data1_combobox.Name = "comp_data1_combobox";
            this.comp_data1_combobox.Size = new System.Drawing.Size(106, 24);
            this.comp_data1_combobox.TabIndex = 5;
            this.comp_data1_combobox.SelectionChangeCommitted += new System.EventHandler(this.comp_data1_combobox_SelectionChangeCommitted);
            // 
            // comp_data2_combobox
            // 
            this.comp_data2_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comp_data2_combobox.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.comp_data2_combobox.FormattingEnabled = true;
            this.comp_data2_combobox.Location = new System.Drawing.Point(927, 50);
            this.comp_data2_combobox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comp_data2_combobox.Name = "comp_data2_combobox";
            this.comp_data2_combobox.Size = new System.Drawing.Size(106, 24);
            this.comp_data2_combobox.TabIndex = 6;
            this.comp_data2_combobox.SelectionChangeCommitted += new System.EventHandler(this.comp_data2_combobox_SelectionChangeCommitted);
            // 
            // com_data_close
            // 
            this.com_data_close.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.com_data_close.Location = new System.Drawing.Point(551, 709);
            this.com_data_close.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.com_data_close.Name = "com_data_close";
            this.com_data_close.Size = new System.Drawing.Size(137, 34);
            this.com_data_close.TabIndex = 7;
            this.com_data_close.Text = "확인";
            this.com_data_close.UseVisualStyleBackColor = true;
            this.com_data_close.Click += new System.EventHandler(this.db_com_close_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(625, 86);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(576, 610);
            this.dataGridView2.TabIndex = 3;
            this.dataGridView2.VirtualMode = true;
            // 
            // Show_two_sets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1221, 751);
            this.Controls.Add(this.com_data_close);
            this.Controls.Add(this.comp_data2_combobox);
            this.Controls.Add(this.comp_data1_combobox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.set2_label);
            this.Controls.Add(this.set1_label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Show_two_sets";
            this.Text = "DB 변경 내역";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label set2_label;
        private System.Windows.Forms.Label set1_label;
        private System.Windows.Forms.ComboBox comp_data1_combobox;
        private System.Windows.Forms.ComboBox comp_data2_combobox;
        private System.Windows.Forms.Button com_data_close;
        private System.Windows.Forms.DataGridView dataGridView2;
    }
}