using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Central_Management
{
    public partial class systemInfo : Form
    {
        public systemData sysDataInf;
        public systemInfo()
        {
            InitializeComponent();
        }

        private void systemInfo_Load(object sender, EventArgs e)
        {
            dataShowing();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            var frm = this.FindForm();
            frm.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dataShowing();
        }

        private void systemInfo_Shown(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        void dataShowing()
        {
            if (sysDataInf.product == -1)
            {
                lblDtc.BackColor = SystemColors.Control;
                lblDtc.ForeColor = SystemColors.ControlText;
                lblNot.BackColor = SystemColors.Control;
                lblNot.ForeColor = SystemColors.ControlText;
            }
            if (sysDataInf.product == 0)
            {
                lblDtc.BackColor = SystemColors.Control;
                lblDtc.ForeColor = SystemColors.ControlText;
                lblNot.BackColor = SystemColors.ControlDark;
                lblNot.ForeColor = SystemColors.HighlightText;
            }
            if (sysDataInf.product == 1)
            {
                lblDtc.BackColor = SystemColors.ControlDark;
                lblDtc.ForeColor = SystemColors.HighlightText;
                lblNot.BackColor = SystemColors.Control;
                lblNot.ForeColor = SystemColors.ControlText;
            }
            if (sysDataInf.color == -1)
            {
                lblCNot.BackColor = SystemColors.Control;
                lblCNot.ForeColor = SystemColors.ControlText;
                lblRed.BackColor = SystemColors.Control;
                lblRed.ForeColor = SystemColors.ControlText;
                lblGreen.BackColor = SystemColors.Control;
                lblGreen.ForeColor = SystemColors.ControlText;
                lblBlue.BackColor = SystemColors.Control;
                lblBlue.ForeColor = SystemColors.ControlText;
            }
            if (sysDataInf.color == 0)
            {
                lblCNot.BackColor = SystemColors.ControlDark;
                lblCNot.ForeColor = SystemColors.HighlightText;
                lblRed.BackColor = SystemColors.Control;
                lblRed.ForeColor = SystemColors.ControlText;
                lblGreen.BackColor = SystemColors.Control;
                lblGreen.ForeColor = SystemColors.ControlText;
                lblBlue.BackColor = SystemColors.Control;
                lblBlue.ForeColor = SystemColors.ControlText;
            }
            if (sysDataInf.color == 1)
            {
                lblCNot.BackColor = SystemColors.Control;
                lblCNot.ForeColor = SystemColors.ControlText;
                lblRed.BackColor = Color.DarkRed;
                lblRed.ForeColor = SystemColors.HighlightText;
                lblGreen.BackColor = SystemColors.Control;
                lblGreen.ForeColor = SystemColors.ControlText;
                lblBlue.BackColor = SystemColors.Control;
                lblBlue.ForeColor = SystemColors.ControlText;
            }
            if (sysDataInf.color == 2)
            {
                lblCNot.BackColor = SystemColors.Control;
                lblCNot.ForeColor = SystemColors.ControlText;
                lblRed.BackColor = SystemColors.Control;
                lblRed.ForeColor = SystemColors.ControlText;
                lblGreen.BackColor = Color.DarkGreen;
                lblGreen.ForeColor = SystemColors.HighlightText;
                lblBlue.BackColor = SystemColors.Control;
                lblBlue.ForeColor = SystemColors.ControlText;
            }
            if (sysDataInf.color == 3)
            {
                lblCNot.BackColor = SystemColors.Control;
                lblCNot.ForeColor = SystemColors.ControlText;
                lblRed.BackColor = SystemColors.Control;
                lblRed.ForeColor = SystemColors.ControlText;
                lblGreen.BackColor = SystemColors.Control;
                lblGreen.ForeColor = SystemColors.ControlText;
                lblBlue.BackColor = Color.Blue;
                lblBlue.ForeColor = SystemColors.HighlightText;
            }
            if (sysDataInf.process == -1)
            {
                lblPWaiting.BackColor = SystemColors.Control;
                lblPWaiting.ForeColor = SystemColors.ControlText;
                lblPReading.BackColor = SystemColors.Control;
                lblPReading.ForeColor = SystemColors.ControlText;
                lblPlacing.BackColor = SystemColors.Control;
                lblPlacing.ForeColor = SystemColors.ControlText;
            }
            if (sysDataInf.process == 0)
            {
                lblPWaiting.BackColor = SystemColors.ControlDark;
                lblPWaiting.ForeColor = SystemColors.HighlightText;
                lblPReading.BackColor = SystemColors.Control;
                lblPReading.ForeColor = SystemColors.ControlText;
                lblPlacing.BackColor = SystemColors.Control;
                lblPlacing.ForeColor = SystemColors.ControlText;
            }
            if (sysDataInf.process == 1)
            {
                lblPWaiting.BackColor = SystemColors.Control;
                lblPWaiting.ForeColor = SystemColors.ControlText;
                lblPReading.BackColor = SystemColors.ControlDark;
                lblPReading.ForeColor = SystemColors.HighlightText;
                lblPlacing.BackColor = SystemColors.Control;
                lblPlacing.ForeColor = SystemColors.ControlText;
            }
            if (sysDataInf.process == 2)
            {
                lblPWaiting.BackColor = SystemColors.Control;
                lblPWaiting.ForeColor = SystemColors.ControlText;
                lblPReading.BackColor = SystemColors.Control;
                lblPReading.ForeColor = SystemColors.ControlText;
                lblPlacing.BackColor = SystemColors.ControlDark;
                lblPlacing.ForeColor = SystemColors.HighlightText;
            }

            if (sysDataInf.lastProduct == -1)
            {
                lblClolorInfo.BackColor = SystemColors.Control;
                lblClolorInfo.ForeColor = SystemColors.ControlText;
                lblClolorInfo.Text = "_";
            }
            if (sysDataInf.lastProduct == 0)
            {
                lblClolorInfo.BackColor = SystemColors.Control;
                lblClolorInfo.ForeColor = SystemColors.ControlText;
                lblClolorInfo.Text = "Not detected";
            }
            if (sysDataInf.lastProduct == 1)
            {
                lblClolorInfo.BackColor = SystemColors.Control;
                lblClolorInfo.ForeColor = Color.DarkRed;
                lblClolorInfo.Text = "Red";
            }
            if (sysDataInf.lastProduct == 2)
            {
                lblClolorInfo.BackColor = SystemColors.Control;
                lblClolorInfo.ForeColor = Color.DarkGreen;
                lblClolorInfo.Text = "Green";
            }
            if (sysDataInf.lastProduct == 3)
            {
                lblClolorInfo.BackColor = SystemColors.Control;
                lblClolorInfo.ForeColor = Color.DarkBlue;
                lblClolorInfo.Text = "Blue";
            }
        }
    }
}
