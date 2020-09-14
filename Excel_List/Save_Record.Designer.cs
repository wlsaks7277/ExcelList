namespace LineList
{
    partial class Save_Record
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
            this.save_record_view = new System.Windows.Forms.DataGridView();
            this.save_records_close = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.save_record_view)).BeginInit();
            this.SuspendLayout();
            // 
            // save_record_view
            // 
            this.save_record_view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.save_record_view.Location = new System.Drawing.Point(29, 27);
            this.save_record_view.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.save_record_view.Name = "save_record_view";
            this.save_record_view.RowTemplate.Height = 23;
            this.save_record_view.Size = new System.Drawing.Size(462, 291);
            this.save_record_view.TabIndex = 0;
            // 
            // save_records_close
            // 
            this.save_records_close.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.save_records_close.Location = new System.Drawing.Point(194, 346);
            this.save_records_close.Name = "save_records_close";
            this.save_records_close.Size = new System.Drawing.Size(129, 30);
            this.save_records_close.TabIndex = 1;
            this.save_records_close.Text = "확인";
            this.save_records_close.UseVisualStyleBackColor = true;
            this.save_records_close.Click += new System.EventHandler(this.save_records_close_Click);
            // 
            // Save_Record
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 399);
            this.Controls.Add(this.save_records_close);
            this.Controls.Add(this.save_record_view);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Save_Record";
            this.Text = "저장 이력";
            ((System.ComponentModel.ISupportInitialize)(this.save_record_view)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView save_record_view;
        private System.Windows.Forms.Button save_records_close;
    }
}