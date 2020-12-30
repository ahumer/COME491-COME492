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
            this.sysGrBx = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblState = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PortTB = new System.Windows.Forms.TextBox();
            this.sysInf = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblSysHeader = new System.Windows.Forms.Label();
            this.lblSys = new System.Windows.Forms.Label();
            this.lblRbt = new System.Windows.Forms.Label();
            this.lblSensor = new System.Windows.Forms.Label();
            this.lblCntHeader = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sysGrBx.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ONbtn
            // 
            this.ONbtn.Enabled = false;
            this.ONbtn.Location = new System.Drawing.Point(10, 28);
            this.ONbtn.Name = "ONbtn";
            this.ONbtn.Size = new System.Drawing.Size(90, 23);
            this.ONbtn.TabIndex = 0;
            this.ONbtn.Text = "ON";
            this.ONbtn.UseVisualStyleBackColor = true;
            this.ONbtn.Click += new System.EventHandler(this.ONbtn_Click);
            // 
            // OFFbtn
            // 
            this.OFFbtn.Enabled = false;
            this.OFFbtn.Location = new System.Drawing.Point(10, 12);
            this.OFFbtn.Name = "OFFbtn";
            this.OFFbtn.Size = new System.Drawing.Size(90, 23);
            this.OFFbtn.TabIndex = 1;
            this.OFFbtn.Text = "OFF";
            this.OFFbtn.UseVisualStyleBackColor = true;
            this.OFFbtn.Click += new System.EventHandler(this.OFFbtn_Click);
            // 
            // OPENbtn
            // 
            this.OPENbtn.Location = new System.Drawing.Point(10, 108);
            this.OPENbtn.Name = "OPENbtn";
            this.OPENbtn.Size = new System.Drawing.Size(75, 23);
            this.OPENbtn.TabIndex = 2;
            this.OPENbtn.Text = "Open";
            this.OPENbtn.UseVisualStyleBackColor = true;
            this.OPENbtn.Click += new System.EventHandler(this.OPENbtn_Click);
            // 
            // CLOSEbtn
            // 
            this.CLOSEbtn.Enabled = false;
            this.CLOSEbtn.Location = new System.Drawing.Point(10, 126);
            this.CLOSEbtn.Name = "CLOSEbtn";
            this.CLOSEbtn.Size = new System.Drawing.Size(75, 23);
            this.CLOSEbtn.TabIndex = 3;
            this.CLOSEbtn.Text = "Close";
            this.CLOSEbtn.UseVisualStyleBackColor = true;
            this.CLOSEbtn.Click += new System.EventHandler(this.CLOSEbtn_Click);
            // 
            // sysGrBx
            // 
            this.sysGrBx.Controls.Add(this.label2);
            this.sysGrBx.Controls.Add(this.lblSensor);
            this.sysGrBx.Controls.Add(this.lblRbt);
            this.sysGrBx.Controls.Add(this.lblSys);
            this.sysGrBx.Controls.Add(this.lblSysHeader);
            this.sysGrBx.Controls.Add(this.button1);
            this.sysGrBx.Controls.Add(this.sysInf);
            this.sysGrBx.Controls.Add(this.ONbtn);
            this.sysGrBx.Controls.Add(this.OFFbtn);
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblCntHeader);
            this.groupBox2.Controls.Add(this.lblState);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.PortTB);
            this.groupBox2.Controls.Add(this.OPENbtn);
            this.groupBox2.Controls.Add(this.CLOSEbtn);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 154);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(403, 172);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "CONNECTION CONTROL";
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(253, 70);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(78, 13);
            this.lblState.TabIndex = 6;
            this.lblState.Text = "Not connected";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Enter the port name :";
            // 
            // PortTB
            // 
            this.PortTB.Location = new System.Drawing.Point(10, 70);
            this.PortTB.Margin = new System.Windows.Forms.Padding(2);
            this.PortTB.Name = "PortTB";
            this.PortTB.Size = new System.Drawing.Size(76, 20);
            this.PortTB.TabIndex = 4;
            // 
            // sysInf
            // 
            this.sysInf.Location = new System.Drawing.Point(10, 57);
            this.sysInf.Name = "sysInf";
            this.sysInf.Size = new System.Drawing.Size(90, 23);
            this.sysInf.TabIndex = 7;
            this.sysInf.Text = "System Info";
            this.sysInf.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(10, 98);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 35);
            this.button1.TabIndex = 8;
            this.button1.Text = "Location Configuration";
            this.button1.UseVisualStyleBackColor = true;
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
            // lblSys
            // 
            this.lblSys.AutoSize = true;
            this.lblSys.Location = new System.Drawing.Point(232, 57);
            this.lblSys.Name = "lblSys";
            this.lblSys.Size = new System.Drawing.Size(27, 13);
            this.lblSys.TabIndex = 10;
            this.lblSys.Text = "OFF";
            // 
            // lblRbt
            // 
            this.lblRbt.AutoSize = true;
            this.lblRbt.Location = new System.Drawing.Point(232, 87);
            this.lblRbt.Name = "lblRbt";
            this.lblRbt.Size = new System.Drawing.Size(131, 13);
            this.lblRbt.TabIndex = 11;
            this.lblRbt.Text = "Robot arm: not connected";
            // 
            // lblSensor
            // 
            this.lblSensor.AutoSize = true;
            this.lblSensor.Location = new System.Drawing.Point(0, 0);
            this.lblSensor.Name = "lblSensor";
            this.lblSensor.Size = new System.Drawing.Size(0, 13);
            this.lblSensor.TabIndex = 12;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(232, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "label2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 326);
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

        private System.Windows.Forms.Button ONbtn;
        private System.Windows.Forms.Button OFFbtn;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button OPENbtn;
        private System.Windows.Forms.Button CLOSEbtn;
        private System.Windows.Forms.GroupBox sysGrBx;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox PortTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Label lblSysHeader;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button sysInf;
        private System.Windows.Forms.Label lblSys;
        private System.Windows.Forms.Label lblSensor;
        private System.Windows.Forms.Label lblRbt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCntHeader;
    }
}

