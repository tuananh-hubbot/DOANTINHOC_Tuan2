namespace QuanLiHeThongSucKhoeVaCanBangMXH
{
    partial class MainForm
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
            this.btnDocCSV = new System.Windows.Forms.Button();
            this.dgvKetQua = new System.Windows.Forms.DataGridView();
            this.btnDocFile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDocCSV
            // 
            this.btnDocCSV.Location = new System.Drawing.Point(685, 37);
            this.btnDocCSV.Name = "btnDocCSV";
            this.btnDocCSV.Size = new System.Drawing.Size(87, 40);
            this.btnDocCSV.TabIndex = 0;
            this.btnDocCSV.Text = "Loading";
            this.btnDocCSV.UseVisualStyleBackColor = true;
            this.btnDocCSV.Click += new System.EventHandler(this.btnDocCSV_Click);
            // 
            // dgvKetQua
            // 
            this.dgvKetQua.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKetQua.Location = new System.Drawing.Point(24, 25);
            this.dgvKetQua.Name = "dgvKetQua";
            this.dgvKetQua.RowHeadersWidth = 62;
            this.dgvKetQua.RowTemplate.Height = 28;
            this.dgvKetQua.Size = new System.Drawing.Size(636, 346);
            this.dgvKetQua.TabIndex = 1;
            // 
            // btnDocFile
            // 
            this.btnDocFile.Location = new System.Drawing.Point(232, 396);
            this.btnDocFile.Name = "btnDocFile";
            this.btnDocFile.Size = new System.Drawing.Size(172, 33);
            this.btnDocFile.TabIndex = 2;
            this.btnDocFile.Text = "Đọc dữ liệu từ CSV\r\n\r\n";
            this.btnDocFile.UseVisualStyleBackColor = true;
            this.btnDocFile.Click += new System.EventHandler(this.btnDocFile_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnDocFile);
            this.Controls.Add(this.dgvKetQua);
            this.Controls.Add(this.btnDocCSV);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDocCSV;
        private System.Windows.Forms.DataGridView dgvKetQua;
        private System.Windows.Forms.Button btnDocFile;
    }
}

