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
        public static string directionForVehicle = "";
        public static string subDirectionCash = "";

        //Calculate the path from given current location to given destination
        public static string pathCalculation(int indexL, int indexD, int indexPr, Label lblFacet, RichTextBox rch)
        {
            int xL, xD, yL, yD, xPr, yPr;
            string directionPath = "";
            string[] directionCalcResult;
            string arrowStart;

            //According to index of them, current location, destination and the previous location coordinates are calculated
            if(indexL != -1)
            {
                xL = indexL / 3;
                yL = indexL % 3;
            }
            else
            {
                xL = -1;
                yL = -1;
            }
            
            xD = indexD / 3;
            yD = indexD % 3;

            if(indexPr != -1)
            {
                xPr = indexPr / 3;
                yPr = indexPr % 3;
            }
            else
            {
                xPr = -1;
                yPr = -1;
            }


            //Calculate which direction the vehicle is facing
            if(indexPr == -1 && indexL == 8)
            {
                //If previous card ID readed isn't on the list, and the card ID readed is the card ID of the enterence point of the vehicle to the stage.
                vehicleFacet = "up";
            }
            else
            {
                vehicleFacet = Utilities.facetCalculation(xL, yL, xPr, yPr);
                lblFacet.Text = vehicleFacet;
            }


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
                arrowStart = Utilities.arrowAdding(alphabet[indexL], rch);

                //According to the current location and the destination coordinates, calculating the path
                if (((xL < xD) || (xL > xD)) && ((yL < yD) || (yL > yD)))
                {
                    directionCalcResult = oneDimensionPathCalc(xL, yL, xD, yL);
                    directionPath += directionCalcResult[0];
                    directionForVehicle += directionCalcResult[1];

                    int tempPosVehicle = xD * 3 + yL;
                    Utilities.arrowAdding(alphabet[tempPosVehicle], rch);

                    directionCalcResult = oneDimensionPathCalc(xD, yL, xD, yD);
                    directionPath += "MID-STOP: ";
                    directionPath += directionCalcResult[0];
                    directionForVehicle += "@";
                    directionForVehicle += directionCalcResult[1];
                }
                else
                {
                    directionCalcResult = oneDimensionPathCalc( xL, yL, xD, yD);
                    directionPath += directionCalcResult[0];
                    directionForVehicle += directionCalcResult[1];
                    directionForVehicle += "@";
                    directionForVehicle += "null";
                }
                Utilities.SelectRichText(rch, arrowStart);
                rch.SelectionColor = Color.Orange;
                Utilities.SelectRichText(rch, alphabet[indexL].ToString());
                rch.SelectionColor = Color.DarkRed;

            }
            vehicleFacet = ""; //Prevent conflict with next calculation
            return directionPath;
        }

        //Calculate the direction for given location and destination coordinates, only on same x coordinates or  on same y coordinates
        public static string[] oneDimensionPathCalc( int xLocation, int yLocation, int xDestination, int yDestination)
        {
            string oneDimensionPath = "";
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
                        oneDimensionPath += "(down of user) ";
                        oneDimensionPath += " to ";
                        oneDimensionPath += alphabet[indexD];
                        oneDimensionPath += "\n";
                        directionForVehicle += "$240";
                        directionForVehicle += "$";
                        directionForVehicle += indexD;


                    }
                    else if (vehicleFacet == "up")
                    {

                        oneDimensionPath += "Vehicle points to up 🡹\n";
                        oneDimensionPath += "turn back,\n";
                        oneDimensionPath += "move forward ";
                        oneDimensionPath += " to ";
                        oneDimensionPath += alphabet[indexD];
                        oneDimensionPath += "\n";
                        directionForVehicle += "$243";
                        directionForVehicle += "$";
                        directionForVehicle += indexD;

                    }
                    else if (vehicleFacet == "left")
                    {
                        oneDimensionPath += "Vehicle points to left 🡸\n";
                        oneDimensionPath += "turn left ";
                        oneDimensionPath += "(down of user),\n ";
                        oneDimensionPath += "move forward ";
                        oneDimensionPath += " to ";
                        oneDimensionPath += alphabet[indexD];
                        oneDimensionPath += "\n";
                        directionForVehicle += "$241";
                        directionForVehicle += "$";
                        directionForVehicle += indexD;

                    }
                    else if (vehicleFacet == "right")
                    {
                        oneDimensionPath += "Vehicle points to right 🡺\n";
                        oneDimensionPath += "turn right ";
                        oneDimensionPath += "(down of user),\n ";
                        oneDimensionPath += "move forward ";
                        oneDimensionPath += " to ";
                        oneDimensionPath += alphabet[indexD];
                        oneDimensionPath += "\n";
                        directionForVehicle += "$242";
                        directionForVehicle += "$";
                        directionForVehicle += indexD;

                    }
                       facetOut = "down";
                }

                if (yLocation > yDestination)
                {
                    if (vehicleFacet == "down")
                    {
                        oneDimensionPath += "Vehicle points to down 🡻\n";
                        oneDimensionPath += "turn back ";
                        oneDimensionPath += "(up of user),\n ";
                        oneDimensionPath += "move forward ";
                        oneDimensionPath += " to ";
                        oneDimensionPath += alphabet[indexD];
                        oneDimensionPath += "\n";
                        directionForVehicle += "$243";
                        directionForVehicle += "$";
                        directionForVehicle += indexD;

                    }
                    else if (vehicleFacet == "up")
                    {
                        oneDimensionPath += "Vehicle points to up 🡹\n";
                        oneDimensionPath += "move forward ";
                        oneDimensionPath += " to ";
                        oneDimensionPath += alphabet[indexD];
                        oneDimensionPath += "\n";
                        directionForVehicle += "$240";
                        directionForVehicle += "$";
                        directionForVehicle += indexD;

                    }
                    else if (vehicleFacet == "left")
                    {
                        oneDimensionPath += "Vehicle points to left 🡸\n";
                        oneDimensionPath += "turn right ";
                        oneDimensionPath += "(up of user),\n ";
                        oneDimensionPath += "move forward ";
                        oneDimensionPath += " to ";
                        oneDimensionPath += alphabet[indexD];
                        oneDimensionPath += "\n";
                        directionForVehicle += "$242";
                        directionForVehicle += "$";
                        directionForVehicle += indexD;

                    }
                    else if (vehicleFacet == "right")
                    {
                        oneDimensionPath += "Vehicle points to right 🡺\n";
                        oneDimensionPath += "turn left, ";
                        oneDimensionPath += "(up of user),\n ";
                        oneDimensionPath += "move forward ";
                        oneDimensionPath += " to ";
                        oneDimensionPath += alphabet[indexD];
                        oneDimensionPath += "\n";
                        directionForVehicle += "$241";
                        directionForVehicle += "$";
                        directionForVehicle += indexD;

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
                        oneDimensionPath += "turn left ";
                        oneDimensionPath += "(right of user),\n ";
                        oneDimensionPath += "move forward ";
                        oneDimensionPath += " to ";
                        oneDimensionPath += alphabet[indexD];
                        oneDimensionPath += "\n";
                        directionForVehicle += "$241";
                        directionForVehicle += "$";
                        directionForVehicle += indexD;

                    }
                    else if (vehicleFacet == "up")
                    {
                        oneDimensionPath += "Vehicle points to up 🡹\n";
                        oneDimensionPath += "turn right,\n ";
                        oneDimensionPath += "move forward ";
                        oneDimensionPath += " to ";
                        oneDimensionPath += alphabet[indexD];
                        oneDimensionPath += "\n";
                        directionForVehicle += "$242";
                        directionForVehicle += "$";
                        directionForVehicle += indexD;

                    }
                    else if (vehicleFacet == "left")
                    {
                        oneDimensionPath += "Vehicle points to left 🡸\n";
                        oneDimensionPath += "turn back ";
                        oneDimensionPath += "(right of user),\n ";
                        oneDimensionPath += "move forward ";
                        oneDimensionPath += " to ";
                        oneDimensionPath += alphabet[indexD];
                        oneDimensionPath += "\n";
                        directionForVehicle += "$243";
                        directionForVehicle += "$";
                        directionForVehicle += indexD;

                    }
                    else if (vehicleFacet == "right")
                    {
                        oneDimensionPath += "Vehicle points to right 🡺\n";
                        oneDimensionPath += "move forward ";
                        oneDimensionPath += "(right of user), ";
                        oneDimensionPath += " to ";
                        oneDimensionPath += alphabet[indexD];
                        oneDimensionPath += "\n";
                        directionForVehicle += "$240";
                        directionForVehicle += "$";
                        directionForVehicle += indexD;

                    }
                    facetOut = "right";
                }
                if (xLocation > xDestination)
                {
                    if (vehicleFacet == "down")
                    {
                        oneDimensionPath += "Vehicle points to down 🡻\n";
                        oneDimensionPath += "turn right ";
                        oneDimensionPath += "(left of user),\n ";
                        oneDimensionPath += "move forward ";
                        oneDimensionPath += " to ";
                        oneDimensionPath += alphabet[indexD];
                        oneDimensionPath += "\n";
                        directionForVehicle += "$242";
                        directionForVehicle += "$";
                        directionForVehicle += indexD;

                    }
                    else if (vehicleFacet == "up")
                    {
                        oneDimensionPath += "Vehicle points to up 🡹\n";
                        oneDimensionPath += "turn left,\n ";
                        oneDimensionPath += "move forward ";
                        oneDimensionPath += " to ";
                        oneDimensionPath += alphabet[indexD];
                        oneDimensionPath += "\n";
                        directionForVehicle += "$241";
                        directionForVehicle += "$";
                        directionForVehicle += indexD;

                    }
                    else if (vehicleFacet == "left")
                    {
                        oneDimensionPath += "Vehicle points to left 🡸\n";
                        oneDimensionPath += " move forward ";
                        oneDimensionPath += "(left of user), ";
                        oneDimensionPath += " to ";
                        oneDimensionPath += alphabet[indexD];
                        oneDimensionPath += "\n";
                        directionForVehicle += "$240";
                        directionForVehicle += "$";
                        directionForVehicle += indexD;

                    }
                    else if (vehicleFacet == "right")
                    {
                        oneDimensionPath += "Vehicle points to right 🡺\n";
                        oneDimensionPath += "turn back ";
                        oneDimensionPath += "(left of user),\n ";
                        oneDimensionPath += "move forward ";
                        oneDimensionPath += " to ";
                        oneDimensionPath += alphabet[indexD];
                        oneDimensionPath += "\n";
                        directionForVehicle += "$243";
                        directionForVehicle += "$";
                        directionForVehicle += indexD;

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
            if(xLocation != -1 || yLocation != -1 || xPrevious != -1 || yPrevious != -1)
            {
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

        //Adding arrow to the graph according to the direction that the vehicle is facing and the index of the location
        public static string arrowAdding(string locOnGraph, RichTextBox rch)
        {
            string arrow = "";

            Utilities.SelectRichText(rch,locOnGraph);

            if (vehicleFacet == "up")
            {
                arrow = "🡹";
                rch.SelectedText += arrow;
            }
            if (vehicleFacet == "down")
            {
                arrow = "🡻";
                rch.SelectedText += arrow;
            }
            if (vehicleFacet == "left")
            {
                arrow = "🡸";
                rch.SelectedText += arrow;
            }
            if (vehicleFacet == "right")
            {
                arrow = "🡺";
                rch.SelectedText += arrow;
            }

            rch.Text = rch.Text.Remove((rch.Text.IndexOf(arrow) - 3), 2);
            return arrow;
        }
    }
}
