using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Central_Management
{
    public static class Utilities
    {
        public static string[] alphabet = { "A", "B", "C", "D", "E", "F", "G", "H", "J" };
        public static string vehicleFacet = "";

        public static string pathCalculation(int indexL, int indexD, int indexPr, Label lblFacet, RichTextBox rch)
        {
            int xL, xD, yL, yD, xPr, yPr;
            string directionPath = "";
            string directionForVehicle = "";
            string[] directionCalcResult;
            string arrowStart;

            //According to index of them, current location, destination and the previous location coordinates are calculated
            xL = indexL / 3;
            xD = indexD / 3;
            yL = indexL % 3;
            yD = indexD % 3;
            xPr = indexPr / 3;
            yPr = indexPr % 3;

            //Calculate which direction the vehicle is facing
            vehicleFacet = Utilities.facetCalculation(xL, yL, xPr, yPr);
            lblFacet.Text = vehicleFacet;

            if (vehicleFacet == "Invalid")
            {
                lblFacet.ForeColor = Color.Black;
                directionPath += "move forward\n";
                directionPath += "Calculate again";
            }
            else
            {
                lblFacet.ForeColor = Color.Orange;

                //Adding an arrow to the graph that indicates the direction the vehicle is facing
                arrowStart = Utilities.arrowAdding(alphabet[indexL], vehicleFacet,rch);

                //According to the current location and the destination coordinates, calculating the path
                if (((xL < xD) || (xL > xD)) && ((yL < yD) || (yL > yD)))
                {
                    directionCalcResult = oneDimensionPathCalc(xL, yL, xD, yL);
                    directionPath += directionCalcResult[0];
                    directionForVehicle += directionCalcResult[1];
                    vehicleFacet = directionCalcResult[2];

                    int tempPosVehicle = xD * 3 + yL;
                    Utilities.arrowAdding(alphabet[tempPosVehicle], vehicleFacet, rch);

                    directionCalcResult = oneDimensionPathCalc(xD, yL, xD, yD);
                    directionPath += directionCalcResult[0];
                    directionForVehicle += directionCalcResult[1];
                }
                else
                {
                    directionCalcResult = oneDimensionPathCalc( xL, yL, xD, yD);
                    directionPath += directionCalcResult[0];
                    directionForVehicle += directionCalcResult[1];
                }
                Utilities.SelectRichText(rch, arrowStart);
                rch.SelectionColor = Color.Orange;
                Utilities.SelectRichText(rch, alphabet[indexL].ToString());
                rch.SelectionColor = Color.DarkRed;
            }
            return directionPath;
        }

        //Calculate the direction for given location and destination coordinates, only on same x coordinates or  on same y coordinates
        public static string[] oneDimensionPathCalc( int xLocation, int yLocation, int xDestination, int yDestination)
        {
            string oneDimensionPath = "$";
            string directionForVehicle = "";
            string facetOut = vehicleFacet;

            int indexD = xDestination * 3 + yDestination;
            if (xLocation == xDestination)
            {
                if (yLocation < yDestination)
                {
                    if (vehicleFacet == "down")
                    {
                        oneDimensionPath += "Vehicle points to down 🡻\n";
                        oneDimensionPath += "move forward ";
                        oneDimensionPath += "(down of user), ";
                        oneDimensionPath += " to ";
                        oneDimensionPath += alphabet[indexD];
                        oneDimensionPath += "\n";
                        directionForVehicle += alphabet[indexD];

                    }
                    else if (vehicleFacet == "up")
                    {

                        oneDimensionPath += "Vehicle points to up 🡹\n";
                        oneDimensionPath += "turn back,";
                        oneDimensionPath += "move forward ";
                        oneDimensionPath += " to ";
                        oneDimensionPath += alphabet[indexD];
                        oneDimensionPath += "\n";
                        directionForVehicle += "turn back$";
                        directionForVehicle += alphabet[indexD];
                    }
                    else if (vehicleFacet == "left")
                    {
                        oneDimensionPath += "Vehicle points to left 🡸\n";
                        oneDimensionPath += "turn left, ";
                        oneDimensionPath += "(down of user), ";
                        oneDimensionPath += "move forward ";
                        oneDimensionPath += " to ";
                        oneDimensionPath += alphabet[indexD];
                        oneDimensionPath += "\n";
                        directionForVehicle += "turn left$";
                        directionForVehicle += alphabet[indexD];
                    }
                    else if (vehicleFacet == "right")
                    {
                        oneDimensionPath += "Vehicle points to right 🡺\n";
                        oneDimensionPath += "turn right, ";
                        oneDimensionPath += "(down of user), ";
                        oneDimensionPath += "move forward ";
                        oneDimensionPath += " to ";
                        oneDimensionPath += alphabet[indexD];
                        oneDimensionPath += "\n";
                        directionForVehicle += "turn right$";
                        directionForVehicle += alphabet[indexD];
                    }
                       facetOut = "down";
                }

                if (yLocation > yDestination)
                {
                    if (vehicleFacet == "down")
                    {
                        oneDimensionPath += "Vehicle points to down 🡻\n";
                        oneDimensionPath += "turn back,";
                        oneDimensionPath += "(up of user), ";
                        oneDimensionPath += "move forward ";
                        oneDimensionPath += " to ";
                        oneDimensionPath += alphabet[indexD];
                        oneDimensionPath += "\n";
                        directionForVehicle += "turn back$";
                        directionForVehicle += alphabet[indexD];
                    }
                    else if (vehicleFacet == "up")
                    {
                        oneDimensionPath += "Vehicle points to up 🡹\n";
                        oneDimensionPath += "move forward ";
                        oneDimensionPath += " to ";
                        oneDimensionPath += alphabet[indexD];
                        oneDimensionPath += "\n";
                        directionForVehicle += alphabet[indexD];
                    }
                    else if (vehicleFacet == "left")
                    {
                        oneDimensionPath += "Vehicle points to left 🡸\n";
                        oneDimensionPath += "turn right, ";
                        oneDimensionPath += "(up of user), ";
                        oneDimensionPath += "move forward ";
                        oneDimensionPath += " to ";
                        oneDimensionPath += alphabet[indexD];
                        oneDimensionPath += "\n";
                        directionForVehicle += "turn right$";
                        directionForVehicle += alphabet[indexD];
                    }
                    else if (vehicleFacet == "right")
                    {
                        oneDimensionPath += "Vehicle points to right 🡺\n";
                        oneDimensionPath += "turn left, ";
                        oneDimensionPath += "(up of user), ";
                        oneDimensionPath += "move forward ";
                        oneDimensionPath += " to ";
                        oneDimensionPath += alphabet[indexD];
                        oneDimensionPath += "\n";
                        directionForVehicle += "turn left$";
                        directionForVehicle += alphabet[indexD];
                    }
                    facetOut = "up";
                }
            }

            else if (yLocation == yDestination)
            {
                if (xLocation < xDestination)
                {
                    if (vehicleFacet == "down")
                    {
                        oneDimensionPath += "Vehicle points to down 🡻\n";
                        oneDimensionPath += "turn left, ";
                        oneDimensionPath += "(right of user), ";
                        oneDimensionPath += "move forward ";
                        oneDimensionPath += " to ";
                        oneDimensionPath += alphabet[indexD];
                        oneDimensionPath += "\n";
                        directionForVehicle += "turn left$";
                        directionForVehicle += alphabet[indexD];
                    }
                    else if (vehicleFacet == "up")
                    {
                        oneDimensionPath += "Vehicle points to up 🡹\n";
                        oneDimensionPath += "turn right, ";
                        oneDimensionPath += "move forward ";
                        oneDimensionPath += " to ";
                        oneDimensionPath += alphabet[indexD];
                        oneDimensionPath += "\n";
                        directionForVehicle += "turn right$";
                        directionForVehicle += alphabet[indexD];
                    }
                    else if (vehicleFacet == "left")
                    {
                        oneDimensionPath += "Vehicle points to left 🡸\n";
                        oneDimensionPath += "turn back, ";
                        oneDimensionPath += "(right of user), ";
                        oneDimensionPath += "move forward ";
                        oneDimensionPath += " to ";
                        oneDimensionPath += alphabet[indexD];
                        oneDimensionPath += "\n";
                        directionForVehicle += "turn back$";
                        directionForVehicle += alphabet[indexD];
                    }
                    else if (vehicleFacet == "right")
                    {
                        oneDimensionPath += "Vehicle points to right 🡺\n";
                        oneDimensionPath += "move forward, ";
                        oneDimensionPath += "(right of user), ";
                        oneDimensionPath += " to ";
                        oneDimensionPath += alphabet[indexD];
                        oneDimensionPath += "\n";
                        directionForVehicle += alphabet[indexD];
                    }
                    facetOut = "right";
                }
                if (xLocation > xDestination)
                {
                    if (vehicleFacet == "down")
                    {
                        oneDimensionPath += "Vehicle points to down 🡻\n";
                        oneDimensionPath += "turn right, ";
                        oneDimensionPath += "(left of user), ";
                        oneDimensionPath += "move forward, ";
                        oneDimensionPath += " to ";
                        oneDimensionPath += alphabet[indexD];
                        oneDimensionPath += "\n";
                        directionForVehicle += alphabet[indexD];
                    }
                    else if (vehicleFacet == "up")
                    {
                        oneDimensionPath += "Vehicle points to up 🡹\n";
                        oneDimensionPath += "turn left, ";
                        oneDimensionPath += "move forward, ";
                        oneDimensionPath += " to ";
                        oneDimensionPath += alphabet[indexD];
                        oneDimensionPath += "\n";
                        directionForVehicle += alphabet[indexD];
                    }
                    else if (vehicleFacet == "left")
                    {
                        oneDimensionPath += "Vehicle points to left 🡸\n";
                        oneDimensionPath += " move forward, ";
                        oneDimensionPath += "(left of user), ";
                        oneDimensionPath += " to ";
                        oneDimensionPath += alphabet[indexD];
                        oneDimensionPath += "\n";
                        directionForVehicle += alphabet[indexD];
                    }
                    else if (vehicleFacet == "right")
                    {
                        oneDimensionPath += "Vehicle points to right 🡺\n";
                        oneDimensionPath += "turn back, ";
                        oneDimensionPath += "(left of user), ";
                        oneDimensionPath += "move forward ";
                        oneDimensionPath += " to ";
                        oneDimensionPath += alphabet[indexD];
                        oneDimensionPath += "\n";
                        directionForVehicle += alphabet[indexD];
                    }
                    facetOut = "left";
                }
            }

            vehicleFacet = facetOut;
            string[] directions = { oneDimensionPath, directionForVehicle};
            return directions;
        }

        //Calculate the facet of the vehicle according to given current location and previous location
        public static string facetCalculation(int xLocation, int yLocation, int xPrevious, int yPrevious)
        {
            string facet = "Invalid";
            if (xLocation == xPrevious)
            {
                if ((yLocation - yPrevious) == -1)
                {
                    facet = "up";
                }
                else if ((yLocation - yPrevious) == 1)
                {
                    facet = "down";
                }
            }
            if (yLocation == yPrevious)
            {
                if ((xLocation - xPrevious) == -1)
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

        //Select given text from rich text box
        public static void SelectRichText(RichTextBox rch, string target)
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
        public static string arrowAdding(string locOnGraph, string facet, RichTextBox rch)
        {
            string arrow = "";

            Utilities.SelectRichText(rch,locOnGraph);

            if (facet == "up")
            {
                arrow = "🡹";
                rch.SelectedText += arrow;
            }
            if (facet == "down")
            {
                arrow = "🡻";
                rch.SelectedText += arrow;
            }
            if (facet == "left")
            {
                arrow = "🡸";
                rch.SelectedText += arrow;
            }
            if (facet == "right")
            {
                arrow = "🡺";
                rch.SelectedText += arrow;
            }

            rch.Text = rch.Text.Remove((rch.Text.IndexOf(arrow) - 3), 2);
            return arrow;
        }
    }
}
