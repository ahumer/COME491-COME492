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
    public partial class directCal : Form
    {
        bool controlShowBtn = false;
        public directCal()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Form frm = this.FindForm();
            frm.Close();
        }

        private void directCalc_Load(object sender, EventArgs e)
        {
            lblVposition.Text = "";
            lblA.Visible = false;
            lblB.Visible = false;
            lblC.Visible = false;
            lblD.Visible = false;
            lblE.Visible = false;
            lblF.Visible = false;
            lblG.Visible = false;
            lblH.Visible = false;
            lblJ.Visible = false;
        }

       
        private void btnShow_Click(object sender, EventArgs e)
        {
            if (controlShowBtn == false)
            {
                this.Text = "Hide IDs";
                controlShowBtn = true;
                lblA.Visible = true;
                lblB.Visible = true;
                lblC.Visible = true;
                lblD.Visible = true;
                lblE.Visible = true;
                lblF.Visible = true;
                lblG.Visible = true;
                lblH.Visible = true;
                lblJ.Visible = true;
            }
            else
            {
                this.Text = "Show IDs";
                controlShowBtn = false;
                lblA.Visible = false;
                lblB.Visible = false;
                lblC.Visible = false;
                lblD.Visible = false;
                lblE.Visible = false;
                lblF.Visible = false;
                lblG.Visible = false;
                lblH.Visible = false;
                lblJ.Visible = false;
            }
            
        }

        private void tbID1_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                //textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            }
        }

        private void rbVehicle_Click(object sender, EventArgs e)
        {
            btnCalc.Enabled = true;
        }

        private void rbCardID_Click(object sender, EventArgs e)
        {
            tbID1.Enabled = true;
            tbID2.Enabled = true;
            tbID3.Enabled = true;
            tbID4.Enabled = true;
        }
    }
}
