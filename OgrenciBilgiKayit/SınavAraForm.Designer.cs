
namespace OgrenciBilgiKayit
{
    partial class SınavAraForm
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
            this.btnSinavSonucuKaydi = new System.Windows.Forms.Button();
            this.btnSinavSonucuSorgu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(112, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(570, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sınav sonucu girişi mi yoksa sınav sonucu sorgulama mı?";
            // 
            // btnSinavSonucuKaydi
            // 
            this.btnSinavSonucuKaydi.Location = new System.Drawing.Point(178, 179);
            this.btnSinavSonucuKaydi.Name = "btnSinavSonucuKaydi";
            this.btnSinavSonucuKaydi.Size = new System.Drawing.Size(88, 62);
            this.btnSinavSonucuKaydi.TabIndex = 1;
            this.btnSinavSonucuKaydi.Text = "Sınav Sonucu Kaydı";
            this.btnSinavSonucuKaydi.UseVisualStyleBackColor = true;
            this.btnSinavSonucuKaydi.Click += new System.EventHandler(this.btnSinavSonucuKaydi_Click);
            // 
            // btnSinavSonucuSorgu
            // 
            this.btnSinavSonucuSorgu.Location = new System.Drawing.Point(471, 179);
            this.btnSinavSonucuSorgu.Name = "btnSinavSonucuSorgu";
            this.btnSinavSonucuSorgu.Size = new System.Drawing.Size(88, 62);
            this.btnSinavSonucuSorgu.TabIndex = 2;
            this.btnSinavSonucuSorgu.Text = "Sınav Sonucu Sorgulama";
            this.btnSinavSonucuSorgu.UseVisualStyleBackColor = true;
            this.btnSinavSonucuSorgu.Click += new System.EventHandler(this.btnSinavSonucuSorgu_Click);
            // 
            // SınavAraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSinavSonucuSorgu);
            this.Controls.Add(this.btnSinavSonucuKaydi);
            this.Controls.Add(this.label1);
            this.Name = "SınavAraForm";
            this.Text = "SınavAraForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSinavSonucuKaydi;
        private System.Windows.Forms.Button btnSinavSonucuSorgu;
    }
}