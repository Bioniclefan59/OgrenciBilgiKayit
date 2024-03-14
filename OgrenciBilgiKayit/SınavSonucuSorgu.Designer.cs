
namespace OgrenciBilgiKayit
{
    partial class SınavSonucuSorgu
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtOgrenciIsmi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOgrenciNo = new System.Windows.Forms.TextBox();
            this.btnSorgula = new System.Windows.Forms.Button();
            this.dgvSinavSonuclari = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinavSonuclari)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(89, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Öğrenci İsmi:";
            // 
            // txtOgrenciIsmi
            // 
            this.txtOgrenciIsmi.Location = new System.Drawing.Point(237, 12);
            this.txtOgrenciIsmi.Name = "txtOgrenciIsmi";
            this.txtOgrenciIsmi.Size = new System.Drawing.Size(100, 22);
            this.txtOgrenciIsmi.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(402, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "Öğrenci No:";
            // 
            // txtOgrenciNo
            // 
            this.txtOgrenciNo.Location = new System.Drawing.Point(537, 13);
            this.txtOgrenciNo.Name = "txtOgrenciNo";
            this.txtOgrenciNo.Size = new System.Drawing.Size(100, 22);
            this.txtOgrenciNo.TabIndex = 3;
            // 
            // btnSorgula
            // 
            this.btnSorgula.Location = new System.Drawing.Point(344, 85);
            this.btnSorgula.Name = "btnSorgula";
            this.btnSorgula.Size = new System.Drawing.Size(75, 23);
            this.btnSorgula.TabIndex = 4;
            this.btnSorgula.Text = "Sorgula";
            this.btnSorgula.UseVisualStyleBackColor = true;
            this.btnSorgula.Click += new System.EventHandler(this.btnSorgula_Click);
            // 
            // dgvSinavSonuclari
            // 
            this.dgvSinavSonuclari.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSinavSonuclari.Location = new System.Drawing.Point(12, 149);
            this.dgvSinavSonuclari.Name = "dgvSinavSonuclari";
            this.dgvSinavSonuclari.RowHeadersWidth = 51;
            this.dgvSinavSonuclari.RowTemplate.Height = 24;
            this.dgvSinavSonuclari.Size = new System.Drawing.Size(775, 300);
            this.dgvSinavSonuclari.TabIndex = 5;
            // 
            // SınavSonucuSorgu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvSinavSonuclari);
            this.Controls.Add(this.btnSorgula);
            this.Controls.Add(this.txtOgrenciNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtOgrenciIsmi);
            this.Controls.Add(this.label1);
            this.Name = "SınavSonucuSorgu";
            this.Text = "SınavSonucuSorgu";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinavSonuclari)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOgrenciIsmi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOgrenciNo;
        private System.Windows.Forms.Button btnSorgula;
        private System.Windows.Forms.DataGridView dgvSinavSonuclari;
    }
}