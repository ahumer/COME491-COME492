using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms;
using System.Threading;

namespace Central_Management
{
    public static class communication
    {
        public static SerialPort port = new SerialPort();
        public static int controlInTimer = 0;
        public static string serialText = "";
        public static int index;   //In sendingDirections
        public static bool SerialConnection (string portName)
        {
            bool state = false;
            try
            {
                port.PortName = portName;
                port.BaudRate = 9600;
                port.Open();
                port.ReadTimeout = 5000;
                port.WriteTimeout = 5000;

                state = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return state;
        }

        public static string systemCommunication(int wait, string message = "null", bool onlyWrite = true)
        {
            string buffer = "";
            int counter = 0;
            if (message != "null")
            {
                try
                {
                    port.Write(message);
                }
                catch (TimeoutException)
                {
                    MessageBox.Show("Serial port writing time out");
                }


            }
            if (onlyWrite == false)
            {
                while (counter < wait)
                {
                    if (port.BytesToRead == 0)
                    {
                        Thread.Sleep(1000);
                        counter++;

                    }

                    if (port.BytesToRead > 2)
                    {
                        try
                        {
                            buffer = port.ReadLine();
                            counter = wait + 1;
                            //tbSerial.Text += "sysCom"+ buffer;
                            if (buffer.ElementAt(0) == '&')
                            {
                                counter = 0;
                            }
                            
                        }
                        catch (TimeoutException)
                        {
                            MessageBox.Show("Serial port reading time out");
                        }

                    }
                    else
                    {
                        Thread.Sleep(1000);
                        counter++;
                    }
                    
                }

                if (buffer == "OK")
                {
                    try
                    {
                        port.Write("002");
                    }
                    catch (TimeoutException)
                    {
                        MessageBox.Show("Serial port writing time out (start)");
                    }
                }
               
            }



            return buffer;

        }
        public static bool connectionClosing ()
        {
            bool control = true;
            port.Close();
            control = port.IsOpen;

            return control;
        }
        public static string sendingDirections(string directions, RichTextBox tb, bool midStop)
        {
            string[] messages;
            string inMessage = "";
            string ID = "";

            messages = directions.ToString().Split('$');

            index = Int32.Parse(messages[2]);

            if (messages[1] == "F")
            {
                inMessage = "OK1";
            }
            else
            {
                inMessage = communication.systemCommunication(10, messages[1], false);
                if (inMessage == "OK1")
                {
                    tb.Text += "direction message has been sent.\n";
                }
                else
                {
                    tb.Text += "direction message couldn't be sent.\n";
                    inMessage = "fail";
                }
            }

            if(inMessage == "OK1")
            {
                inMessage = "";
                ID = cardIDreference.CardIDArray[index];
                inMessage = communication.systemCommunication(10, ID, false);
                if(inMessage == "OK2")
                {
                    if (midStop == true)
                    {
                        tb.Text += "Waiting the vehicle to arrive mid-stop.\n";
                    }
                    else
                    {
                        tb.Text += "Waiting the vehicle to arrive destination.\n";
                    }

                   
                }
                else
                {
                    tb.Text += "ID message couldn't be sent.\n";
                    inMessage = "fail";
                }
            }

            return inMessage;

        }
        public static string readingSerialTimer()
        {
            string buffer = "";

            if (communication.port.BytesToRead != 0)
            {

                try
                {
                    if (controlInTimer == 0)
                    {
                        buffer = communication.port.ReadLine();
                    }
                    else
                    {
                        buffer = communication.port.ReadLine();
                        cardIDreference.preCardID = cardIDreference.cardID;
                        cardIDreference.cardID = buffer;
                        cardIDreference.cardID = cardIDreference.cardID.Trim();
                        controlInTimer = 0; ;

                    }

                    if (buffer == "#")
                    {
                        controlInTimer = 1;
                    }


                }
                catch (TimeoutException)
                {
                    MessageBox.Show("Serial port reading time out");
                }
            }
            return buffer;
        }
    }
}
