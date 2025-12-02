namespace AIS.Forms
{
    partial class CreateStudentAccount
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
            components = new System.ComponentModel.Container();
            contextMenuStrip1 = new ContextMenuStrip(components);
            txtFirstName = new TextBox();
            txtLastName = new TextBox();
            btnCreateStudent = new Button();
            cmbStudentGroup = new ComboBox();
            SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(323, 137);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.PlaceholderText = "First Name";
            txtFirstName.Size = new Size(121, 23);
            txtFirstName.TabIndex = 1;
            txtFirstName.TextChanged += txtFirstName_TextChanged;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(323, 185);
            txtLastName.Name = "txtLastName";
            txtLastName.PlaceholderText = "Last Name";
            txtLastName.Size = new Size(121, 23);
            txtLastName.TabIndex = 2;
            txtLastName.TextChanged += txtLastName_TextChanged;
            // 
            // btnCreateStudent
            // 
            btnCreateStudent.Location = new Point(323, 275);
            btnCreateStudent.Name = "btnCreateStudent";
            btnCreateStudent.Size = new Size(75, 23);
            btnCreateStudent.TabIndex = 3;
            btnCreateStudent.Text = "Create";
            btnCreateStudent.UseVisualStyleBackColor = true;
            btnCreateStudent.Click += btnCreateStudent_Click_1;
            // 
            // cmbStudentGroup
            // 
            cmbStudentGroup.FormattingEnabled = true;
            cmbStudentGroup.Location = new Point(323, 230);
            cmbStudentGroup.Name = "cmbStudentGroup";
            cmbStudentGroup.Size = new Size(121, 23);
            cmbStudentGroup.TabIndex = 4;
            cmbStudentGroup.SelectedIndexChanged += cmbStudentGroup_SelectedIndexChanged;
            // 
            // CreateStudentAccount
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cmbStudentGroup);
            Controls.Add(btnCreateStudent);
            Controls.Add(txtLastName);
            Controls.Add(txtFirstName);
            Name = "CreateStudentAccount";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CreateStudentAccount";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ContextMenuStrip contextMenuStrip1;
        private TextBox txtFirstName;
        private TextBox txtLastName;
        private Button btnCreateStudent;
        private ComboBox cmbStudentGroup;
    }
}