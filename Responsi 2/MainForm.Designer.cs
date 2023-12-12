namespace Responsi_2
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            InsertButton = new Button();
            EditButton = new Button();
            DeleteButton = new Button();
            NamaKaryawan = new TextBox();
            label1 = new Label();
            label2 = new Label();
            DataViewer = new DataGridView();
            ListDepartemen = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)DataViewer).BeginInit();
            SuspendLayout();
            // 
            // InsertButton
            // 
            InsertButton.Location = new Point(12, 73);
            InsertButton.Name = "InsertButton";
            InsertButton.Size = new Size(75, 23);
            InsertButton.TabIndex = 0;
            InsertButton.Text = "Insert";
            InsertButton.UseVisualStyleBackColor = true;
            InsertButton.Click += InsertButton_Click;
            // 
            // EditButton
            // 
            EditButton.Location = new Point(169, 73);
            EditButton.Name = "EditButton";
            EditButton.Size = new Size(75, 23);
            EditButton.TabIndex = 1;
            EditButton.Text = "Edit";
            EditButton.UseVisualStyleBackColor = true;
            EditButton.Click += EditButton_Click;
            // 
            // DeleteButton
            // 
            DeleteButton.Location = new Point(319, 68);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(75, 23);
            DeleteButton.TabIndex = 2;
            DeleteButton.Text = "Delete";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // NamaKaryawan
            // 
            NamaKaryawan.Location = new Point(96, 10);
            NamaKaryawan.Name = "NamaKaryawan";
            NamaKaryawan.Size = new Size(302, 23);
            NamaKaryawan.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 13);
            label1.Name = "label1";
            label1.Size = new Size(64, 15);
            label1.TabIndex = 5;
            label1.Text = "Karyawan :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 42);
            label2.Name = "label2";
            label2.Size = new Size(78, 15);
            label2.TabIndex = 6;
            label2.Text = "Departemen :";
            // 
            // DataViewer
            // 
            DataViewer.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataViewer.Location = new Point(12, 102);
            DataViewer.Name = "DataViewer";
            DataViewer.RowTemplate.Height = 25;
            DataViewer.Size = new Size(386, 150);
            DataViewer.TabIndex = 7;
            DataViewer.CellClick += DataViewer_CellClick;
            // 
            // ListDepartemen
            // 
            ListDepartemen.FormattingEnabled = true;
            ListDepartemen.Location = new Point(96, 39);
            ListDepartemen.Name = "ListDepartemen";
            ListDepartemen.Size = new Size(302, 23);
            ListDepartemen.TabIndex = 8;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(406, 259);
            Controls.Add(ListDepartemen);
            Controls.Add(DataViewer);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(NamaKaryawan);
            Controls.Add(DeleteButton);
            Controls.Add(EditButton);
            Controls.Add(InsertButton);
            Name = "MainForm";
            Text = "Application";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)DataViewer).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button InsertButton;
        private Button EditButton;
        private Button DeleteButton;
        private TextBox NamaKaryawan;
        private Label label1;
        private Label label2;
        private DataGridView DataViewer;
        private ComboBox ListDepartemen;
    }
}