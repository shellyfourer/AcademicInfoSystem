namespace AIS.Forms
{
    partial class StudentGroupInformation
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
            dataGridView1 = new DataGridView();
            btnAddSubjet = new Button();
            btnDeleteGroup = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(51, 44);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(709, 299);
            dataGridView1.TabIndex = 7;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick_1;
            // 
            // btnAddSubjet
            // 
            btnAddSubjet.Location = new Point(40, 383);
            btnAddSubjet.Name = "btnAddSubjet";
            btnAddSubjet.Size = new Size(187, 23);
            btnAddSubjet.TabIndex = 6;
            btnAddSubjet.Text = "Add Subject";
            btnAddSubjet.UseVisualStyleBackColor = true;
            btnAddSubjet.Click += btnAddSubjet_Click;
            // 
            // btnDeleteGroup
            // 
            btnDeleteGroup.Location = new Point(573, 383);
            btnDeleteGroup.Name = "btnDeleteGroup";
            btnDeleteGroup.Size = new Size(187, 23);
            btnDeleteGroup.TabIndex = 8;
            btnDeleteGroup.Text = "Delete Group";
            btnDeleteGroup.UseVisualStyleBackColor = true;
            btnDeleteGroup.Click += btnBack_Click;
            // 
            // StudentGroupInformation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDeleteGroup);
            Controls.Add(dataGridView1);
            Controls.Add(btnAddSubjet);
            Name = "StudentGroupInformation";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "StudentGroupInformation";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView dataGridView1;
        private Button btnAddSubjet;
        private Button btnDeleteGroup;
    }
}