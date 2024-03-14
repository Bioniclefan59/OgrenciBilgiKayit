
namespace OgrenciBilgiKayit
{
    partial class SinavSonucuKaydi
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
            this.txtOgrenciNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbSinav = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbDersKodu = new System.Windows.Forms.ComboBox();
            this.txtNot = new System.Windows.Forms.TextBox();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtOgrenciIsmi = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(389, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Öğrenci Numarası:";
            // 
            // txtOgrenciNo
            // 
            this.txtOgrenciNo.Location = new System.Drawing.Point(589, 33);
            this.txtOgrenciNo.Name = "txtOgrenciNo";
            this.txtOgrenciNo.Size = new System.Drawing.Size(121, 22);
            this.txtOgrenciNo.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(280, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ders Kodu:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(173, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 26);
            this.label3.TabIndex = 4;
            this.label3.Text = "Sınav:";
            // 
            // cmbSinav
            // 
            this.cmbSinav.FormattingEnabled = true;
            this.cmbSinav.Location = new System.Drawing.Point(252, 170);
            this.cmbSinav.Name = "cmbSinav";
            this.cmbSinav.Size = new System.Drawing.Size(121, 24);
            this.cmbSinav.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(459, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 26);
            this.label4.TabIndex = 6;
            this.label4.Text = "Not:";
            // 
            // cmbDersKodu
            // 
            this.cmbDersKodu.FormattingEnabled = true;
            this.cmbDersKodu.Location = new System.Drawing.Point(407, 102);
            this.cmbDersKodu.Name = "cmbDersKodu";
            this.cmbDersKodu.Size = new System.Drawing.Size(121, 24);
            this.cmbDersKodu.TabIndex = 7;
            // 
            // txtNot
            // 
            this.txtNot.Location = new System.Drawing.Point(517, 172);
            this.txtNot.Name = "txtNot";
            this.txtNot.Size = new System.Drawing.Size(121, 22);
            this.txtNot.TabIndex = 8;
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(345, 260);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(117, 33);
            this.btnKaydet.TabIndex = 9;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(91, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 26);
            this.label5.TabIndex = 10;
            this.label5.Text = "Öğrenci İsmi";
            // 
            // txtOgrenciIsmi
            // 
            this.txtOgrenciIsmi.Location = new System.Drawing.Point(232, 33);
            this.txtOgrenciIsmi.Name = "txtOgrenciIsmi";
            this.txtOgrenciIsmi.Size = new System.Drawing.Size(121, 22);
            this.txtOgrenciIsmi.TabIndex = 11;
            // 
            // SinavSonucuKaydi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtOgrenciIsmi);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.txtNot);
            this.Controls.Add(this.cmbDersKodu);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbSinav);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtOgrenciNo);
            this.Controls.Add(this.label1);
            this.Name = "SinavSonucuKaydi";
            this.Text = "SinavSonucuKaydi";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOgrenciNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbSinav;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbDersKodu;
        private System.Windows.Forms.TextBox txtNot;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtOgrenciIsmi;
    }
}