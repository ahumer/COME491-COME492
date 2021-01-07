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
                    btnLctConf.Enabled = true;

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
                btnOpen.Visible = true;
                btnClose.Visible = false;
                btnON.Enabled = false;
                btnON.Enabled = false;
                btnSysInf.Enabled = false;
                btnLctConf.Enabled = false;


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
                serialPort1.Write("201");
                dataInfo.keepData("201");
                btnON.Enabled = true;
                btnOFF.Enabled = false;
                btnON.Visible = true;
                btnOFF.Visible = false;
                lblSys.Text = "OFF";
                lblRbt.Text = "Not connected";
                lblSensor.Text = "Not connected";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnON_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Write("200");
                lblSys.Text = "Waiting";
                short counter = 0;
                while (dataInfo.start == false && counter < 8)
                {
                    Thread.Sleep(1000);
                    counter++;
                }
                if (dataInfo.fail == true)
                {
                    lblSys.Text = "Fail";
                    lblRbt.Text = "Fail";
                    lblSensor.Text = "Connected";
                }
                else if (dataInfo.start == true)
                {
                    lblSys.Text = "ON";
                    lblRbt.Text = "Connected";
                    lblSensor.Text = "Connected";
                    btnON.Enabled = false;
                    btnOFF.Enabled = true;
                    btnON.Visible = false;
                    btnOFF.Visible = true;
                }
                else
                {
                    MessageBox.Show("Fail to communicate with sensors!");
                    lblSys.Text = "OFF";
                }
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnSysInf_Click(object sender, EventArgs e)
        {
            systemInfo sysInf = new systemInfo();
            sysInf.sysDataInf = dataInfo;
            sysInf.Show();

            ////Test
            //if (sysInf.Visible)
            //    label2.Text = "Visible";
            //else
            //    label2.Text = "Invisible";

        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (serialPort1.BytesToRead > 3)
            {
                dataInfo.keepData(serialPort1.ReadLine());
            }
        }

        private void btnLctConf_Click(object sender, EventArgs e)
        {
            Configuration conf = new Configuration();
            conf.Show();
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
        public systemData()
        {
            start = false; //successful start
            fail = false;  //fail to start
            product = -1;  //-1->none ; 0->not detected ; 1->detected
            process = -1;  //-1->none ; 0->waiting ; 1->reading ; 2->placing
            color = -1;    //-1->none ; 0->not detected ; 1->red ; 2->green ; 3->blue
            lastProduct = -1;
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
            }
        }
    }

}

