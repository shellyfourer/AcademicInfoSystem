namespace AIS.Forms
{
    partial class EditDeleteTeacher
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
            labelLastName = new Label();
            labelName = new Label();
            label1 = new Label();
            txtLastName = new TextBox();
            txtFirstName = new TextBox();
            btnEditTeacher = new Button();
            btnDeleteTeacher = new Button();
            SuspendLayout();
            // 
            // labelLastName
            // 
            labelLastName.AutoSize = true;
            labelLastName.Location = new Point(298, 237);
            labelLastName.Name = "labelLastName";
            labelLastName.Size = new Size(63, 15);
            labelLastName.TabIndex = 17;
            labelLastName.Text = "Last Name";
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(298, 182);
            labelName.Name = "labelName";
            labelName.Size = new Size(39, 15);
            labelName.TabIndex = 16;
            labelName.Text = "Name";
            labelName.Click += labelName_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 13);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 15;
            label1.Text = "label1";
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(414, 234);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(100, 23);
            txtLastName.TabIndex = 14;
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(414, 179);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(100, 23);
            txtFirstName.TabIndex = 12;
            // 
            // btnEditTeacher
            // 
            btnEditTeacher.Location = new Point(436, 415);
            btnEditTeacher.Name = "btnEditTeacher";
            btnEditTeacher.Size = new Size(166, 23);
            btnEditTeacher.TabIndex = 11;
            btnEditTeacher.Text = "Confirm Changes";
            btnEditTeacher.UseVisualStyleBackColor = true;
            btnEditTeacher.Click += btnEditStudent_Click;
            // 
            // btnDeleteTeacher
            // 
            btnDeleteTeacher.Location = new Point(623, 415);
            btnDeleteTeacher.Name = "btnDeleteTeacher";
            btnDeleteTeacher.Size = new Size(166, 23);
            btnDeleteTeacher.TabIndex = 10;
            btnDeleteTeacher.Text = "Delete Teacher";
            btnDeleteTeacher.UseVisualStyleBackColor = true;
            btnDeleteTeacher.Click += btnDeleteTeacher_Click;
            // 
            // EditDeleteTeacher
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(labelLastName);
            Controls.Add(labelName);
            Controls.Add(label1);
            Controls.Add(txtLastName);
            Controls.Add(txtFirstName);
            Controls.Add(btnEditTeacher);
            Controls.Add(btnDeleteTeacher);
            Name = "EditDeleteTeacher";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EditDeleteTeacher";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelLastName;
        private Label labelName;
        private Label label1;
        private TextBox txtLastName;
        private TextBox txtFirstName;
        private Button btnEditTeacher;
        private Button btnDeleteTeacher;
    }
}