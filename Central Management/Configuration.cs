using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Central_Management
{
    public partial class Configuration : Form
    {
        public char[] preConfig;
        char r, g, b;
        public Configuration()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            var frm = this.FindForm();
            frm.Close();
        }

        private void rbR_CheckedChanged(object sender, EventArgs e)
        {
            rbLctn1.Enabled = true;
            rbLctn2.Enabled = true;
            rbLctn3.Enabled = true;
        }

        private void rbG_CheckedChanged(object sender, EventArgs e)
        {
            rbLctn1.Enabled = true;
            rbLctn2.Enabled = true;
            rbLctn3.Enabled = true;
        }

        private void rbB_CheckedChanged(object sender, EventArgs e)
        {
            rbLctn1.Enabled = true;
            rbLctn2.Enabled = true;
            rbLctn3.Enabled = true;
        }

        private void rbLctn1_CheckedChanged(object sender, EventArgs e)
        {
            btnMatch.Enabled = true;
        }

        private void rbLctn2_CheckedChanged(object sender, EventArgs e)
        {
            btnMatch.Enabled = true;
        }

        private void rbLctn3_CheckedChanged(object sender, EventArgs e)
        {
            btnMatch.Enabled = true;
        }

        private void Configuration_Load(object sender, EventArgs e)
        {
            char no;
            no = preConfig[0];
            lblRLctn.Text = "Location " + no;
            no = preConfig[1];
            lblGLctn.Text = "Location " + no;
            no = preConfig[2];
            lblBLctn.Text = "Location " + no;

        }

        private void btnMatch_Click(object sender, EventArgs e)
        {
            r = preConfig[0];

            g = preConfig[1];

            b = preConfig[2];

            if (rbR.Checked == true)
            {

                if (rbLctn1.Checked == true)
                {
                    lblRLctn.Text = "Location 1";
                    r = '1';
                }
                if (rbLctn2.Checked == true)
                {
                    lblRLctn.Text = "Location 2";
                    r = '2';
                }
                if (rbLctn3.Checked == true)
                {
                    lblRLctn.Text = "Location 3";
                    r = '3';
                }
                preConfig[0] = r;
            }

            if (rbG.Checked == true)
            {
                if (rbLctn1.Checked == true)
                {
                    lblGLctn.Text = "Location 1";
                    g = '1';
                }
                if (rbLctn2.Checked == true)
                {
                    lblGLctn.Text = "Location 2";
                    g = '2';
                }
                if (rbLctn3.Checked == true)
                {
                    lblGLctn.Text = "Location 3";
                    g = '3';
                }
                preConfig[1] = g;
            }

            if (rbB.Checked == true)
            {
                if (rbLctn1.Checked == true)
                {
                    lblBLctn.Text = "Location 1";
                    b = '1';
                }
                if (rbLctn2.Checked == true)
                {
                    lblBLctn.Text = "Location 2";
                    b = '2';
                }
                if (rbLctn3.Checked == true)
                {
                    lblBLctn.Text = "Location 3";
                    b = '3';
                }
                preConfig[2] = b;

            }

            rbLctn1.Checked = false;
            rbLctn2.Checked = false;
            rbLctn3.Checked = false;
            rbR.Checked = false;
            rbG.Checked = false;
            rbB.Checked = false;
            //"Enabled" values of Location radio buttons should be made false after "checked" values of R - G - B radio buttons made false.
            // Because R_G_B radio buttons "checked_changed" events make these values true.
            rbLctn1.Enabled = false;
            rbLctn2.Enabled = false;
            rbLctn3.Enabled = false;
            btnMatch.Enabled = false;
            btnSave.Enabled = true;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string filePath = @"configLocation.txt";
            string strConfig = new string(preConfig);
            File.WriteAllText(filePath, strConfig);
            btnSave.Enabled = false;
            MessageBox.Show("Saved!");
        }
    }
}
