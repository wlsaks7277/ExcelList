namespace LineList
{
    partial class Data_save
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
            this.userName = new System.Windows.Forms.Label();
            this.date = new System.Windows.Forms.Label();
            this.comment = new System.Windows.Forms.Label();
            this.user_name_textbox = new System.Windows.Forms.TextBox();
            this.comment_textbox = new System.Windows.Forms.TextBox();
            this.save_data_button = new System.Windows.Forms.Button();
            this.date_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // userName
            // 
            this.userName.AutoSize = true;
            this.userName.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.userName.Location = new System.Drawing.Point(45, 79);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(122, 20);
            this.userName.TabIndex = 0;
            this.userName.Text = "사용자 이름";
            // 
            // date
            // 
            this.date.AutoSize = true;
            this.date.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.date.Location = new System.Drawing.Point(45, 160);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(51, 20);
            this.date.TabIndex = 1;
            this.date.Text = "날짜";
            // 
            // comment
            // 
            this.comment.AutoSize = true;
            this.comment.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.comment.Location = new System.Drawing.Point(45, 245);
            this.comment.Name = "comment";
            this.comment.Size = new System.Drawing.Size(97, 20);
            this.comment.TabIndex = 2;
            this.comment.Text = "Comment";
            // 
            // user_name_textbox
            // 
            this.user_name_textbox.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.user_name_textbox.Location = new System.Drawing.Point(187, 75);
            this.user_name_textbox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.user_name_textbox.Name = "user_name_textbox";
            this.user_name_textbox.Size = new System.Drawing.Size(241, 30);
            this.user_name_textbox.TabIndex = 3;
            // 
            // comment_textbox
            // 
            this.comment_textbox.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.comment_textbox.Location = new System.Drawing.Point(187, 245);
            this.comment_textbox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comment_textbox.Multiline = true;
            this.comment_textbox.Name = "comment_textbox";
            this.comment_textbox.Size = new System.Drawing.Size(241, 103);
            this.comment_textbox.TabIndex = 5;
            // 
            // save_data_button
            // 
            this.save_data_button.Location = new System.Drawing.Point(175, 400);
            this.save_data_button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.save_data_button.Name = "save_data_button";
            this.save_data_button.Size = new System.Drawing.Size(127, 35);
            this.save_data_button.TabIndex = 6;
            this.save_data_button.Text = "저장";
            this.save_data_button.UseVisualStyleBackColor = true;
            this.save_data_button.Click += new System.EventHandler(this.save_button_Click);
            // 
            // date_label
            // 
            this.date_label.AutoSize = true;
            this.date_label.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.date_label.Location = new System.Drawing.Point(184, 160);
            this.date_label.Name = "date_label";
            this.date_label.Size = new System.Drawing.Size(119, 20);
            this.date_label.TabIndex = 7;
            this.date_label.Text = "2020-04-07";
            // 
            // Data_save
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 468);
            this.Controls.Add(this.date_label);
            this.Controls.Add(this.save_data_button);
            this.Controls.Add(this.comment_textbox);
            this.Controls.Add(this.user_name_textbox);
            this.Controls.Add(this.comment);
            this.Controls.Add(this.date);
            this.Controls.Add(this.userName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Data_save";
            this.Text = "DB 저장하기";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label userName;
        private System.Windows.Forms.Label date;
        private System.Windows.Forms.Label comment;
        private System.Windows.Forms.TextBox user_name_textbox;
        private System.Windows.Forms.TextBox comment_textbox;
        private System.Windows.Forms.Button save_data_button;
        private System.Windows.Forms.Label date_label;
    }
}