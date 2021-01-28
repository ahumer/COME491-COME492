using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Central_Management
{
    public partial class directCal : Form
    {
        
        bool controlShowBtn = false;
        string destination;
        int posVehicle = -1;
        int prePosVehicle = -1;
        
        string defaultText = "";
        string cardIDCopy;
        string preCardIDCopy;
        string  [] cardIDArrayCopy;
        public Form parent;
        int btnSendControl = 0;
        public directCal()
        {
            InitializeComponent();
        }

        private void directCalc_Load(object sender, EventArgs e)
        {
            cardIDCopy = cardIDreference.cardID.Trim();
            preCardIDCopy = cardIDreference.preCardID.Trim();
            cardIDArrayCopy = cardIDreference.CardIDArray;
            defaultText = rtbGraph.Text;
            timerCalc.Enabled = true;

            //Finding index in the card IDs array, for card ID of the current location of the vehicle 
            for (int i = 0; i < 9; i++)
            {
                if (cardIDArrayCopy[i] == cardIDCopy)
                {
                    posVehicle = i;
                    break;
                }
            }

            //Finding index in the card IDs array, for card ID of the previous location of the vehicle
            for (int i = 0; i < 9; i++)
            {
                if (cardIDArrayCopy[i] == preCardIDCopy)
                {
                    prePosVehicle = i;
                    break;
                }
            }

            //Writing the current position and the previous position information of the vehicle on the form, according to graph.
            if (posVehicle != -1)
            {
                lblVposition.Text = Utilities.alphabet[posVehicle];
            }
            else
            {
                lblVposition.Text = "";
            }
            
            if(prePosVehicle != -1)
            {
                lblVprePos.Text = Utilities.alphabet[prePosVehicle];
            }
            else
            {
                lblVprePos.Text = "";
            }

            lblVfacet.Text = "";
            lblA.Visible = false;
            lblB.Visible = false;
            lblC.Visible = false;
            lblD.Visible = false;
            lblE.Visible = false;
            lblF.Visible = false;
            lblG.Visible = false;
            lblH.Visible = false;
            lblJ.Visible = false;

            rbA.Checked = false;
            rbB.Checked = false;
            rbC.Checked = false;
            rbD.Checked = false;
            rbE.Checked = false;
            rbF.Checked = false;
            rbG.Checked = false;
            rbH.Checked = false;
            rbJ.Checked = false;

            //IDs of the locations are assigned to labels
            lblA.Text = cardIDArrayCopy[0];
            lblB.Text = cardIDArrayCopy[1];
            lblC.Text = cardIDArrayCopy[2];
            lblD.Text = cardIDArrayCopy[3];
            lblE.Text = cardIDArrayCopy[4];
            lblF.Text = cardIDArrayCopy[5];
            lblG.Text = cardIDArrayCopy[6];
            lblH.Text = cardIDArrayCopy[7];
            lblJ.Text = cardIDArrayCopy[8];

            //Coloring the current position of the vehicle on the graph
            if (posVehicle != -1)
            {
                Utilities.SelectRichText(rtbGraph, Utilities.alphabet[posVehicle].ToString());
                rtbGraph.SelectionColor = Color.DarkRed;
            }

        }

        private void rbA_CheckedChanged(object sender, EventArgs e)
        {
            if (rbA.Checked)
            {
                destination = lblA.Text;
                rbA.ForeColor = Color.Green;
                lblA.ForeColor = Color.Green;
            }
            else
            {
                lblA.ForeColor = Color.Black;
                rbA.ForeColor = Color.Black;
            }

        }

        private void rbB_CheckedChanged(object sender, EventArgs e)
        {
            if (rbB.Checked)
            {
                destination = lblB.Text;
                rbB.ForeColor = Color.Green;
                lblB.ForeColor = Color.Green;
            }
            else
            {
                lblB.ForeColor = Color.Black;
                rbB.ForeColor = Color.Black;
            }
        }

        private void rbC_CheckedChanged(object sender, EventArgs e)
        {
            if (rbC.Checked)
            {
                destination = lblC.Text;
                rbC.ForeColor = Color.Green;
                lblC.ForeColor = Color.Green;
            }
            else
            {
                lblC.ForeColor = Color.Black;
                rbC.ForeColor = Color.Black;
            }
        }

        private void rbD_CheckedChanged(object sender, EventArgs e)
        {
            if (rbD.Checked)
            {
                destination = lblD.Text;
                rbD.ForeColor = Color.Green;
                lblD.ForeColor = Color.Green;
            }
            else
            {
                lblD.ForeColor = Color.Black;
                rbD.ForeColor = Color.Black;
            }
        }

        private void rbE_CheckedChanged(object sender, EventArgs e)
        {
            if (rbE.Checked)
            {
                destination = lblE.Text;
                rbE.ForeColor = Color.Green;
                lblE.ForeColor = Color.Green;
            }
            else
            {
                lblE.ForeColor = Color.Black;
                rbE.ForeColor = Color.Black;
            }
        }

        private void rbF_CheckedChanged(object sender, EventArgs e)
        {
            if (rbF.Checked)
            {
                destination = lblF.Text;
                rbF.ForeColor = Color.Green;
                lblF.ForeColor = Color.Green;
            }
            else
            {
                lblF.ForeColor = Color.Black;
                rbF.ForeColor = Color.Black;
            }
        }
        private void rbG_CheckedChanged(object sender, EventArgs e)
        {

            if (rbG.Checked)
            {
                destination = lblG.Text;
                rbG.ForeColor = Color.Green;
                lblG.ForeColor = Color.Green;
            }
            else
            {
                lblG.ForeColor = Color.Black;
                rbG.ForeColor = Color.Black;
            }
        }

        private void rbH_CheckedChanged(object sender, EventArgs e)
        {
            if (rbH.Checked)
            {
                destination = lblH.Text;
                rbH.ForeColor = Color.Green;
                lblH.ForeColor = Color.Green;
            }
            else
            {
                lblH.ForeColor = Color.Black;
                rbH.ForeColor = Color.Black;
            }
        }

        private void rbJ_CheckedChanged(object sender, EventArgs e)
        {
            if (rbJ.Checked)
            {
                destination = lblJ.Text;
                rbJ.ForeColor = Color.Green;
                lblJ.ForeColor = Color.Green;
            }
            else
            {
                lblJ.ForeColor = Color.Black;
                rbJ.ForeColor = Color.Black;
            }
        }

        //Make visible or invisible the labels that has card ID information of the locaitons
        private void btnShow_Click(object sender, EventArgs e)
        {
            if (controlShowBtn == false)
            {
                btnShow.Text = "Hide IDs";
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
                btnShow.Text = "Show IDs";
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

        //Edit later
        private void tbID1_TextChanged(object sender, EventArgs e)
        {
            //if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "[^0-9]"))
            //{
            //    MessageBox.Show("Please enter only numbers.");
            //    textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            //}
        }

        private void rbVehicle_Click(object sender, EventArgs e)
        {
            btnCalc.Enabled = true;
            tbID1.Enabled = false;
            tbID2.Enabled = false;
            tbID3.Enabled = false;
            tbID4.Enabled = false;
            btnAssign.Enabled = true;
        }

        private void rbCardID_Click(object sender, EventArgs e)
        {
            tbID1.Enabled = true;
            tbID2.Enabled = true;
            tbID3.Enabled = true;
            tbID4.Enabled = true;
            btnAssign.Enabled = true;
            btnCalc.Enabled = false;
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            try
            {
                //The index in the card ID array for selected destination
                int posDestination = 0;
                for (int i = 0; i < 9; i++)
                {
                    if (cardIDArrayCopy[i] == destination)
                    {
                        posDestination = i;
                        break;
                    }
                }

                rtbPath.Text = Utilities.pathCalculation(posVehicle, posDestination, prePosVehicle, lblVfacet, rtbGraph);

                //Destination is colored on graph
                Utilities.SelectRichText(rtbGraph, Utilities.alphabet[posDestination].ToString());
                rtbGraph.SelectionColor = Color.Green;

                btnCalc.Enabled = false;
                rbVehicle.Enabled = false;
                btnSend.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        
        private void btnReLoad_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
            directCal direction = new directCal();
            direction.cardIDArrayCopy = cardIDreference.CardIDArray;
            direction.cardIDCopy = cardIDreference.cardID;
            direction.preCardIDCopy = cardIDreference.preCardID;
            direction.parent = this.parent;
            direction.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            var frm = this.FindForm();
            timerCalc.Enabled = true;
            parent.Visible = true;
            frm.Close();
            
        }

        private void directCal_FormClosing(object sender, FormClosingEventArgs e)
        {
            parent.Enabled = true;
            e.Cancel = false;
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            btnSend.Enabled = false;
            string message = "";
            try
            {
                if (btnSendControl == 0)
                {
                    string[] subDirectionsArray;
                    subDirectionsArray = Utilities.directionForVehicle.ToString().Split('@');
                    Utilities.directionForVehicle = ""; //Prevent conflict with next calculation

                    if (subDirectionsArray[1].ToString() != "null")
                    {
                        Utilities.subDirectionCash = subDirectionsArray[1].ToString();
                        rtbProcess.Text += "First ";
                        message = communication.sendingDirections(subDirectionsArray[0].ToString(), rtbProcess, true);

                        if (message != "fail")
                        {
                            //rtbProcess.Text += "Wait for 'Send' button being enabled for second path sending.\n";
                            btnSendControl = 1;
                        }
                        else
                        {
                            MessageBox.Show("Control the vehicle!");
                            Utilities.subDirectionCash = ""; //Prevent conflict with next calculation
                        }    
                    }
                    else
                    {
                        rtbProcess.Text += "The ";
                        message = communication.sendingDirections(subDirectionsArray[0].ToString(), rtbProcess, false);

                        if (message != "fail")
                        {
                            btnSendControl = 3;
                        }
                        else
                        {
                            MessageBox.Show("Control the vehicle!");
                        }
                    }
                    
                }
                else if(btnSendControl == 2)
                {
                    btnSendControl = 3;
                    rtbProcess.Text += "Second ";
                    message = communication.sendingDirections(Utilities.subDirectionCash, rtbProcess, false);
                    if (message != "fail")
                    {
                        
                    }
                    else
                    {
                        MessageBox.Show("Control the vehicle!");
                    }
                    Utilities.subDirectionCash = ""; //Prevent conflict with next calculation
                }
    
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           
            
        }

        private void timerCalc_Tick(object sender, EventArgs e)
        {

            string buffer;
            string preText = communication.serialText;
            buffer = communication.readingSerialTimer();
            if (buffer != "")
            {
                buffer += "\n" + preText;
                communication.serialText = buffer;
            }
            if (btnSendControl == 1)
            {
                if(cardIDreference.CardIDArray[communication.index].ToString() == cardIDreference.cardID.ToString())
                {
                    rtbProcess.Text += "The vehicle arrived to mid-stop.\n";
                    btnSend.Enabled = true;
                    btnSendControl = 2;
                    btnSend_Click(timerCalc, e);
                }
            }
            if(btnSendControl == 3)
            {
                if (cardIDreference.CardIDArray[communication.index].ToString() == cardIDreference.cardID.ToString())
                {
                    rtbProcess.Text += "The vehicle arrived to the destination.";
                    btnSendControl = 0;
                }
            }
        }
    }
}
