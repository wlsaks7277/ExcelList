namespace LineList
{
    partial class LineListForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.show_loaded_data = new System.Windows.Forms.DataGridView();
            this.Compare_DB_Button = new System.Windows.Forms.Button();
            this.Excel_Button = new System.Windows.Forms.Button();
            this.Load_DB_Button = new System.Windows.Forms.Button();
            this.Save_DB_Button = new System.Windows.Forms.Button();
            this.Save_Record_Button = new System.Windows.Forms.Button();
            this.data_set_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.show_loaded_data)).BeginInit();
            this.SuspendLayout();
            // 
            // show_loaded_data
            // 
            this.show_loaded_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.show_loaded_data.Location = new System.Drawing.Point(78, 69);
            this.show_loaded_data.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.show_loaded_data.Name = "show_loaded_data";
            this.show_loaded_data.Size = new System.Drawing.Size(1143, 625);
            this.show_loaded_data.TabIndex = 0;
            this.show_loaded_data.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.Loaded_data_CellBeginEdit);
            this.show_loaded_data.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.Loaded_data_CellEndEdit);
            // 
            // Compare_DB_Button
            // 
            this.Compare_DB_Button.Location = new System.Drawing.Point(1254, 628);
            this.Compare_DB_Button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Compare_DB_Button.Name = "Compare_DB_Button";
            this.Compare_DB_Button.Size = new System.Drawing.Size(200, 66);
            this.Compare_DB_Button.TabIndex = 1;
            this.Compare_DB_Button.Text = "DB 변경 내역";
            this.Compare_DB_Button.UseVisualStyleBackColor = true;
            this.Compare_DB_Button.Click += new System.EventHandler(this.Compare_DB_Click);
            // 
            // Excel_Button
            // 
            this.Excel_Button.Location = new System.Drawing.Point(1254, 69);
            this.Excel_Button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Excel_Button.Name = "Excel_Button";
            this.Excel_Button.Size = new System.Drawing.Size(200, 66);
            this.Excel_Button.TabIndex = 2;
            this.Excel_Button.Text = "Excel -> DB";
            this.Excel_Button.UseVisualStyleBackColor = true;
            this.Excel_Button.Click += new System.EventHandler(this.Excel_Button_Click);
            // 
            // Load_DB_Button
            // 
            this.Load_DB_Button.Location = new System.Drawing.Point(1254, 202);
            this.Load_DB_Button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Load_DB_Button.Name = "Load_DB_Button";
            this.Load_DB_Button.Size = new System.Drawing.Size(200, 66);
            this.Load_DB_Button.TabIndex = 3;
            this.Load_DB_Button.Text = "DB 불러오기";
            this.Load_DB_Button.UseVisualStyleBackColor = true;
            this.Load_DB_Button.Click += new System.EventHandler(this.Load_DB_Click);
            // 
            // Save_DB_Button
            // 
            this.Save_DB_Button.Location = new System.Drawing.Point(1254, 345);
            this.Save_DB_Button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Save_DB_Button.Name = "Save_DB_Button";
            this.Save_DB_Button.Size = new System.Drawing.Size(200, 66);
            this.Save_DB_Button.TabIndex = 4;
            this.Save_DB_Button.Text = "DB 저장하기";
            this.Save_DB_Button.UseVisualStyleBackColor = true;
            this.Save_DB_Button.Click += new System.EventHandler(this.Store_DB_Click);
            // 
            // Save_Record_Button
            // 
            this.Save_Record_Button.Location = new System.Drawing.Point(1254, 476);
            this.Save_Record_Button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Save_Record_Button.Name = "Save_Record_Button";
            this.Save_Record_Button.Size = new System.Drawing.Size(200, 66);
            this.Save_Record_Button.TabIndex = 5;
            this.Save_Record_Button.Text = "저장 이력";
            this.Save_Record_Button.UseVisualStyleBackColor = true;
            this.Save_Record_Button.Click += new System.EventHandler(this.Save_Record_Button_Click);
            // 
            // data_set_label
            // 
            this.data_set_label.AutoSize = true;
            this.data_set_label.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.data_set_label.Location = new System.Drawing.Point(73, 28);
            this.data_set_label.Name = "data_set_label";
            this.data_set_label.Size = new System.Drawing.Size(306, 24);
            this.data_set_label.TabIndex = 6;
            this.data_set_label.Text = "Database에서 가져온 data";
            // 
            // LineListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1528, 742);
            this.Controls.Add(this.data_set_label);
            this.Controls.Add(this.Save_Record_Button);
            this.Controls.Add(this.Save_DB_Button);
            this.Controls.Add(this.Load_DB_Button);
            this.Controls.Add(this.Excel_Button);
            this.Controls.Add(this.Compare_DB_Button);
            this.Controls.Add(this.show_loaded_data);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "LineListForm";
            this.Text = "LineList";
            ((System.ComponentModel.ISupportInitialize)(this.show_loaded_data)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView show_loaded_data;
        private System.Windows.Forms.Button Compare_DB_Button;
        private System.Windows.Forms.Button Excel_Button;
        private System.Windows.Forms.Button Load_DB_Button;
        private System.Windows.Forms.Button Save_DB_Button;
        private System.Windows.Forms.Button Save_Record_Button;
        private System.Windows.Forms.Label data_set_label;
    }
}

