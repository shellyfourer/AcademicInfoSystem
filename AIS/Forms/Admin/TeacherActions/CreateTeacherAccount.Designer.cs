namespace AIS.Forms
{
    partial class CreateTeacherAccount
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
            txtFirstName = new TextBox();
            txtLastName = new TextBox();
            btnCreateStudent = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            SuspendLayout();
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(338, 174);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.PlaceholderText = "First Name";
            txtFirstName.Size = new Size(121, 23);
            txtFirstName.TabIndex = 5;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(338, 222);
            txtLastName.Name = "txtLastName";
            txtLastName.PlaceholderText = "Last Name";
            txtLastName.Size = new Size(121, 23);
            txtLastName.TabIndex = 6;
            // 
            // btnCreateStudent
            // 
            btnCreateStudent.Location = new Point(338, 266);
            btnCreateStudent.Name = "btnCreateStudent";
            btnCreateStudent.Size = new Size(75, 23);
            btnCreateStudent.TabIndex = 7;
            btnCreateStudent.Text = "Create";
            btnCreateStudent.UseVisualStyleBackColor = true;
            btnCreateStudent.Click += btnCreateStudent_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // CreateTeacherAccount
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCreateStudent);
            Controls.Add(txtLastName);
            Controls.Add(txtFirstName);
            Name = "CreateTeacherAccount";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CreateTeacherAccount";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtFirstName;
        private TextBox txtLastName;
        private Button btnCreateStudent;
        private ContextMenuStrip contextMenuStrip1;
    }
}