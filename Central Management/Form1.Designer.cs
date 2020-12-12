namespace Central_Management
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ONbtn = new System.Windows.Forms.Button();
            this.OFFbtn = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.OPENbtn = new System.Windows.Forms.Button();
            this.CLOSEbtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ONbtn
            // 
            this.ONbtn.Location = new System.Drawing.Point(14, 41);
            this.ONbtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ONbtn.Name = "ONbtn";
            this.ONbtn.Size = new System.Drawing.Size(100, 28);
            this.ONbtn.TabIndex = 0;
            this.ONbtn.Text = "ON";
            this.ONbtn.UseVisualStyleBackColor = true;
            this.ONbtn.Click += new System.EventHandler(this.ONbtn_Click);
            // 
            // OFFbtn
            // 
            this.OFFbtn.Location = new System.Drawing.Point(236, 41);
            this.OFFbtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.OFFbtn.Name = "OFFbtn";
            this.OFFbtn.Size = new System.Drawing.Size(100, 28);
            this.OFFbtn.TabIndex = 1;
            this.OFFbtn.Text = "OFF";
            this.OFFbtn.UseVisualStyleBackColor = true;
            this.OFFbtn.Click += new System.EventHandler(this.OFFbtn_Click);
            // 
            // OPENbtn
            // 
            this.OPENbtn.Location = new System.Drawing.Point(14, 55);
            this.OPENbtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.OPENbtn.Name = "OPENbtn";
            this.OPENbtn.Size = new System.Drawing.Size(100, 28);
            this.OPENbtn.TabIndex = 2;
            this.OPENbtn.Text = "Open";
            this.OPENbtn.UseVisualStyleBackColor = true;
            this.OPENbtn.Click += new System.EventHandler(this.OPENbtn_Click);
            // 
            // CLOSEbtn
            // 
            this.CLOSEbtn.Location = new System.Drawing.Point(236, 55);
            this.CLOSEbtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CLOSEbtn.Name = "CLOSEbtn";
            this.CLOSEbtn.Size = new System.Drawing.Size(100, 28);
            this.CLOSEbtn.TabIndex = 3;
            this.CLOSEbtn.Text = "Close";
            this.CLOSEbtn.UseVisualStyleBackColor = true;
            this.CLOSEbtn.Click += new System.EventHandler(this.CLOSEbtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ONbtn);
            this.groupBox1.Controls.Add(this.OFFbtn);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(349, 100);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "LED CONTROL";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.OPENbtn);
            this.groupBox2.Controls.Add(this.CLOSEbtn);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 104);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(349, 114);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "SERIAL CONTROL";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 218);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ONbtn;
        private System.Windows.Forms.Button OFFbtn;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button OPENbtn;
        private System.Windows.Forms.Button CLOSEbtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

