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
        string destination;
        string vehicleFacet;
        int posVehicle = 0;
        int prePosVehicle = 0;
        string[] alphabet = { "A", "B", "C", "D", "E", "F", "G", "H", "J" };
        string defaultText;
        string cardIDCopy;
        string preCardIDCopy;
        string  [] cardIDArrayCopy;
        public Form parent;
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
            lblVposition.Text = alphabet[posVehicle];
            lblVprePos.Text = alphabet[prePosVehicle];

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
            SelectRichText(rtbGraph, alphabet[posVehicle].ToString());
            rtbGraph.SelectionColor = Color.DarkRed;
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

            rtbPath.Text = pathCalculation(posVehicle, posDestination,prePosVehicle);

            //Destination is colored on graph
            SelectRichText(rtbGraph, alphabet[posDestination].ToString());
            rtbGraph.SelectionColor = Color.Green;

            btnCalc.Enabled = false;
            rbVehicle.Enabled = false;
        }

        //Calculate the path from given current location to given destination
        private string pathCalculation(int indexL, int indexD, int indexPr)
        {
            int xL, xD, yL, yD, xPr, yPr;
            string directionPath = "";
            string arrowStart;

            //According to index of them, current location, destination and the previous location coordinates are calculated
            xL = indexL / 3;
            xD = indexD / 3;
            yL = indexL % 3;
            yD = indexD % 3;
            xPr = indexPr / 3;
            yPr = indexPr % 3;

            //Calculate which direction the vehicle is facing
            vehicleFacet = facetCalculation(xL, yL, xPr, yPr);
            lblVfacet .Text= vehicleFacet;

            if (vehicleFacet == "Invalid")
            {
                lblVfacet.ForeColor = Color.Black;
                directionPath += "move forward\n";
                directionPath += "Calculate again";
            }
            else
            {
                lblVfacet.ForeColor = Color.Orange;

                //Adding an arrow to the graph that indicates the direction the vehicle is facing
                arrowStart = arrowAdding(posVehicle);
             
                //According to the current location and the destination coordinates, calculating the path
                if (((xL < xD) || (xL > xD)) && ((yL < yD) || (yL > yD)))
                {
                    directionPath += oneDimensionPathCalc(vehicleFacet, xL, yL, xD, yL);
                    int tempPosVehicle = xD * 3 + yL;
                    arrowAdding(tempPosVehicle);
                    directionPath += oneDimensionPathCalc(vehicleFacet, xD, yL, xD, yD);
                }
                else
                {
                    directionPath += oneDimensionPathCalc(vehicleFacet, xL, yL, xD, yD);
                }
                SelectRichText(rtbGraph, arrowStart);
                rtbGraph.SelectionColor = Color.Orange;
                SelectRichText(rtbGraph, alphabet[posVehicle].ToString());
                rtbGraph.SelectionColor = Color.DarkRed;
            }  
            return directionPath;
        }

        //Calculate the facet of the vehicle according to given current location and previous location
        private string facetCalculation (int xLocation, int yLocation, int xPrevious, int yPrevious)
        {
            string facet = "Invalid";
            if (xLocation == xPrevious)
            {
                if ((yLocation - yPrevious)==-1)
                {
                    facet = "up";
                }
                else if((yLocation - yPrevious) == 1)
                {
                    facet = "down";
                }
            }
            if (yLocation == yPrevious)
            {
                if ((xLocation - xPrevious)==-1)
                {
                    facet = "left";
                }
                else if ((xLocation - xPrevious) == 1)
                {
                    facet = "right";
                }
            }

            return facet;
        }

        //Calculate the direction for given location and destination coordinates, only on same x coordinates or  on same y coordinates
        private string oneDimensionPathCalc(string facet, int xLocation, int yLocation, int xDestination, int yDestination)
        {
            string oneDimensionPath = "";
            int indexD = xDestination* 3 + yDestination;
            if (xLocation == xDestination)
            {
                if (yLocation < yDestination)
                {
                    if (facet == "down")
                    {
                        oneDimensionPath += "Vehicle points to down 🡻\n";
                        oneDimensionPath += "move forward ";
                        oneDimensionPath += "(down of user), ";
                        oneDimensionPath += " to ";
                        oneDimensionPath += alphabet[indexD];
                        oneDimensionPath += "\n";
                    }
                    else if (facet == "up")
                    {

                        oneDimensionPath += "Vehicle points to up 🡹\n";
                        oneDimensionPath += "turn back,";
                        oneDimensionPath += "move forward ";
                        oneDimensionPath += " to ";
                        oneDimensionPath += alphabet[indexD];
                        oneDimensionPath += "\n";
                    }
                    else if (facet == "left")
                    {
                    rtbGraph.SelectedText += "🡸";
                        oneDimensionPath += "Vehicle points to left 🡸\n";
                        oneDimensionPath += "turn left, ";
                        oneDimensionPath += "(down of user), ";
                        oneDimensionPath += "move forward ";
                        oneDimensionPath += " to ";
                        oneDimensionPath += alphabet[indexD];
                        oneDimensionPath += "\n";
                    }
                    else if (facet == "right")
                    {
                        oneDimensionPath += "Vehicle points to right 🡺\n";
                        oneDimensionPath += "turn right, ";
                        oneDimensionPath += "(down of user), ";
                        oneDimensionPath += "move forward ";
                        oneDimensionPath += " to ";
                        oneDimensionPath += alphabet[indexD];
                        oneDimensionPath += "\n";
                    }
                    vehicleFacet = "down";   
                }

                if (yLocation > yDestination)
                {
                    if (facet == "down")
                    {
                        oneDimensionPath += "Vehicle points to down 🡻\n";
                        oneDimensionPath += "turn back,";
                        oneDimensionPath += "(up of user), ";
                        oneDimensionPath += "move forward ";
                        oneDimensionPath += " to ";
                        oneDimensionPath += alphabet[indexD];
                        oneDimensionPath += "\n";
                    }
                    else if (facet == "up")
                    {
                        oneDimensionPath += "Vehicle points to up 🡹\n";
                        oneDimensionPath += "move forward ";
                        oneDimensionPath += " to ";
                        oneDimensionPath += alphabet[indexD];
                        oneDimensionPath += "\n";
                    }
                    else if (facet == "left")
                    {
                        oneDimensionPath += "Vehicle points to left 🡸\n";
                        oneDimensionPath += "turn right, ";
                        oneDimensionPath += "(up of user), ";
                        oneDimensionPath += "move forward ";
                        oneDimensionPath += " to ";
                        oneDimensionPath += alphabet[indexD];
                        oneDimensionPath += "\n";
                    }
                    else if (facet == "right")
                    {
                        oneDimensionPath += "Vehicle points to right 🡺\n";
                        oneDimensionPath += "turn left, ";
                        oneDimensionPath += "(up of user), ";
                        oneDimensionPath += "move forward ";
                        oneDimensionPath += " to ";
                        oneDimensionPath += alphabet[indexD];
                        oneDimensionPath += "\n";
                    }
                    vehicleFacet = "up";
                }
            }

            else if (yLocation == yDestination)
            {
                if (xLocation < xDestination)
                {
                    if (facet == "down")
                    {
                        oneDimensionPath += "Vehicle points to down 🡻\n";
                        oneDimensionPath += "turn left, ";
                        oneDimensionPath += "(right of user), ";
                        oneDimensionPath += "move forward ";
                        oneDimensionPath += " to ";
                        oneDimensionPath += alphabet[indexD];
                        oneDimensionPath += "\n";
                    }
                    else if (facet == "up")
                    {
                        oneDimensionPath += "Vehicle points to up 🡹\n";
                        oneDimensionPath += "turn right, ";
                        oneDimensionPath += "move forward ";
                        oneDimensionPath += " to ";
                        oneDimensionPath += alphabet[indexD];
                        oneDimensionPath += "\n";
                    }
                    else if (facet == "left")
                    {
                        oneDimensionPath += "Vehicle points to left 🡸\n";
                        oneDimensionPath += "turn back, ";
                        oneDimensionPath += "(right of user), ";
                        oneDimensionPath += "move forward ";
                        oneDimensionPath += " to ";
                        oneDimensionPath += alphabet[indexD];
                        oneDimensionPath += "\n";
                    }
                    else if (facet == "right")
                    {
                        oneDimensionPath += "Vehicle points to right 🡺\n";
                        oneDimensionPath += "move forward, ";
                        oneDimensionPath += "(right of user), ";
                        oneDimensionPath += " to ";
                        oneDimensionPath += alphabet[indexD];
                        oneDimensionPath += "\n";
                    }
                    vehicleFacet = "right";
                }
                if (xLocation > xDestination)
                {
                    if (facet == "down")
                    {
                        oneDimensionPath += "Vehicle points to down 🡻\n";
                        oneDimensionPath += "turn right, ";
                        oneDimensionPath += "(left of user), ";
                        oneDimensionPath += "move forward, ";
                        oneDimensionPath += " to ";
                        oneDimensionPath += alphabet[indexD];
                        oneDimensionPath += "\n";
                    }
                    else if (facet == "up")
                    {
                        oneDimensionPath += "Vehicle points to up 🡹\n";
                        oneDimensionPath += "turn left, ";
                        oneDimensionPath += "move forward, ";
                        oneDimensionPath += " to ";
                        oneDimensionPath += alphabet[indexD];
                        oneDimensionPath += "\n";
                    }
                    else if (facet == "left")
                    {
                        oneDimensionPath += "Vehicle points to left 🡸\n";
                        oneDimensionPath += " move forward, ";
                        oneDimensionPath += "(left of user), ";
                        oneDimensionPath += " to ";
                        oneDimensionPath += alphabet[indexD];
                        oneDimensionPath += "\n";
                    }
                    else if (facet == "right")
                    {
                        oneDimensionPath += "Vehicle points to right 🡺\n";
                        oneDimensionPath += "turn back, ";
                        oneDimensionPath += "(left of user), ";
                        oneDimensionPath += "move forward ";
                        oneDimensionPath += " to ";
                        oneDimensionPath += alphabet[indexD];
                        oneDimensionPath += "\n";
                    }
                    vehicleFacet = "left";
                }
            }

            return oneDimensionPath;
        }

        private void btnReLoad_Click(object sender, EventArgs e)
        {
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
            parent.Enabled = true;
            frm.Close();
            
        }

        private void directCal_FormClosing(object sender, FormClosingEventArgs e)
        {
            parent.Enabled = true;
            e.Cancel = false;
        }

        private string arrowAdding (int index)
        {
            string arrow = "";

            SelectRichText(rtbGraph, alphabet[index].ToString());

            if (vehicleFacet == "up")
            {
                arrow = "🡹";
                rtbGraph.SelectedText += arrow;
            }
            if (vehicleFacet == "down")
            {
                arrow = "🡻";
                rtbGraph.SelectedText += arrow;
            }
            if (vehicleFacet == "left")
            {
                arrow = "🡸";
                rtbGraph.SelectedText += arrow;
            }
            if (vehicleFacet == "right")
            {
                arrow = "🡺";
                rtbGraph.SelectedText += arrow;
            }

            rtbGraph.Text = rtbGraph.Text.Remove((rtbGraph.Text.IndexOf(arrow) - 3), 2);
            return arrow;
        }

        //Select given text from rich text box
        private void SelectRichText(RichTextBox rch, string target)
        {
            int pos = rch.Text.IndexOf(target);
            if (pos < 0)
            {
                rch.Select(0, 0);
            }
            else
            {
                rch.Select(pos, target.Length);
            }
        }

    }
}
