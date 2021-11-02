namespace MyNetwork
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnTekCift = new System.Windows.Forms.Button();
            this.x2Normalizasyonla = new System.Windows.Forms.Button();
            this.btnx5Normalizasyonla = new System.Windows.Forms.Button();
            this.btnXOR = new System.Windows.Forms.Button();
            this.btnTekCiftBinary = new System.Windows.Forms.Button();
            this.btnTekCiftDatasetOlustur = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 150);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Yeni Layer";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Input Layer",
            "Hidden Layer",
            "Output Layer"});
            this.comboBox2.Location = new System.Drawing.Point(82, 93);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(112, 21);
            this.comboBox2.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Önceki Layer";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(80, 40);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(54, 20);
            this.numericUpDown1.TabIndex = 6;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nöron Sayısı";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Input Layer",
            "Hidden Layer",
            "Output Layer"});
            this.comboBox1.Location = new System.Drawing.Point(34, 66);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(100, 21);
            this.comboBox1.TabIndex = 4;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(34, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tipi";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Adı";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(218, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(444, 524);
            this.listBox1.TabIndex = 1;
            this.listBox1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox1_DrawItem);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 498);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(201, 38);
            this.button1.TabIndex = 2;
            this.button1.Text = "Ağları yükle ve raporla";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnTekCift
            // 
            this.btnTekCift.Location = new System.Drawing.Point(12, 168);
            this.btnTekCift.Name = "btnTekCift";
            this.btnTekCift.Size = new System.Drawing.Size(201, 38);
            this.btnTekCift.TabIndex = 3;
            this.btnTekCift.Text = "Tek Çift";
            this.btnTekCift.UseVisualStyleBackColor = true;
            this.btnTekCift.Click += new System.EventHandler(this.btnTekCift_Click);
            // 
            // x2Normalizasyonla
            // 
            this.x2Normalizasyonla.Location = new System.Drawing.Point(11, 255);
            this.x2Normalizasyonla.Name = "x2Normalizasyonla";
            this.x2Normalizasyonla.Size = new System.Drawing.Size(201, 38);
            this.x2Normalizasyonla.TabIndex = 4;
            this.x2Normalizasyonla.Text = "x2 normalizasyonla";
            this.x2Normalizasyonla.UseVisualStyleBackColor = true;
            this.x2Normalizasyonla.Click += new System.EventHandler(this.x2Normalizasyonla_Click);
            // 
            // btnx5Normalizasyonla
            // 
            this.btnx5Normalizasyonla.Location = new System.Drawing.Point(11, 299);
            this.btnx5Normalizasyonla.Name = "btnx5Normalizasyonla";
            this.btnx5Normalizasyonla.Size = new System.Drawing.Size(201, 38);
            this.btnx5Normalizasyonla.TabIndex = 5;
            this.btnx5Normalizasyonla.Text = "x5 normalizasyonla";
            this.btnx5Normalizasyonla.UseVisualStyleBackColor = true;
            this.btnx5Normalizasyonla.Click += new System.EventHandler(this.btnx5Normalizasyonla_Click);
            // 
            // btnXOR
            // 
            this.btnXOR.Location = new System.Drawing.Point(11, 343);
            this.btnXOR.Name = "btnXOR";
            this.btnXOR.Size = new System.Drawing.Size(201, 38);
            this.btnXOR.TabIndex = 6;
            this.btnXOR.Text = "XOR";
            this.btnXOR.UseVisualStyleBackColor = true;
            this.btnXOR.Click += new System.EventHandler(this.btnXOR_Click);
            // 
            // btnTekCiftBinary
            // 
            this.btnTekCiftBinary.Location = new System.Drawing.Point(12, 212);
            this.btnTekCiftBinary.Name = "btnTekCiftBinary";
            this.btnTekCiftBinary.Size = new System.Drawing.Size(201, 38);
            this.btnTekCiftBinary.TabIndex = 7;
            this.btnTekCiftBinary.Text = "Tek Çift Binary Representation";
            this.btnTekCiftBinary.UseVisualStyleBackColor = true;
            this.btnTekCiftBinary.Click += new System.EventHandler(this.btnTekCiftBinary_Click);
            // 
            // btnTekCiftDatasetOlustur
            // 
            this.btnTekCiftDatasetOlustur.Location = new System.Drawing.Point(12, 454);
            this.btnTekCiftDatasetOlustur.Name = "btnTekCiftDatasetOlustur";
            this.btnTekCiftDatasetOlustur.Size = new System.Drawing.Size(201, 38);
            this.btnTekCiftDatasetOlustur.TabIndex = 8;
            this.btnTekCiftDatasetOlustur.Text = "Tek-Çift Dataset Oluştur";
            this.btnTekCiftDatasetOlustur.UseVisualStyleBackColor = true;
            this.btnTekCiftDatasetOlustur.Click += new System.EventHandler(this.btnTekCiftDatasetOlustur_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 544);
            this.Controls.Add(this.btnTekCiftDatasetOlustur);
            this.Controls.Add(this.btnTekCiftBinary);
            this.Controls.Add(this.btnXOR);
            this.Controls.Add(this.btnx5Normalizasyonla);
            this.Controls.Add(this.x2Normalizasyonla);
            this.Controls.Add(this.btnTekCift);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnTekCift;
        private System.Windows.Forms.Button x2Normalizasyonla;
        private System.Windows.Forms.Button btnx5Normalizasyonla;
        private System.Windows.Forms.Button btnXOR;
        private System.Windows.Forms.Button btnTekCiftBinary;
        private System.Windows.Forms.Button btnTekCiftDatasetOlustur;
    }
}

