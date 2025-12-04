namespace AIS.Forms.Admin.GroupActions
{
    partial class EditDeleteSubject
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
            labelGroup = new Label();
            labelLastName = new Label();
            labelName = new Label();
            txtSubject = new TextBox();
            btnEditSubject = new Button();
            btnDeleteSubject = new Button();
            cmbTeacher = new ComboBox();
            cmbGroup = new ComboBox();
            SuspendLayout();
            // 
            // labelGroup
            // 
            labelGroup.AutoSize = true;
            labelGroup.Location = new Point(283, 262);
            labelGroup.Name = "labelGroup";
            labelGroup.Size = new Size(40, 15);
            labelGroup.TabIndex = 17;
            labelGroup.Text = "Group";
            // 
            // labelLastName
            // 
            labelLastName.AutoSize = true;
            labelLastName.Location = new Point(283, 197);
            labelLastName.Name = "labelLastName";
            labelLastName.Size = new Size(48, 15);
            labelLastName.TabIndex = 16;
            labelLastName.Text = "Teacher";
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(283, 137);
            labelName.Name = "labelName";
            labelName.Size = new Size(46, 15);
            labelName.TabIndex = 15;
            labelName.Text = "Subject";
            labelName.Click += labelName_Click;
            // 
            // txtSubject
            // 
            txtSubject.Location = new Point(399, 134);
            txtSubject.Name = "txtSubject";
            txtSubject.Size = new Size(121, 23);
            txtSubject.TabIndex = 12;
            txtSubject.TextChanged += txtSubject_TextChanged;
            // 
            // btnEditSubject
            // 
            btnEditSubject.Location = new Point(418, 408);
            btnEditSubject.Name = "btnEditSubject";
            btnEditSubject.Size = new Size(166, 23);
            btnEditSubject.TabIndex = 11;
            btnEditSubject.Text = "Confirm Changes";
            btnEditSubject.UseVisualStyleBackColor = true;
            btnEditSubject.Click += btnEditSubject_Click;
            // 
            // btnDeleteSubject
            // 
            btnDeleteSubject.Location = new Point(605, 408);
            btnDeleteSubject.Name = "btnDeleteSubject";
            btnDeleteSubject.Size = new Size(166, 23);
            btnDeleteSubject.TabIndex = 10;
            btnDeleteSubject.Text = "Delete Subject";
            btnDeleteSubject.UseVisualStyleBackColor = true;
            btnDeleteSubject.Click += btnDeleteSubject_Click_1;
            // 
            // cmbTeacher
            // 
            cmbTeacher.FormattingEnabled = true;
            cmbTeacher.Location = new Point(399, 189);
            cmbTeacher.Name = "cmbTeacher";
            cmbTeacher.Size = new Size(121, 23);
            cmbTeacher.TabIndex = 18;
            cmbTeacher.SelectedIndexChanged += cmbTeacher_SelectedIndexChanged;
            // 
            // cmbGroup
            // 
            cmbGroup.FormattingEnabled = true;
            cmbGroup.Location = new Point(399, 254);
            cmbGroup.Name = "cmbGroup";
            cmbGroup.Size = new Size(121, 23);
            cmbGroup.TabIndex = 19;
            // 
            // EditDeleteSubject
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cmbGroup);
            Controls.Add(cmbTeacher);
            Controls.Add(labelGroup);
            Controls.Add(labelLastName);
            Controls.Add(labelName);
            Controls.Add(txtSubject);
            Controls.Add(btnEditSubject);
            Controls.Add(btnDeleteSubject);
            Name = "EditDeleteSubject";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EditDeleteSubject";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelGroup;
        private Label labelLastName;
        private Label labelName;
        private TextBox txtLastName;
        private TextBox txtGroup;
        private TextBox txtSubject;
        private Button btnEditStudent;
        private Button btnDeleteSubject;
        private ComboBox cmbTeacher;
        private ComboBox cmbGroup;
        private Button btnEditSubject;
    }
}