namespace Central_Management
{
    partial class systemInfo
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
            this.components = new System.ComponentModel.Container();
            this.lblProduct = new System.Windows.Forms.Label();
            this.lblColor = new System.Windows.Forms.Label();
            this.lblProcess = new System.Windows.Forms.Label();
            this.lblLastProduct = new System.Windows.Forms.Label();
            this.gbHeader = new System.Windows.Forms.GroupBox();
            this.gbInfo = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblClolorInfo = new System.Windows.Forms.Label();
            this.lblPlacing = new System.Windows.Forms.Label();
            this.lblPReading = new System.Windows.Forms.Label();
            this.lblPWaiting = new System.Windows.Forms.Label();
            this.lblBlue = new System.Windows.Forms.Label();
            this.lblGreen = new System.Windows.Forms.Label();
            this.lblRed = new System.Windows.Forms.Label();
            this.lblSlash = new System.Windows.Forms.Label();
            this.lblSlash3 = new System.Windows.Forms.Label();
            this.lblSlash4 = new System.Windows.Forms.Label();
            this.lblSlash5 = new System.Windows.Forms.Label();
            this.lblSlash6 = new System.Windows.Forms.Label();
            this.lblSlash1 = new System.Windows.Forms.Label();
            this.lblCNot = new System.Windows.Forms.Label();
            this.lblDtc = new System.Windows.Forms.Label();
            this.lblNot = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.gbHeader.SuspendLayout();
            this.gbInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblProduct.Location = new System.Drawing.Point(12, 32);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(75, 13);
            this.lblProduct.TabIndex = 0;
            this.lblProduct.Text = "PRODUCT: ";
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblColor.Location = new System.Drawing.Point(12, 86);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(57, 13);
            this.lblColor.TabIndex = 1;
            this.lblColor.Text = "COLOR: ";
            // 
            // lblProcess
            // 
            this.lblProcess.AutoSize = true;
            this.lblProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblProcess.Location = new System.Drawing.Point(12, 151);
            this.lblProcess.Name = "lblProcess";
            this.lblProcess.Size = new System.Drawing.Size(73, 13);
            this.lblProcess.TabIndex = 2;
            this.lblProcess.Text = "PROCESS: ";
            // 
            // lblLastProduct
            // 
            this.lblLastProduct.AutoSize = true;
            this.lblLastProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblLastProduct.Location = new System.Drawing.Point(12, 219);
            this.lblLastProduct.Name = "lblLastProduct";
            this.lblLastProduct.Size = new System.Drawing.Size(110, 17);
            this.lblLastProduct.TabIndex = 3;
            this.lblLastProduct.Text = "Last Product: ";
            // 
            // gbHeader
            // 
            this.gbHeader.Controls.Add(this.lblProduct);
            this.gbHeader.Controls.Add(this.lblLastProduct);
            this.gbHeader.Controls.Add(this.lblColor);
            this.gbHeader.Controls.Add(this.lblProcess);
            this.gbHeader.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbHeader.Location = new System.Drawing.Point(0, 0);
            this.gbHeader.Name = "gbHeader";
            this.gbHeader.Size = new System.Drawing.Size(115, 276);
            this.gbHeader.TabIndex = 4;
            this.gbHeader.TabStop = false;
            // 
            // gbInfo
            // 
            this.gbInfo.Controls.Add(this.btnClose);
            this.gbInfo.Controls.Add(this.lblClolorInfo);
            this.gbInfo.Controls.Add(this.lblPlacing);
            this.gbInfo.Controls.Add(this.lblPReading);
            this.gbInfo.Controls.Add(this.lblPWaiting);
            this.gbInfo.Controls.Add(this.lblBlue);
            this.gbInfo.Controls.Add(this.lblGreen);
            this.gbInfo.Controls.Add(this.lblRed);
            this.gbInfo.Controls.Add(this.lblSlash);
            this.gbInfo.Controls.Add(this.lblSlash3);
            this.gbInfo.Controls.Add(this.lblSlash4);
            this.gbInfo.Controls.Add(this.lblSlash5);
            this.gbInfo.Controls.Add(this.lblSlash6);
            this.gbInfo.Controls.Add(this.lblSlash1);
            this.gbInfo.Controls.Add(this.lblCNot);
            this.gbInfo.Controls.Add(this.lblDtc);
            this.gbInfo.Controls.Add(this.lblNot);
            this.gbInfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.gbInfo.Location = new System.Drawing.Point(121, 0);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Size = new System.Drawing.Size(333, 276);
            this.gbInfo.TabIndex = 5;
            this.gbInfo.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(240, 219);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblClolorInfo
            // 
            this.lblClolorInfo.AutoSize = true;
            this.lblClolorInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblClolorInfo.Location = new System.Drawing.Point(6, 219);
            this.lblClolorInfo.Name = "lblClolorInfo";
            this.lblClolorInfo.Size = new System.Drawing.Size(78, 17);
            this.lblClolorInfo.TabIndex = 17;
            this.lblClolorInfo.Text = "Color Info";
            // 
            // lblPlacing
            // 
            this.lblPlacing.AutoSize = true;
            this.lblPlacing.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblPlacing.Location = new System.Drawing.Point(237, 149);
            this.lblPlacing.Name = "lblPlacing";
            this.lblPlacing.Size = new System.Drawing.Size(54, 17);
            this.lblPlacing.TabIndex = 16;
            this.lblPlacing.Text = "Placing";
            // 
            // lblPReading
            // 
            this.lblPReading.AutoSize = true;
            this.lblPReading.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblPReading.Location = new System.Drawing.Point(131, 148);
            this.lblPReading.Name = "lblPReading";
            this.lblPReading.Size = new System.Drawing.Size(61, 17);
            this.lblPReading.TabIndex = 15;
            this.lblPReading.Text = "Reading";
            // 
            // lblPWaiting
            // 
            this.lblPWaiting.AutoSize = true;
            this.lblPWaiting.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblPWaiting.Location = new System.Drawing.Point(36, 148);
            this.lblPWaiting.Name = "lblPWaiting";
            this.lblPWaiting.Size = new System.Drawing.Size(55, 17);
            this.lblPWaiting.TabIndex = 14;
            this.lblPWaiting.Text = "Waiting";
            // 
            // lblBlue
            // 
            this.lblBlue.AutoSize = true;
            this.lblBlue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblBlue.Location = new System.Drawing.Point(281, 84);
            this.lblBlue.Name = "lblBlue";
            this.lblBlue.Size = new System.Drawing.Size(36, 17);
            this.lblBlue.TabIndex = 13;
            this.lblBlue.Text = "Blue";
            // 
            // lblGreen
            // 
            this.lblGreen.AutoSize = true;
            this.lblGreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblGreen.Location = new System.Drawing.Point(202, 84);
            this.lblGreen.Name = "lblGreen";
            this.lblGreen.Size = new System.Drawing.Size(48, 17);
            this.lblGreen.TabIndex = 12;
            this.lblGreen.Text = "Green";
            // 
            // lblRed
            // 
            this.lblRed.AutoSize = true;
            this.lblRed.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblRed.Location = new System.Drawing.Point(121, 84);
            this.lblRed.Name = "lblRed";
            this.lblRed.Size = new System.Drawing.Size(34, 17);
            this.lblRed.TabIndex = 11;
            this.lblRed.Text = "Red";
            // 
            // lblSlash
            // 
            this.lblSlash.AutoSize = true;
            this.lblSlash.Location = new System.Drawing.Point(153, 32);
            this.lblSlash.Name = "lblSlash";
            this.lblSlash.Size = new System.Drawing.Size(18, 13);
            this.lblSlash.TabIndex = 10;
            this.lblSlash.Text = " / ";
            // 
            // lblSlash3
            // 
            this.lblSlash3.AutoSize = true;
            this.lblSlash3.Location = new System.Drawing.Point(96, 86);
            this.lblSlash3.Name = "lblSlash3";
            this.lblSlash3.Size = new System.Drawing.Size(18, 13);
            this.lblSlash3.TabIndex = 9;
            this.lblSlash3.Text = " / ";
            // 
            // lblSlash4
            // 
            this.lblSlash4.AutoSize = true;
            this.lblSlash4.Location = new System.Drawing.Point(164, 86);
            this.lblSlash4.Name = "lblSlash4";
            this.lblSlash4.Size = new System.Drawing.Size(18, 13);
            this.lblSlash4.TabIndex = 8;
            this.lblSlash4.Text = " / ";
            // 
            // lblSlash5
            // 
            this.lblSlash5.AutoSize = true;
            this.lblSlash5.Location = new System.Drawing.Point(253, 86);
            this.lblSlash5.Name = "lblSlash5";
            this.lblSlash5.Size = new System.Drawing.Size(18, 13);
            this.lblSlash5.TabIndex = 7;
            this.lblSlash5.Text = " / ";
            // 
            // lblSlash6
            // 
            this.lblSlash6.AutoSize = true;
            this.lblSlash6.Location = new System.Drawing.Point(103, 150);
            this.lblSlash6.Name = "lblSlash6";
            this.lblSlash6.Size = new System.Drawing.Size(18, 13);
            this.lblSlash6.TabIndex = 6;
            this.lblSlash6.Text = " / ";
            // 
            // lblSlash1
            // 
            this.lblSlash1.AutoSize = true;
            this.lblSlash1.Location = new System.Drawing.Point(210, 150);
            this.lblSlash1.Name = "lblSlash1";
            this.lblSlash1.Size = new System.Drawing.Size(18, 13);
            this.lblSlash1.TabIndex = 5;
            this.lblSlash1.Text = " / ";
            // 
            // lblCNot
            // 
            this.lblCNot.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblCNot.Location = new System.Drawing.Point(6, 84);
            this.lblCNot.Name = "lblCNot";
            this.lblCNot.Size = new System.Drawing.Size(89, 19);
            this.lblCNot.TabIndex = 0;
            this.lblCNot.Text = "Not detected";
            // 
            // lblDtc
            // 
            this.lblDtc.AutoSize = true;
            this.lblDtc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblDtc.Location = new System.Drawing.Point(194, 30);
            this.lblDtc.Name = "lblDtc";
            this.lblDtc.Size = new System.Drawing.Size(65, 17);
            this.lblDtc.TabIndex = 2;
            this.lblDtc.Text = "Detected";
            // 
            // lblNot
            // 
            this.lblNot.AutoSize = true;
            this.lblNot.BackColor = System.Drawing.SystemColors.Control;
            this.lblNot.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblNot.Location = new System.Drawing.Point(51, 30);
            this.lblNot.Name = "lblNot";
            this.lblNot.Size = new System.Drawing.Size(89, 17);
            this.lblNot.TabIndex = 0;
            this.lblNot.Text = "Not detected";
            // 
            // timer1
            // 
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // systemInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(454, 276);
            this.ControlBox = false;
            this.Controls.Add(this.gbInfo);
            this.Controls.Add(this.gbHeader);
            this.Enabled = false;
            this.Name = "systemInfo";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "System Info";
            this.Load += new System.EventHandler(this.systemInfo_Load);
            this.Shown += new System.EventHandler(this.systemInfo_Shown);
            this.gbHeader.ResumeLayout(false);
            this.gbHeader.PerformLayout();
            this.gbInfo.ResumeLayout(false);
            this.gbInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.Label lblProcess;
        private System.Windows.Forms.Label lblLastProduct;
        private System.Windows.Forms.GroupBox gbHeader;
        private System.Windows.Forms.GroupBox gbInfo;
        private System.Windows.Forms.Label lblClolorInfo;
        private System.Windows.Forms.Label lblPlacing;
        private System.Windows.Forms.Label lblPReading;
        private System.Windows.Forms.Label lblPWaiting;
        private System.Windows.Forms.Label lblBlue;
        private System.Windows.Forms.Label lblGreen;
        private System.Windows.Forms.Label lblRed;
        private System.Windows.Forms.Label lblSlash;
        private System.Windows.Forms.Label lblSlash3;
        private System.Windows.Forms.Label lblSlash4;
        private System.Windows.Forms.Label lblSlash5;
        private System.Windows.Forms.Label lblSlash6;
        private System.Windows.Forms.Label lblSlash1;
        private System.Windows.Forms.Label lblCNot;
        private System.Windows.Forms.Label lblDtc;
        private System.Windows.Forms.Label lblNot;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Timer timer1;
    }
}