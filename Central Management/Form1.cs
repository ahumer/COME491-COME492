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
        static SerialPort _serialPortS;
        static SerialPort _serialPortR;
        public Form1()
        {
            InitializeComponent();

        }

        Thread loopThread = new Thread(systemLoop);

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (tbSPort.Text == "" || tbRPort.Text=="")
                MessageBox.Show("Enter the port name!");
            else
            {
                if (SerialConnection() == true)
                {
                    btnOpen.Enabled = false;
                    btnClose.Enabled = true;
                    lblState.Text = "";
                    MessageBox.Show("Connection established!");
                    lblState.Text = "Connected";
                    btnOpen.Visible = false;
                    btnClose.Visible = true;
                    btnON.Enabled = true;
                    btnSysInf.Enabled = true;
                    btnLctConf.Enabled = true;

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
            _serialPortS.Close();
            _serialPortR.Close();
            if (_serialPortS.IsOpen == false && _serialPortR.IsOpen == false)
            {
                btnOpen.Enabled = true;
                btnClose.Enabled = false;
                lblState.Text = "";
                MessageBox.Show("Connection closed!");
                lblState.Text = "Not connected";
                btnOpen.Visible = true;
                btnClose.Visible = false;
                btnON.Enabled = false;
                btnON.Enabled = false;
                btnSysInf.Enabled = false;
                btnLctConf.Enabled = false;
            }
        }

        private bool SerialConnection()
        {
            bool state = false;
            try
            {
                _serialPortS.PortName = tbSPort.Text;
                _serialPortS.BaudRate = 9600;
                _serialPortS.Open();
                _serialPortR.PortName = tbRPort.Text;
                _serialPortR.BaudRate = 9600;
                _serialPortR.Open();

                state = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return state;
        }

        private void btnOFF_Click(object sender, EventArgs e)
        {
            try
            {


                btnOFF.Enabled = false;
                btnON.Enabled = true;
                btnOFF.Visible = false;
                btnON.Visible = true;
                
                systemCommunication("201"); //Indicate turning of the system
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnON_Click(object sender, EventArgs e)
        {
            bool state = false;
            try
            {

                
                state=systemInit();

                btnON.Enabled = false;
                btnOFF.Enabled = true;
                btnON.Visible = false;
                btnOFF.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (state)
                MessageBox.Show("The system is initialized succesfully.");
            else
                MessageBox.Show("The system couldn't be initialized.");
        }

        private bool systemInit()
        {
            string inMessage = "";
            bool control = true;
            //Communication with sensors
            inMessage = systemCommunication("200");
            if (inMessage == "OK")
            {
                lblSensor.Text = "connected";
            }
            else
            {
                control = false;
                MessageBox.Show("couldn't communicate with sensor station");
                
            }

            //communicate with robot arm
            inMessage = "";
            inMessage = systemCommunication("203");
            if (inMessage == "OK")
            {
                lblSensor.Text = "connected";
            }
            else
            {
                control = false;
                MessageBox.Show("couldn't communicate with robot arm");
            }
            return control;


        }
        private string systemCommunication(string message)
        {
      
            string buffer = "";

            if (_serialPortS.BytesToRead==0)
            {
                Thread.Sleep(1000);
                   
            }

            if(_serialPortS.BytesToRead!=0)
            {
                try
                {
                    _serialPortS.Write(message);
                    buffer = _serialPortS.ReadLine();
                }
                catch (TimeoutException) { }

            }

            return buffer;
        } 
        
        private static void systemLoop()
        {
            while (true)
            {
                try
                {
                    string message = "";

                    _serialPortS.WriteLine("204");

                    while (_serialPortS.BytesToRead == 0) { }

                    message = _serialPortS.ReadLine();

                    if (message == "251")
                    {
                        _serialPortR.WriteLine("251");
                    }

                    while (_serialPortS.BytesToRead == 0) { }

                    message = _serialPortS.ReadLine();

                    if (message == "252")
                    {
                        _serialPortR.WriteLine("252");
                    }
                    if (message == "253")
                    {
                        _serialPortR.WriteLine("253");
                    }
                    if (message == "254")
                    {
                        _serialPortR.WriteLine("254");
                    }

                    while (message == "255")
                    {
                        while (_serialPortR.BytesToRead == 0) { }

                        message = _serialPortR.ReadLine();
                    }
 
                }
                catch (TimeoutException) { }
            }
        }
    }
}


//Sistem döngü içinde bir yerde takılırsa ne kadar süre için time out verebilirim ve time out'da ne yapabilirim? Şu an bunla uğraşmalıyım?