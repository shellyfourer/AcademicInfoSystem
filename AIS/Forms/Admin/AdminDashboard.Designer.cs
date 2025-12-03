namespace AIS.Forms
{
    partial class AdminDashboard
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
            btnStudentAccounts = new Button();
            btnTeacherAccounts = new Button();
            btnStudentGroups = new Button();
            SuspendLayout();
            // 
            // btnStudentAccounts
            // 
            btnStudentAccounts.Location = new Point(289, 187);
            btnStudentAccounts.Name = "btnStudentAccounts";
            btnStudentAccounts.Size = new Size(202, 23);
            btnStudentAccounts.TabIndex = 0;
            btnStudentAccounts.Text = "Student Accounts";
            btnStudentAccounts.UseVisualStyleBackColor = true;
            btnStudentAccounts.Click += btnStudentAccounts_Click;
            // 
            // btnTeacherAccounts
            // 
            btnTeacherAccounts.Location = new Point(289, 216);
            btnTeacherAccounts.Name = "btnTeacherAccounts";
            btnTeacherAccounts.Size = new Size(202, 23);
            btnTeacherAccounts.TabIndex = 1;
            btnTeacherAccounts.Text = "Teacher Accounts";
            btnTeacherAccounts.UseVisualStyleBackColor = true;
            btnTeacherAccounts.Click += btnTeacherAccounts_Click;
            // 
            // btnStudentGroups
            // 
            btnStudentGroups.Location = new Point(289, 245);
            btnStudentGroups.Name = "btnStudentGroups";
            btnStudentGroups.Size = new Size(202, 23);
            btnStudentGroups.TabIndex = 3;
            btnStudentGroups.Text = "Student Groups";
            btnStudentGroups.UseVisualStyleBackColor = true;
            btnStudentGroups.Click += btnStudentGroups_Click;
            // 
            // AdminDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnStudentGroups);
            Controls.Add(btnTeacherAccounts);
            Controls.Add(btnStudentAccounts);
            Name = "AdminDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AdminDashboard";
            Load += AdminDashboard_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnStudentAccounts;
        private Button btnTeacherAccounts;
        private Button btnStudentGroups;
    }
}