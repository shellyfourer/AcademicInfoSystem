namespace AIS.Forms
{
    partial class EditDeleteStudent
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
            btnDeleteStudent = new Button();
            btnEditStudent = new Button();
            txtFirstName = new TextBox();
            txtLastName = new TextBox();
            labelName = new Label();
            labelLastName = new Label();
            labelGroup = new Label();
            cmbGroup = new ComboBox();
            SuspendLayout();
            // 
            // btnDeleteStudent
            // 
            btnDeleteStudent.Location = new Point(612, 402);
            btnDeleteStudent.Name = "btnDeleteStudent";
            btnDeleteStudent.Size = new Size(166, 23);
            btnDeleteStudent.TabIndex = 1;
            btnDeleteStudent.Text = "Delete Student";
            btnDeleteStudent.UseVisualStyleBackColor = true;
            btnDeleteStudent.Click += btnDeleteStudent_Click;
            // 
            // btnEditStudent
            // 
            btnEditStudent.Location = new Point(425, 402);
            btnEditStudent.Name = "btnEditStudent";
            btnEditStudent.Size = new Size(166, 23);
            btnEditStudent.TabIndex = 2;
            btnEditStudent.Text = "Confirm Changes";
            btnEditStudent.UseVisualStyleBackColor = true;
            btnEditStudent.Click += btnEditStudent_Click;
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(406, 128);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(100, 23);
            txtFirstName.TabIndex = 3;
            txtFirstName.TextChanged += txtFirstName_TextChanged;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(406, 183);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(100, 23);
            txtLastName.TabIndex = 5;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(290, 131);
            labelName.Name = "labelName";
            labelName.Size = new Size(39, 15);
            labelName.TabIndex = 7;
            labelName.Text = "Name";
            // 
            // labelLastName
            // 
            labelLastName.AutoSize = true;
            labelLastName.Location = new Point(290, 186);
            labelLastName.Name = "labelLastName";
            labelLastName.Size = new Size(63, 15);
            labelLastName.TabIndex = 8;
            labelLastName.Text = "Last Name";
            // 
            // labelGroup
            // 
            labelGroup.AutoSize = true;
            labelGroup.Location = new Point(290, 256);
            labelGroup.Name = "labelGroup";
            labelGroup.Size = new Size(40, 15);
            labelGroup.TabIndex = 9;
            labelGroup.Text = "Group";
            // 
            // cmbGroup
            // 
            cmbGroup.FormattingEnabled = true;
            cmbGroup.Location = new Point(406, 248);
            cmbGroup.Name = "cmbGroup";
            cmbGroup.Size = new Size(121, 23);
            cmbGroup.TabIndex = 10;
            cmbGroup.SelectedIndexChanged += cmbGroup_SelectedIndexChanged;
            // 
            // EditDeleteStudent
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cmbGroup);
            Controls.Add(labelGroup);
            Controls.Add(labelLastName);
            Controls.Add(labelName);
            Controls.Add(txtLastName);
            Controls.Add(txtFirstName);
            Controls.Add(btnEditStudent);
            Controls.Add(btnDeleteStudent);
            Name = "EditDeleteStudent";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EditDeleteStudent";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnDeleteStudent;
        private Button btnEditStudent;
        private TextBox txtFirstName;
        private TextBox txtLastName;
        private Label labelName;
        private Label labelLastName;
        private Label labelGroup;
        private ComboBox cmbGroup;
    }
}