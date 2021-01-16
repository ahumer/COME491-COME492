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

        public static string systemCommunication(string message = "null", bool onlyWrite = true)
        {
            string buffer = "";
            short counter = 0;
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
                while (counter < 10)
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
                            //tbSerial.Text += "sysCom"+ buffer;
                            counter = 11;
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
    }
}
