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
            this.btnON = new System.Windows.Forms.Button();
            this.btnOFF = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.gbSys = new System.Windows.Forms.GroupBox();
            this.btnDirect = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblSys = new System.Windows.Forms.Label();
            this.lblSysHeader = new System.Windows.Forms.Label();
            this.btnSysInf = new System.Windows.Forms.Button();
            this.gbCon = new System.Windows.Forms.GroupBox();
            this.lblV = new System.Windows.Forms.Label();
            this.lblCntHeader = new System.Windows.Forms.Label();
            this.lblState = new System.Windows.Forms.Label();
            this.tbVPort = new System.Windows.Forms.TextBox();
            this.rtbSerial = new System.Windows.Forms.RichTextBox();
            this.timer1Main = new System.Windows.Forms.Timer(this.components);
            this.gbSerial = new System.Windows.Forms.GroupBox();
            this.timer2Main = new System.Windows.Forms.Timer(this.components);
            this.gbSys.SuspendLayout();
            this.gbCon.SuspendLayout();
            this.gbSerial.SuspendLayout();
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
            this.btnOpen.Location = new System.Drawing.Point(16, 79);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(16, 89);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Visible = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // gbSys
            // 
            this.gbSys.Controls.Add(this.btnDirect);
            this.gbSys.Controls.Add(this.btnClear);
            this.gbSys.Controls.Add(this.lblSys);
            this.gbSys.Controls.Add(this.lblSysHeader);
            this.gbSys.Controls.Add(this.btnSysInf);
            this.gbSys.Controls.Add(this.btnON);
            this.gbSys.Controls.Add(this.btnOFF);
            this.gbSys.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbSys.Location = new System.Drawing.Point(0, 0);
            this.gbSys.Margin = new System.Windows.Forms.Padding(2);
            this.gbSys.Name = "gbSys";
            this.gbSys.Padding = new System.Windows.Forms.Padding(2);
            this.gbSys.Size = new System.Drawing.Size(403, 150);
            this.gbSys.TabIndex = 8;
            this.gbSys.TabStop = false;
            this.gbSys.Text = "SYSTEM CONTROL";
            // 
            // btnDirect
            // 
            this.btnDirect.Location = new System.Drawing.Point(12, 98);
            this.btnDirect.Name = "btnDirect";
            this.btnDirect.Size = new System.Drawing.Size(88, 35);
            this.btnDirect.TabIndex = 13;
            this.btnDirect.Text = "Direction Settings";
            this.btnDirect.UseVisualStyleBackColor = true;
            this.btnDirect.Click += new System.EventHandler(this.btnDirect_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(313, 98);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(78, 35);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "Clear text";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
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
            // gbCon
            // 
            this.gbCon.Controls.Add(this.lblV);
            this.gbCon.Controls.Add(this.lblCntHeader);
            this.gbCon.Controls.Add(this.lblState);
            this.gbCon.Controls.Add(this.tbVPort);
            this.gbCon.Controls.Add(this.btnOpen);
            this.gbCon.Controls.Add(this.btnClose);
            this.gbCon.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbCon.Location = new System.Drawing.Point(0, 564);
            this.gbCon.Margin = new System.Windows.Forms.Padding(2);
            this.gbCon.Name = "gbCon";
            this.gbCon.Padding = new System.Windows.Forms.Padding(2);
            this.gbCon.Size = new System.Drawing.Size(403, 139);
            this.gbCon.TabIndex = 9;
            this.gbCon.TabStop = false;
            this.gbCon.Text = "CONNECTION CONTROL";
            // 
            // lblV
            // 
            this.lblV.AutoSize = true;
            this.lblV.Location = new System.Drawing.Point(12, 31);
            this.lblV.Name = "lblV";
            this.lblV.Size = new System.Drawing.Size(63, 13);
            this.lblV.TabIndex = 9;
            this.lblV.Text = "The vehicle";
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
            // tbVPort
            // 
            this.tbVPort.Location = new System.Drawing.Point(15, 54);
            this.tbVPort.Margin = new System.Windows.Forms.Padding(2);
            this.tbVPort.Name = "tbVPort";
            this.tbVPort.Size = new System.Drawing.Size(76, 20);
            this.tbVPort.TabIndex = 4;
            // 
            // rtbSerial
            // 
            this.rtbSerial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbSerial.Enabled = false;
            this.rtbSerial.Location = new System.Drawing.Point(3, 16);
            this.rtbSerial.Name = "rtbSerial";
            this.rtbSerial.ReadOnly = true;
            this.rtbSerial.Size = new System.Drawing.Size(397, 395);
            this.rtbSerial.TabIndex = 0;
            this.rtbSerial.Text = "";
            // 
            // timer1Main
            // 
            this.timer1Main.Tick += new System.EventHandler(this.timer1Main_Tick);
            // 
            // gbSerial
            // 
            this.gbSerial.Controls.Add(this.rtbSerial);
            this.gbSerial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbSerial.Location = new System.Drawing.Point(0, 150);
            this.gbSerial.Name = "gbSerial";
            this.gbSerial.Size = new System.Drawing.Size(403, 414);
            this.gbSerial.TabIndex = 10;
            this.gbSerial.TabStop = false;
            this.gbSerial.Text = "SERIAL VEHICLE";
            // 
            // timer2Main
            // 
            this.timer2Main.Tick += new System.EventHandler(this.timer2Main_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 703);
            this.Controls.Add(this.gbSerial);
            this.Controls.Add(this.gbCon);
            this.Controls.Add(this.gbSys);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbSys.ResumeLayout(false);
            this.gbSys.PerformLayout();
            this.gbCon.ResumeLayout(false);
            this.gbCon.PerformLayout();
            this.gbSerial.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnON;
        private System.Windows.Forms.Button btnOFF;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox gbSys;
        private System.Windows.Forms.GroupBox gbCon;
        private System.Windows.Forms.TextBox tbVPort;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Label lblSysHeader;
        private System.Windows.Forms.Button btnSysInf;
        private System.Windows.Forms.Label lblSys;
        private System.Windows.Forms.Label lblCntHeader;
        private System.Windows.Forms.Label lblV;
        private System.Windows.Forms.RichTextBox rtbSerial;
        private System.Windows.Forms.Timer timer1Main;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox gbSerial;
        private System.Windows.Forms.Timer timer2Main;
        private System.Windows.Forms.Button btnDirect;
    }
}

