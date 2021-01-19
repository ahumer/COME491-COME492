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
        public string directionToSend = "";
        
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
                if (communication.SerialConnection(tbVPort.Text) == true)
                {
                    lblState.Text = "";
                    MessageBox.Show("Connection established!");
                    lblState.Text = "Connected";
                    btnOpen.Visible = false;
                    btnClose.Visible = true;
                    btnON.Enabled = true;
                    btnSysInf.Enabled = true;
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
            
            
            if (communication.connectionClosing() == false)
            {
                lblState.Text = "";
                MessageBox.Show("Connection closed!");
                lblState.Text = "Not connected";
                btnOpen.Visible = true;
                btnClose.Visible = false;
                btnON.Enabled = false;
                btnSysInf.Enabled = false;
                rtbSerial.Enabled = false;
            }
        }

        private void btnON_Click(object sender, EventArgs e)
        {
            communication.port.DiscardInBuffer();
            communication.port.DiscardOutBuffer();
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
                lblSys.Text = "ON";
                btnOFF.Enabled = true;
                timer1Main.Enabled = true;
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
                timer1Main.Enabled = false;
                rtbSerial.Text = "\nSTOP\n\n" + preText;
                gbCon.Visible = true;
                frm.Enabled = false;
                lblSys.Text = "OFF";
                communication.systemCommunication(10, "201");
                timer2Main.Enabled = true;              
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
            
            inMessage = communication.systemCommunication(10, "200",false);
            if (inMessage == "OK")
            {
                rtbSerial.Text += "\n" + inMessage;
                control = true;
            }
            else
            {
                MessageBox.Show("couldn't communicate with the vehicle");
                
            }
            return control;
        }
        

        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            rtbSerial.Clear();
            //rtbSerial.Text = "Current card ID: \n" + cardIDreference.cardID + "\nPrevious card ID: \n" + cardIDreference.preCardID;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
           
        }

        private void btnDirect_Click(object sender, EventArgs e)
        {
            directCal direction = new directCal();
            Form frm = this.FindForm();
            direction.parent = frm;
            frm.Visible = false;
            communication.serialText = rtbSerial.Text;
            timer1Main.Enabled = false;
            direction.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string filePath = @"configCardID.txt";

            string configText;
            configText = File.ReadAllText(filePath);

            rtbSerial.Text = configText;

            string [] subText = configText.Split('\n');

            char[] seperator = new char[] { '\r' };
            for(int i=0; i < 9; i++)
            {
                cardIDreference.CardIDArray[i] = subText[i].Trim('\r');
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void timer1Main_Tick(object sender, EventArgs e)
        {
             string buffer;
            string preText = rtbSerial.Text;
            if (communication.serialText != "")
            {
                buffer = communication.serialText;
                communication.serialText = "";
            }
            else
            {
                buffer = communication.readingSerialTimer();
            }
           
            if(buffer !="")
            {
                buffer += "\n" + preText;
                rtbSerial.Text = buffer;
            }

        }

        private void timer2Main_Tick(object sender, EventArgs e)
        {
            Form frm = this.FindForm();
            Thread.Sleep(6500);
            frm.Enabled = true;
            btnOFF.Visible = false;
            btnON.Visible = true;
            timer2Main.Enabled = false;
        }
    }
    
}

