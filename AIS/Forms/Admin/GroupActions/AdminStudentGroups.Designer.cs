namespace AIS.Forms
{
    partial class AdminStudentGroups
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
            btnBack = new Button();
            dataGridView1 = new DataGridView();
            btnAddGroup = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnBack
            // 
            btnBack.Location = new Point(573, 383);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(187, 23);
            btnBack.TabIndex = 5;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(51, 44);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(709, 299);
            dataGridView1.TabIndex = 4;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // btnAddGroup
            // 
            btnAddGroup.Location = new Point(40, 383);
            btnAddGroup.Name = "btnAddGroup";
            btnAddGroup.Size = new Size(187, 23);
            btnAddGroup.TabIndex = 3;
            btnAddGroup.Text = "Create Student Group";
            btnAddGroup.UseVisualStyleBackColor = true;
            btnAddGroup.Click += btnAddGroup_Click;
            // 
            // AdminStudentGroups
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnBack);
            Controls.Add(dataGridView1);
            Controls.Add(btnAddGroup);
            Name = "AdminStudentGroups";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AdminStudentGroups";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnBack;
        private DataGridView dataGridView1;
        private Button btnAddGroup;
    }
}