
namespace OgrenciBilgiKayit
{
    partial class AnaForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDersKaydi = new System.Windows.Forms.Button();
            this.btnSinavSonuclari = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(204, 199);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 45);
            this.button1.TabIndex = 0;
            this.button1.Text = "Öğrenci Kayıt";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnKayit_click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(461, 199);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 45);
            this.button2.TabIndex = 1;
            this.button2.Text = "Öğrenci Sorgulama";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnSorgulama_click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(182, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(431, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Lütfen yapmak istediğiniz işlemi seçiniz\r\n";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnDersKaydi
            // 
            this.btnDersKaydi.Location = new System.Drawing.Point(204, 301);
            this.btnDersKaydi.Name = "btnDersKaydi";
            this.btnDersKaydi.Size = new System.Drawing.Size(105, 44);
            this.btnDersKaydi.TabIndex = 3;
            this.btnDersKaydi.Text = "Ders Kaydı";
            this.btnDersKaydi.UseVisualStyleBackColor = true;
            this.btnDersKaydi.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnSinavSonuclari
            // 
            this.btnSinavSonuclari.Location = new System.Drawing.Point(461, 301);
            this.btnSinavSonuclari.Name = "btnSinavSonuclari";
            this.btnSinavSonuclari.Size = new System.Drawing.Size(105, 44);
            this.btnSinavSonuclari.TabIndex = 4;
            this.btnSinavSonuclari.Text = "Sınav Sonuçları";
            this.btnSinavSonuclari.UseVisualStyleBackColor = true;
            this.btnSinavSonuclari.Click += new System.EventHandler(this.btnSinavSonuclari_Click);
            // 
            // AnaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSinavSonuclari);
            this.Controls.Add(this.btnDersKaydi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "AnaForm";
            this.Text = "AnaForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDersKaydi;
        private System.Windows.Forms.Button btnSinavSonuclari;
    }
}