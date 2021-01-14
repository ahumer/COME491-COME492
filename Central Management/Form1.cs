using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Threading;

namespace Central_Management
{
    public partial class Form1 : Form
    {
        static SerialPort _serialPortV = new SerialPort();
        string cardID = "";
        string preCardID = "";
        int controlInTimer = 0;
        public Form1()
        {
            InitializeComponent();

        }


        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (tbVPort.Text == "")
                MessageBox.Show("Enter the port name!");
            else
            {
                if (SerialConnection() == true)
                {
                    lblState.Text = "";
                    MessageBox.Show("Connection established!");
                    lblState.Text = "Connected";
                    btnOpen.Visible = false;
                    btnClose.Visible = true;
                    btnON.Enabled = true;
                    btnSysInf.Enabled = true;
                    btnLctConf.Enabled = true;
                    rtbSerial.Enabled = true;

                }
                else
                {
                    MessageBox.Show("Can not connect!");
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (btnOFF.Visible == true)
            {
                MessageBox.Show("System is on!");
                return;
            }


            //Investigate if exception handling is required here
            
            _serialPortV.Close();
            if (_serialPortV.IsOpen == false)
            {
                lblState.Text = "";
                MessageBox.Show("Connection closed!");
                lblState.Text = "Not connected";
                btnOpen.Visible = true;
                btnClose.Visible = false;
                btnON.Enabled = false;
                btnSysInf.Enabled = false;
                btnLctConf.Enabled = false;
                rtbSerial.Enabled = false;
            }
        }

        private bool SerialConnection()
        {
            bool state = false;
            try
            {
                _serialPortV.PortName = tbVPort.Text;
                _serialPortV.BaudRate = 9600;
                _serialPortV.Open();
                _serialPortV.ReadTimeout = 5000;
                _serialPortV.WriteTimeout = 5000;

                state = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return state;
        }

        private void btnON_Click(object sender, EventArgs e)
        {
            _serialPortV.DiscardInBuffer();
            _serialPortV.DiscardOutBuffer();
            bool state = false;
            try
            {
                state = systemInit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (state)
            {
                btnON.Visible = false;
                btnOFF.Visible = true;
                btnOFF.Enabled = true;
                timer1.Enabled = true;
                gbCon.Visible = false;
                MessageBox.Show("The system is initialized succesfully.");
            }

            else
            {
                MessageBox.Show("The system couldn't be initialized.");
            }
                
        }


        private void btnOFF_Click(object sender, EventArgs e)
        {
            try
            {
                string preText = rtbSerial.Text;
                Form frm = this.FindForm();
                timer1.Enabled = false;
                rtbSerial.Text = "\nSTOP\n\n" + preText;
                gbCon.Visible = true;
                frm.Enabled = false;
                systemCommunication("201");
                timer2.Enabled = true;              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        

        private bool systemInit()
        {
            string inMessage = "";
            bool control = false;
            
            inMessage = systemCommunication("200",false);
            if (inMessage == "OK")
            {
                lblSensor.Text = "connected";
                rtbSerial.Text += "\n" + inMessage;
                control = true;
            }
            else
            {
                MessageBox.Show("couldn't communicate with the vehicle");
                
            }
            return control;
        }
        private string systemCommunication(string message = "null", bool onlyWrite = true)
        {
            string buffer = "";
            short counter = 0;
            if (message != "null")
            { 
                try
                {
                    _serialPortV.Write(message);
                }
                catch(TimeoutException)
                {
                    MessageBox.Show("Serial port writing time out");
                }
            
                
            }
            if (onlyWrite == false)
            {
                while (counter < 10)
                {
                    if (_serialPortV.BytesToRead == 0)
                    {
                        Thread.Sleep(1000);
                        counter++;

                    }

                    if (_serialPortV.BytesToRead > 2)
                    {
                        try
                        {
                            buffer = _serialPortV.ReadLine();
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
                        _serialPortV.Write("002");
                    }
                    catch (TimeoutException)
                    {
                        MessageBox.Show("Serial port writing time out (start)");
                    }
                }
            }

            
           
            return buffer;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string preText = rtbSerial.Text;
            string buffer;
            
            if (_serialPortV.BytesToRead != 0)
            {
                
                try
                {
                    if (controlInTimer == 0)
                    {
                        buffer = _serialPortV.ReadLine();
                    }
                    else
                    {   
                        buffer = _serialPortV.ReadLine();
                        preCardID = cardID;
                        cardID = buffer;
                        controlInTimer = 0; ;
                        
                    }
                    
                    if(buffer == "#")
                    {
                        controlInTimer = 1;
                    }
                    
                    buffer += "\n" + preText;
                    rtbSerial.Text = buffer;
                     
                }
                catch (TimeoutException) 
                {
                    MessageBox.Show("Serial port reading time out");
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            rtbSerial.Clear();
            rtbSerial.Text = "Current card ID: \n" + cardID + "\nPrevious card ID: \n" + preCardID;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Form frm = this.FindForm();
            Thread.Sleep(6500);
            frm.Enabled = true;
            btnOFF.Visible = false;
            btnON.Visible = true;
            timer2.Enabled = false;
        }
    }
    
}

