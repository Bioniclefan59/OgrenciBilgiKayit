
namespace OgrenciBilgiKayit
{
    partial class DersKaydi
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
            this.label3 = new System.Windows.Forms.Label();
            this.btnDersSec = new System.Windows.Forms.Button();
            this.txtSecilenDers = new System.Windows.Forms.TextBox();
            this.btnDersKaydet = new System.Windows.Forms.Button();
            this.btnIptal = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(69, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Öğrenci İsmi:";
            // 
            // txtOgrenciIsmi
            // 
            this.txtOgrenciIsmi.Location = new System.Drawing.Point(216, 46);
            this.txtOgrenciIsmi.Name = "txtOgrenciIsmi";
            this.txtOgrenciIsmi.Size = new System.Drawing.Size(100, 22);
            this.txtOgrenciIsmi.TabIndex = 1;
            this.txtOgrenciIsmi.TextChanged += new System.EventHandler(this.txtOgrenciIsmi_TextChanged_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(396, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "Öğrenci No:";
            // 
            // txtOgrenciNo
            // 
            this.txtOgrenciNo.Location = new System.Drawing.Point(530, 46);
            this.txtOgrenciNo.Name = "txtOgrenciNo";
            this.txtOgrenciNo.Size = new System.Drawing.Size(100, 22);
            this.txtOgrenciNo.TabIndex = 3;
            this.txtOgrenciNo.TextChanged += new System.EventHandler(this.txtOgrenciNo_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(211, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 26);
            this.label3.TabIndex = 4;
            this.label3.Text = "Dersler:";
            // 
            // btnDersSec
            // 
            this.btnDersSec.Location = new System.Drawing.Point(357, 224);
            this.btnDersSec.Name = "btnDersSec";
            this.btnDersSec.Size = new System.Drawing.Size(75, 23);
            this.btnDersSec.TabIndex = 5;
            this.btnDersSec.Text = "Ders Seç";
            this.btnDersSec.UseVisualStyleBackColor = true;
            this.btnDersSec.Click += new System.EventHandler(this.btnDersSec_Click);
            // 
            // txtSecilenDers
            // 
            this.txtSecilenDers.Location = new System.Drawing.Point(305, 196);
            this.txtSecilenDers.Name = "txtSecilenDers";
            this.txtSecilenDers.Size = new System.Drawing.Size(181, 22);
            this.txtSecilenDers.TabIndex = 6;
            // 
            // btnDersKaydet
            // 
            this.btnDersKaydet.Location = new System.Drawing.Point(241, 335);
            this.btnDersKaydet.Name = "btnDersKaydet";
            this.btnDersKaydet.Size = new System.Drawing.Size(82, 39);
            this.btnDersKaydet.TabIndex = 7;
            this.btnDersKaydet.Text = "Kaydet";
            this.btnDersKaydet.UseVisualStyleBackColor = true;
            this.btnDersKaydet.Click += new System.EventHandler(this.btnDersKaydet_Click);
            // 
            // btnIptal
            // 
            this.btnIptal.Location = new System.Drawing.Point(401, 335);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(85, 38);
            this.btnIptal.TabIndex = 8;
            this.btnIptal.Text = "İptal";
            this.btnIptal.UseVisualStyleBackColor = true;
            // 
            // DersKaydi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnIptal);
            this.Controls.Add(this.btnDersKaydet);
            this.Controls.Add(this.txtSecilenDers);
            this.Controls.Add(this.btnDersSec);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtOgrenciNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtOgrenciIsmi);
            this.Controls.Add(this.label1);
            this.Name = "DersKaydi";
            this.Text = "DersKaydi";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOgrenciIsmi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOgrenciNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDersSec;
        private System.Windows.Forms.TextBox txtSecilenDers;
        private System.Windows.Forms.Button btnDersKaydet;
        private System.Windows.Forms.Button btnIptal;
    }
}