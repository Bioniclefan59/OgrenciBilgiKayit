
namespace OgrenciBilgiKayit
{
    partial class DersListesi
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
            this.dgvDersListesi = new System.Windows.Forms.DataGridView();
            this.btnSec = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDersListesi)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDersListesi
            // 
            this.dgvDersListesi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDersListesi.Location = new System.Drawing.Point(13, 13);
            this.dgvDersListesi.Name = "dgvDersListesi";
            this.dgvDersListesi.RowHeadersWidth = 51;
            this.dgvDersListesi.RowTemplate.Height = 24;
            this.dgvDersListesi.Size = new System.Drawing.Size(775, 380);
            this.dgvDersListesi.TabIndex = 0;
            // 
            // btnSec
            // 
            this.btnSec.Location = new System.Drawing.Point(347, 399);
            this.btnSec.Name = "btnSec";
            this.btnSec.Size = new System.Drawing.Size(75, 23);
            this.btnSec.TabIndex = 1;
            this.btnSec.Text = "Seç";
            this.btnSec.UseVisualStyleBackColor = true;
            this.btnSec.Click += new System.EventHandler(this.btnSec_Click);
            // 
            // DersListesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSec);
            this.Controls.Add(this.dgvDersListesi);
            this.Name = "DersListesi";
            this.Text = "DersListesi";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDersListesi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDersListesi;
        private System.Windows.Forms.Button btnSec;
    }
}