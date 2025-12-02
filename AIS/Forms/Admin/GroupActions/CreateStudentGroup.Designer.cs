namespace AIS.Forms
{
    partial class CreateStudentGroup
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
            txtStudentGroup = new TextBox();
            btnCreateStudent = new Button();
            SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // txtStudentGroup
            // 
            txtStudentGroup.Location = new Point(335, 197);
            txtStudentGroup.Name = "txtStudentGroup";
            txtStudentGroup.PlaceholderText = "Group Name";
            txtStudentGroup.Size = new Size(121, 23);
            txtStudentGroup.TabIndex = 8;
            txtStudentGroup.TextChanged += txtStudentGroup_TextChanged;
            // 
            // btnCreateStudent
            // 
            btnCreateStudent.Location = new Point(335, 242);
            btnCreateStudent.Name = "btnCreateStudent";
            btnCreateStudent.Size = new Size(75, 23);
            btnCreateStudent.TabIndex = 7;
            btnCreateStudent.Text = "Create";
            btnCreateStudent.UseVisualStyleBackColor = true;
            btnCreateStudent.Click += btnCreateStudent_Click;
            // 
            // CreateStudentGroup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtStudentGroup);
            Controls.Add(btnCreateStudent);
            Name = "CreateStudentGroup";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CreateStudentGroup";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ContextMenuStrip contextMenuStrip1;
        private TextBox txtStudentGroup;
        private Button btnCreateStudent;
    }
}