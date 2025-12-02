namespace AIS.Forms
{
    partial class AddSubject
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
            txtSubject = new TextBox();
            btnCreateSubject = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            cmbTeacher = new ComboBox();
            SuspendLayout();
            // 
            // txtSubject
            // 
            txtSubject.Location = new Point(334, 181);
            txtSubject.Name = "txtSubject";
            txtSubject.PlaceholderText = "Subject";
            txtSubject.Size = new Size(121, 23);
            txtSubject.TabIndex = 10;
            txtSubject.TextChanged += txtStudentGroup_TextChanged;
            // 
            // btnCreateSubject
            // 
            btnCreateSubject.Location = new Point(334, 283);
            btnCreateSubject.Name = "btnCreateSubject";
            btnCreateSubject.Size = new Size(75, 23);
            btnCreateSubject.TabIndex = 9;
            btnCreateSubject.Text = "Create";
            btnCreateSubject.UseVisualStyleBackColor = true;
            btnCreateSubject.Click += btnCreateSubject_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // cmbTeacher
            // 
            cmbTeacher.FormattingEnabled = true;
            cmbTeacher.Location = new Point(334, 229);
            cmbTeacher.Name = "cmbTeacher";
            cmbTeacher.Size = new Size(121, 23);
            cmbTeacher.TabIndex = 11;
            cmbTeacher.SelectedIndexChanged += cmbTeacher_SelectedIndexChanged;
            // 
            // AddSubject
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cmbTeacher);
            Controls.Add(txtSubject);
            Controls.Add(btnCreateSubject);
            Name = "AddSubject";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddSubject";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtSubject;
        private Button btnCreateSubject;
        private ContextMenuStrip contextMenuStrip1;
        private ComboBox cmbTeacher;
    }
}