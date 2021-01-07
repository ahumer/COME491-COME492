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
            this.btnON = new System.Windows.Forms.Button();
            this.btnOFF = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.sysGrBx = new System.Windows.Forms.GroupBox();
            this.lblSensor = new System.Windows.Forms.Label();
            this.lblRbt = new System.Windows.Forms.Label();
            this.lblSys = new System.Windows.Forms.Label();
            this.lblSysHeader = new System.Windows.Forms.Label();
            this.btnLctConf = new System.Windows.Forms.Button();
            this.btnSysInf = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblCntHeader = new System.Windows.Forms.Label();
            this.lblState = new System.Windows.Forms.Label();
            this.tbRPort = new System.Windows.Forms.Label();
            this.tbSPort = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblRP = new System.Windows.Forms.Label();
            this.lblSP = new System.Windows.Forms.Label();
            this.sysGrBx.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnON
            // 
            this.btnON.Enabled = false;
            this.btnON.Location = new System.Drawing.Point(10, 28);
            this.btnON.Name = "btnON";
            this.btnON.Size = new System.Drawing.Size(90, 23);
            this.btnON.TabIndex = 0;
            this.btnON.Text = "ON";
            this.btnON.UseVisualStyleBackColor = true;
            this.btnON.Click += new System.EventHandler(this.btnON_Click);
            // 
            // btnOFF
            // 
            this.btnOFF.Enabled = false;
            this.btnOFF.Location = new System.Drawing.Point(10, 12);
            this.btnOFF.Name = "btnOFF";
            this.btnOFF.Size = new System.Drawing.Size(90, 23);
            this.btnOFF.TabIndex = 1;
            this.btnOFF.Text = "OFF";
            this.btnOFF.UseVisualStyleBackColor = true;
            this.btnOFF.Visible = false;
            this.btnOFF.Click += new System.EventHandler(this.btnOFF_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(262, 88);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnClose
            // 
            this.btnClose.Enabled = false;
            this.btnClose.Location = new System.Drawing.Point(263, 98);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Visible = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // sysGrBx
            // 
            this.sysGrBx.Controls.Add(this.lblSensor);
            this.sysGrBx.Controls.Add(this.lblRbt);
            this.sysGrBx.Controls.Add(this.lblSys);
            this.sysGrBx.Controls.Add(this.lblSysHeader);
            this.sysGrBx.Controls.Add(this.btnLctConf);
            this.sysGrBx.Controls.Add(this.btnSysInf);
            this.sysGrBx.Controls.Add(this.btnON);
            this.sysGrBx.Controls.Add(this.btnOFF);
            this.sysGrBx.Dock = System.Windows.Forms.DockStyle.Top;
            this.sysGrBx.Location = new System.Drawing.Point(0, 0);
            this.sysGrBx.Margin = new System.Windows.Forms.Padding(2);
            this.sysGrBx.Name = "sysGrBx";
            this.sysGrBx.Padding = new System.Windows.Forms.Padding(2);
            this.sysGrBx.Size = new System.Drawing.Size(403, 150);
            this.sysGrBx.TabIndex = 8;
            this.sysGrBx.TabStop = false;
            this.sysGrBx.Text = "SYSTEM CONTROL";
            // 
            // lblSensor
            // 
            this.lblSensor.AutoSize = true;
            this.lblSensor.Location = new System.Drawing.Point(232, 109);
            this.lblSensor.Name = "lblSensor";
            this.lblSensor.Size = new System.Drawing.Size(120, 13);
            this.lblSensor.TabIndex = 12;
            this.lblSensor.Text = "Sensors: not connected";
            // 
            // lblRbt
            // 
            this.lblRbt.AutoSize = true;
            this.lblRbt.Location = new System.Drawing.Point(232, 83);
            this.lblRbt.Name = "lblRbt";
            this.lblRbt.Size = new System.Drawing.Size(131, 13);
            this.lblRbt.TabIndex = 11;
            this.lblRbt.Text = "Robot arm: not connected";
            // 
            // lblSys
            // 
            this.lblSys.AutoSize = true;
            this.lblSys.Location = new System.Drawing.Point(232, 57);
            this.lblSys.Name = "lblSys";
            this.lblSys.Size = new System.Drawing.Size(27, 13);
            this.lblSys.TabIndex = 10;
            this.lblSys.Text = "OFF";
            // 
            // lblSysHeader
            // 
            this.lblSysHeader.AutoSize = true;
            this.lblSysHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSysHeader.Location = new System.Drawing.Point(224, 15);
            this.lblSysHeader.Name = "lblSysHeader";
            this.lblSysHeader.Size = new System.Drawing.Size(113, 20);
            this.lblSysHeader.TabIndex = 9;
            this.lblSysHeader.Text = "System Status";
            // 
            // btnLctConf
            // 
            this.btnLctConf.Enabled = false;
            this.btnLctConf.Location = new System.Drawing.Point(10, 98);
            this.btnLctConf.Name = "btnLctConf";
            this.btnLctConf.Size = new System.Drawing.Size(90, 35);
            this.btnLctConf.TabIndex = 8;
            this.btnLctConf.Text = "Location Configuration";
            this.btnLctConf.UseVisualStyleBackColor = true;
            // 
            // btnSysInf
            // 
            this.btnSysInf.Enabled = false;
            this.btnSysInf.Location = new System.Drawing.Point(10, 57);
            this.btnSysInf.Name = "btnSysInf";
            this.btnSysInf.Size = new System.Drawing.Size(90, 23);
            this.btnSysInf.TabIndex = 7;
            this.btnSysInf.Text = "System Info";
            this.btnSysInf.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblSP);
            this.groupBox2.Controls.Add(this.lblRP);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.lblCntHeader);
            this.groupBox2.Controls.Add(this.lblState);
            this.groupBox2.Controls.Add(this.tbRPort);
            this.groupBox2.Controls.Add(this.tbSPort);
            this.groupBox2.Controls.Add(this.btnOpen);
            this.groupBox2.Controls.Add(this.btnClose);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 151);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(403, 136);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "CONNECTION CONTROL";
            // 
            // lblCntHeader
            // 
            this.lblCntHeader.AutoSize = true;
            this.lblCntHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCntHeader.Location = new System.Drawing.Point(224, 15);
            this.lblCntHeader.Name = "lblCntHeader";
            this.lblCntHeader.Size = new System.Drawing.Size(141, 20);
            this.lblCntHeader.TabIndex = 7;
            this.lblCntHeader.Text = "Connection Status";
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(232, 61);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(78, 13);
            this.lblState.TabIndex = 6;
            this.lblState.Text = "Not connected";
            // 
            // tbRPort
            // 
            this.tbRPort.AutoSize = true;
            this.tbRPort.Location = new System.Drawing.Point(11, 35);
            this.tbRPort.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.tbRPort.Name = "tbRPort";
            this.tbRPort.Size = new System.Drawing.Size(106, 13);
            this.tbRPort.TabIndex = 5;
            this.tbRPort.Text = "Enter the port name :";
            // 
            // tbSPort
            // 
            this.tbSPort.Location = new System.Drawing.Point(10, 88);
            this.tbSPort.Margin = new System.Windows.Forms.Padding(2);
            this.tbSPort.Name = "tbSPort";
            this.tbSPort.Size = new System.Drawing.Size(76, 20);
            this.tbSPort.TabIndex = 4;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(105, 88);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(76, 20);
            this.textBox1.TabIndex = 8;
            // 
            // lblRP
            // 
            this.lblRP.AutoSize = true;
            this.lblRP.Location = new System.Drawing.Point(12, 61);
            this.lblRP.Name = "lblRP";
            this.lblRP.Size = new System.Drawing.Size(57, 13);
            this.lblRP.TabIndex = 9;
            this.lblRP.Text = "Robot Arm";
            // 
            // lblSP
            // 
            this.lblSP.AutoSize = true;
            this.lblSP.Location = new System.Drawing.Point(102, 61);
            this.lblSP.Name = "lblSP";
            this.lblSP.Size = new System.Drawing.Size(45, 13);
            this.lblSP.TabIndex = 10;
            this.lblSP.Text = "Sensors";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 287);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.sysGrBx);
            this.Name = "Form1";
            this.Text = "Form1";
            this.sysGrBx.ResumeLayout(false);
            this.sysGrBx.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnON;
        private System.Windows.Forms.Button btnOFF;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox sysGrBx;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbSPort;
        private System.Windows.Forms.Label tbRPort;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Label lblSysHeader;
        private System.Windows.Forms.Button btnLctConf;
        private System.Windows.Forms.Button btnSysInf;
        private System.Windows.Forms.Label lblSys;
        private System.Windows.Forms.Label lblRbt;
        private System.Windows.Forms.Label lblCntHeader;
        private System.Windows.Forms.Label lblSensor;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblSP;
        private System.Windows.Forms.Label lblRP;
    }
}

