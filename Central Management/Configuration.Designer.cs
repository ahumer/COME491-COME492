namespace Central_Management
{
    partial class Configuration
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
            this.gbConfLsit = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblConfList = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbLocation = new System.Windows.Forms.GroupBox();
            this.lblR = new System.Windows.Forms.Label();
            this.lblG = new System.Windows.Forms.Label();
            this.lblB = new System.Windows.Forms.Label();
            this.lblRLctn = new System.Windows.Forms.Label();
            this.lblGLctn = new System.Windows.Forms.Label();
            this.lblBLctn = new System.Windows.Forms.Label();
            this.gbProduct = new System.Windows.Forms.GroupBox();
            this.rbLctn1 = new System.Windows.Forms.RadioButton();
            this.lbLctn2 = new System.Windows.Forms.RadioButton();
            this.lbLctn3 = new System.Windows.Forms.RadioButton();
            this.rbR = new System.Windows.Forms.RadioButton();
            this.rbG = new System.Windows.Forms.RadioButton();
            this.rbB = new System.Windows.Forms.RadioButton();
            this.btnMatch = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.gbConfLsit.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbLocation.SuspendLayout();
            this.gbProduct.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbConfLsit
            // 
            this.gbConfLsit.Controls.Add(this.btnClose);
            this.gbConfLsit.Controls.Add(this.lblBLctn);
            this.gbConfLsit.Controls.Add(this.lblGLctn);
            this.gbConfLsit.Controls.Add(this.lblRLctn);
            this.gbConfLsit.Controls.Add(this.lblB);
            this.gbConfLsit.Controls.Add(this.lblG);
            this.gbConfLsit.Controls.Add(this.lblR);
            this.gbConfLsit.Controls.Add(this.lblConfList);
            this.gbConfLsit.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbConfLsit.Location = new System.Drawing.Point(0, 0);
            this.gbConfLsit.Name = "gbConfLsit";
            this.gbConfLsit.Size = new System.Drawing.Size(240, 284);
            this.gbConfLsit.TabIndex = 0;
            this.gbConfLsit.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnMatch);
            this.groupBox2.Controls.Add(this.gbProduct);
            this.groupBox2.Controls.Add(this.gbLocation);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox2.Location = new System.Drawing.Point(247, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(320, 284);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // lblConfList
            // 
            this.lblConfList.AutoSize = true;
            this.lblConfList.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfList.Location = new System.Drawing.Point(16, 20);
            this.lblConfList.Name = "lblConfList";
            this.lblConfList.Size = new System.Drawing.Size(150, 22);
            this.lblConfList.TabIndex = 0;
            this.lblConfList.Text = "Configuration List";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Match a location to a product";
            // 
            // gbLocation
            // 
            this.gbLocation.Controls.Add(this.lbLctn3);
            this.gbLocation.Controls.Add(this.lbLctn2);
            this.gbLocation.Controls.Add(this.rbLctn1);
            this.gbLocation.Location = new System.Drawing.Point(6, 61);
            this.gbLocation.Name = "gbLocation";
            this.gbLocation.Size = new System.Drawing.Size(127, 158);
            this.gbLocation.TabIndex = 1;
            this.gbLocation.TabStop = false;
            // 
            // lblR
            // 
            this.lblR.AutoSize = true;
            this.lblR.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblR.Location = new System.Drawing.Point(17, 78);
            this.lblR.Name = "lblR";
            this.lblR.Size = new System.Drawing.Size(86, 17);
            this.lblR.TabIndex = 1;
            this.lblR.Text = "Red product";
            // 
            // lblG
            // 
            this.lblG.AutoSize = true;
            this.lblG.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblG.Location = new System.Drawing.Point(17, 126);
            this.lblG.Name = "lblG";
            this.lblG.Size = new System.Drawing.Size(100, 17);
            this.lblG.TabIndex = 2;
            this.lblG.Text = "Green product";
            // 
            // lblB
            // 
            this.lblB.AutoSize = true;
            this.lblB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblB.Location = new System.Drawing.Point(17, 178);
            this.lblB.Name = "lblB";
            this.lblB.Size = new System.Drawing.Size(88, 17);
            this.lblB.TabIndex = 3;
            this.lblB.Text = "Blue product";
            // 
            // lblRLctn
            // 
            this.lblRLctn.AutoSize = true;
            this.lblRLctn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRLctn.Location = new System.Drawing.Point(139, 78);
            this.lblRLctn.Name = "lblRLctn";
            this.lblRLctn.Size = new System.Drawing.Size(74, 17);
            this.lblRLctn.TabIndex = 4;
            this.lblRLctn.Text = "Location 1";
            // 
            // lblGLctn
            // 
            this.lblGLctn.AutoSize = true;
            this.lblGLctn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGLctn.Location = new System.Drawing.Point(139, 126);
            this.lblGLctn.Name = "lblGLctn";
            this.lblGLctn.Size = new System.Drawing.Size(74, 17);
            this.lblGLctn.TabIndex = 5;
            this.lblGLctn.Text = "Location 2";
            // 
            // lblBLctn
            // 
            this.lblBLctn.AutoSize = true;
            this.lblBLctn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBLctn.Location = new System.Drawing.Point(139, 178);
            this.lblBLctn.Name = "lblBLctn";
            this.lblBLctn.Size = new System.Drawing.Size(74, 17);
            this.lblBLctn.TabIndex = 6;
            this.lblBLctn.Text = "Location 3";
            // 
            // gbProduct
            // 
            this.gbProduct.Controls.Add(this.rbB);
            this.gbProduct.Controls.Add(this.rbG);
            this.gbProduct.Controls.Add(this.rbR);
            this.gbProduct.Location = new System.Drawing.Point(180, 61);
            this.gbProduct.Name = "gbProduct";
            this.gbProduct.Size = new System.Drawing.Size(129, 158);
            this.gbProduct.TabIndex = 2;
            this.gbProduct.TabStop = false;
            // 
            // rbLctn1
            // 
            this.rbLctn1.AutoSize = true;
            this.rbLctn1.Location = new System.Drawing.Point(19, 9);
            this.rbLctn1.Name = "rbLctn1";
            this.rbLctn1.Size = new System.Drawing.Size(75, 17);
            this.rbLctn1.TabIndex = 1;
            this.rbLctn1.TabStop = true;
            this.rbLctn1.Text = "Location 1";
            this.rbLctn1.UseVisualStyleBackColor = true;
            // 
            // lbLctn2
            // 
            this.lbLctn2.AutoSize = true;
            this.lbLctn2.Location = new System.Drawing.Point(19, 75);
            this.lbLctn2.Name = "lbLctn2";
            this.lbLctn2.Size = new System.Drawing.Size(75, 17);
            this.lbLctn2.TabIndex = 2;
            this.lbLctn2.TabStop = true;
            this.lbLctn2.Text = "Location 2";
            this.lbLctn2.UseVisualStyleBackColor = true;
            // 
            // lbLctn3
            // 
            this.lbLctn3.AutoSize = true;
            this.lbLctn3.Location = new System.Drawing.Point(19, 135);
            this.lbLctn3.Name = "lbLctn3";
            this.lbLctn3.Size = new System.Drawing.Size(75, 17);
            this.lbLctn3.TabIndex = 3;
            this.lbLctn3.TabStop = true;
            this.lbLctn3.Text = "Location 3";
            this.lbLctn3.UseVisualStyleBackColor = true;
            // 
            // rbR
            // 
            this.rbR.AutoSize = true;
            this.rbR.Location = new System.Drawing.Point(25, 9);
            this.rbR.Name = "rbR";
            this.rbR.Size = new System.Drawing.Size(84, 17);
            this.rbR.TabIndex = 3;
            this.rbR.TabStop = true;
            this.rbR.Text = "Red product";
            this.rbR.UseVisualStyleBackColor = true;
            // 
            // rbG
            // 
            this.rbG.AutoSize = true;
            this.rbG.Location = new System.Drawing.Point(24, 75);
            this.rbG.Name = "rbG";
            this.rbG.Size = new System.Drawing.Size(93, 17);
            this.rbG.TabIndex = 4;
            this.rbG.TabStop = true;
            this.rbG.Text = "Green product";
            this.rbG.UseVisualStyleBackColor = true;
            // 
            // rbB
            // 
            this.rbB.AutoSize = true;
            this.rbB.Location = new System.Drawing.Point(24, 135);
            this.rbB.Name = "rbB";
            this.rbB.Size = new System.Drawing.Size(85, 17);
            this.rbB.TabIndex = 5;
            this.rbB.TabStop = true;
            this.rbB.Text = "Blue product";
            this.rbB.UseVisualStyleBackColor = true;
            // 
            // btnMatch
            // 
            this.btnMatch.Location = new System.Drawing.Point(233, 235);
            this.btnMatch.Name = "btnMatch";
            this.btnMatch.Size = new System.Drawing.Size(75, 23);
            this.btnMatch.TabIndex = 3;
            this.btnMatch.Text = "Match";
            this.btnMatch.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(142, 235);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // Configuration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 284);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbConfLsit);
            this.Name = "Configuration";
            this.Text = "Configuration";
            this.gbConfLsit.ResumeLayout(false);
            this.gbConfLsit.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbLocation.ResumeLayout(false);
            this.gbLocation.PerformLayout();
            this.gbProduct.ResumeLayout(false);
            this.gbProduct.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbConfLsit;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblBLctn;
        private System.Windows.Forms.Label lblGLctn;
        private System.Windows.Forms.Label lblRLctn;
        private System.Windows.Forms.Label lblB;
        private System.Windows.Forms.Label lblG;
        private System.Windows.Forms.Label lblR;
        private System.Windows.Forms.Label lblConfList;
        private System.Windows.Forms.GroupBox gbLocation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbProduct;
        private System.Windows.Forms.RadioButton rbB;
        private System.Windows.Forms.RadioButton rbG;
        private System.Windows.Forms.RadioButton rbR;
        private System.Windows.Forms.RadioButton lbLctn3;
        private System.Windows.Forms.RadioButton lbLctn2;
        private System.Windows.Forms.RadioButton rbLctn1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMatch;
    }
}