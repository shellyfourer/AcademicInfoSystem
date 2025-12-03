namespace AIS.Forms.Teacher
{
    partial class AssignGrades
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
            cmbGrades = new ComboBox();
            btnUpdateGrade = new Button();
            label3 = new Label();
            SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // cmbGrades
            // 
            cmbGrades.FormattingEnabled = true;
            cmbGrades.Location = new Point(340, 192);
            cmbGrades.Name = "cmbGrades";
            cmbGrades.Size = new Size(121, 23);
            cmbGrades.TabIndex = 8;
            cmbGrades.SelectedIndexChanged += cmbGrades_SelectedIndexChanged;
            // 
            // btnUpdateGrade
            // 
            btnUpdateGrade.Location = new Point(340, 244);
            btnUpdateGrade.Name = "btnUpdateGrade";
            btnUpdateGrade.Size = new Size(75, 23);
            btnUpdateGrade.TabIndex = 7;
            btnUpdateGrade.Text = "Update";
            btnUpdateGrade.UseVisualStyleBackColor = true;
            btnUpdateGrade.Click += btnUpdateGrade_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(267, 200);
            label3.Name = "label3";
            label3.Size = new Size(41, 15);
            label3.TabIndex = 11;
            label3.Text = "Grade:";
            label3.Click += label3_Click;
            // 
            // AssignGrades
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(cmbGrades);
            Controls.Add(btnUpdateGrade);
            Name = "AssignGrades";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AssignGrades";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ContextMenuStrip contextMenuStrip1;
        private ComboBox cmbGrades;
        private Button btnUpdateGrade;
        private Label label3;
    }
}