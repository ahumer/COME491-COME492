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
    public partial class Main : Form
    {
        systemData dataInfo = new systemData();
        char[] configData = {'1','2','3' };
        
        
 
        public Main()
        {
            InitializeComponent();

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (PortTB.Text == "")
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
                    

                }
                else
                {
                    MessageBox.Show("Can not connect!");
                }
            }

            ////Test
            //if (sysInf.Visible)
            //{
            //    label2.Visible = true;
            //    label2.Text = "Visible";
            //}
            //else
            //    label2.Text = "Invisible";

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (btnOFF.Visible == true)
            {
                MessageBox.Show("System is on!");
                return;
            }

            serialPort1.Close();
            if (serialPort1.IsOpen == false)
            {
                btnOpen.Enabled = true;
                btnClose.Enabled = false;
                lblState.Text = "";
                MessageBox.Show("Connection closed!");
                lblState.Text = "Not connected";
                lblSys.Text = "OFF";
                lblRbt.Text = "";
                lblSensor.Text = "";
                btnOpen.Visible = true;
                btnClose.Visible = false;
                btnON.Enabled = false;
                btnON.Enabled = false;
                btnSysInf.Enabled = false;
                


            }

            ////Test
            //if (sysInf.Visible)
            //    label2.Text = "Visible";
            //else
            //    label2.Text = "Invisible";

        }

        private bool SerialConnection()
        {
            bool state = false;
            try
            {
                serialPort1.PortName = PortTB.Text;
                serialPort1.BaudRate = 9600;
                serialPort1.Open();
                serialPort1.ReceivedBytesThreshold = 4;
                serialPort1.WriteTimeout = 5000;
                serialPort1.ReadTimeout = 5000;
                if(serialPort1.IsOpen)
                {
                    state = true;
                }           
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return state;
        }
        private void btnON_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (!serialPort1.IsOpen)
                {
                    btnOpen.Enabled = true;
                    btnClose.Enabled = false;
                    lblState.Text = "";
                    MessageBox.Show("Bluetooth connection is broken!)");
                    lblState.Text = "Not connected";
                    btnOpen.Visible = true;
                    btnClose.Visible = false;
                    btnON.Enabled = false;
                    btnON.Enabled = false;
                    btnSysInf.Enabled = false;

                }
                else
                {
                    lblSys.Text = "Waiting";
                    serialPort1.Write("200");
                    short counter = 0;
                    while (dataInfo.start == false && counter < 8)  //control it for '||' operator
                    {
                        Thread.Sleep(1000);
                        counter++;
                    }

                    if (dataInfo.fail == true)   //Maybe, I do this instead of dataInfo.start == false because of readability 
                                                 //or maybe because of flow changes, the need for it lost, but it stayed like this
                                                 //think about it later

                    {
                        lblSys.Text = "OFF";
                        lblRbt.Text = "Robot arm : Fail";
                        lblSensor.Text = "Sensors : Success";
                    }

                    else if (dataInfo.start == true)
                    {
                        lblRbt.Text = "Robot arm : Success";
                        lblSensor.Text = "Sensors : Success";
                        serialPort1.Write("@");
                        serialPort1.Write(configData, 0, 3);
                        while (dataInfo.confError == true && counter < 8)
                        {
                            Thread.Sleep(1000);
                            counter++;
                        }
                        if (dataInfo.confError == false)
                        {
                            lblSys.Text = "ON";
                            lblRbt.Text = "Robot arm : Success";
                            lblSensor.Text = "Sensors : Success";
                            btnON.Enabled = false;
                            btnOFF.Enabled = true;
                            btnON.Visible = false;
                            btnOFF.Visible = true;
                            btnLctConf.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show("Fail to send configuration data!");
                            lblSys.Text = "Error";
                        }
                    }
                    else
                    {
                        serialPort1.DiscardOutBuffer();
                        MessageBox.Show("Fail to communicate with sensors!");
                        lblSys.Text = "OFF";
                        lblRbt.Text = "";
                        lblSensor.Text = "";
                    }
                }    

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                dataInfo.start = false;
                dataInfo.confError = true;
                dataInfo.fail = false;
                MessageBox.Show("Reopen the connection!");
                lblSys.Text = "Exception!";
            }

        }

        private void btnOFF_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Write("201");
                dataInfo.keepData("201");
                btnON.Enabled = true;
                btnOFF.Enabled = false;
                btnON.Visible = true;
                btnOFF.Visible = false;
                btnLctConf.Enabled = true;
                lblSys.Text = "OFF";
                lblRbt.Text = "";
                lblSensor.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                dataInfo.start = false;
                dataInfo.confError = false; //control it later for the change
                dataInfo.fail = false;
                MessageBox.Show("Reopen the connection!");
                lblSys.Text = "Exception!";
            }

        }

        


        private void btnSysInf_Click(object sender, EventArgs e)
        {
            systemInfo sysInf = new systemInfo();
            sysInf.sysDataInf = dataInfo;
            Form frm = this.FindForm();
            sysInf.parent = frm;
            frm.Enabled = false;
            sysInf.Show();
            
            ////Test
            //if (sysInf.Visible)
            //    label2.Text = "Visible";
            //else
            //    label2.Text = "Invisible";

        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (serialPort1.BytesToRead > 3)
                {
                    dataInfo.keepData(serialPort1.ReadLine());
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
           
        }

        private void btnLctConf_Click(object sender, EventArgs e)
        {
            Configuration conf = new Configuration();
            conf.preConfig = configData;
            Form frm = this.FindForm();
            conf.parent = frm;
            frm.Enabled = false;
            conf.Show();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            var confirmResult = MessageBox.Show("Do you want to exit?",
                                     "Confirm Exit!!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.No)
            {
                e.Cancel = true;

            }

        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.btnOpen.Location = new System.Drawing.Point(10, 96);
            this.btnON.Location = new System.Drawing.Point(12, 21);
            lblRbt.Text = "";
            lblSensor.Text = "";
            string filePath = @"configLocation.txt";

            string configText;
            configText = File.ReadAllText(filePath);

            for(int i=0; i<3; i++)
            {
                configData[i] = configText.ElementAt(i);
            }



        }
    }

    public class systemData
    {
        public bool start;
        public bool fail;
        public short product;
        public short process;
        public short color;
        public short lastProduct;
        public bool confError;
        public systemData()
        {
            start = false; //successful start
            fail = false;  //fail to start
            product = -1;  //-1->none ; 0->not detected ; 1->detected
            process = -1;  //-1->none ; 0->waiting ; 1->reading ; 2->placing
            color = -1;    //-1->none ; 0->not detected ; 1->red ; 2->green ; 3->blue
            lastProduct = -1;
            confError = true;
        }
        public void keepData(string data)
        {
            if (data == "202")
            {
                start = true;
                fail = false;
                process = 0;  //waiting
            }
            if (data == "205")
            {
                start = false;
                fail = true;
                confError = false;  //control it later for true value
                process = -1;  //none
            }
            if(data=="212")
            {
                product = 1;  //detected
                process = 1;  //reading
            }
            if (data == "211")
            {
                product = 0;  //not detected
            }
            if (data == "221")
            {
                color = 1;  //red
            }
            if (data == "222")
            {
                color = 2;  //green
            }
            if (data == "223")
            {
                color = 3;  //blue
            }
            if (data == "224")
            {
                lastProduct = color;
                color = 0;  //not detected
            }
            if (data == "203")
            {
                process = 2;  //placing
            }
            if(data=="204")
            {
                process = 0;  //waiting
                lastProduct = color;
                color = -1;   //none
                product = -1;  //none
            }
            if(data=="201")
            {
                process = -1;
                lastProduct = -1;
                color = -1;
                product = -1;
                start = false;
                fail = false;
                confError = true; //control it later for the change
            }
            if(data=="206")
            {
                start = true;
                confError = false;
                fail = false;

            }
            if (data == "207")
            {
                start = false;
                confError = true;//control it later for its absence
                fail = false;

            }
        }
    }

}

