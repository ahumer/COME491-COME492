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

namespace Central_Management
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void OPENbtn_Click(object sender, EventArgs e)
        {
            if (PortTB.Text == "")
                MessageBox.Show("Enter the port name!");
            else
            {
                if(SerialConnection()==true)
                {
                    OPENbtn.Enabled = false;
                    CLOSEbtn.Enabled = true;
                    StateLBL.Text = "";
                    MessageBox.Show("Connection established!");
                    StateLBL.Text = "Connected";

                }
                else
                {
                    MessageBox.Show("Can not connect!");
                }
                    

            }
        }

        private void CLOSEbtn_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            if (serialPort1.IsOpen == false)
            {
                OPENbtn.Enabled = true;
                CLOSEbtn.Enabled = false;
                StateLBL.Text = "";
                MessageBox.Show("Connection closed!");
                StateLBL.Text = "Not connected";

            }
                
        }

        private void ONbtn_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Write("1");
                ONbtn.Enabled = false;
                OFFbtn.Enabled = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            
        }

        private void OFFbtn_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Write("0");
                ONbtn.Enabled = true;
                OFFbtn.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private bool SerialConnection ()
        {
            bool state = false;
            try
            {
                serialPort1.PortName = PortTB.Text;
                serialPort1.BaudRate = 9600;
                serialPort1.Open();
                state = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return state;
        }
    }
}
