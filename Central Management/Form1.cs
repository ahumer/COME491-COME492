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
        }

        private bool SerialConnection()
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

        private void btnOFF_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Write("201");
                btnON.Enabled = true;
                btnOFF.Enabled = false;
                btnON.Visible = true;
                btnOFF.Visible = false;
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
                btnON.Enabled = false;
                btnOFF.Enabled = true;
                btnON.Visible = false;
                btnOFF.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        
    }
}

