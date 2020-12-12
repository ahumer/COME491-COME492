﻿using System;
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
            serialPort1.PortName = "COM4";
            serialPort1.BaudRate = 9600;

        }

        private void OPENbtn_Click(object sender, EventArgs e)
        {
            if (PortTB.Text == "")
                MessageBox.Show("Enter the port name!");
            else
            {
                SerialConnection();
            }

            if (serialPort1.IsOpen == true)
                MessageBox.Show("Connected to COME4 port!");

        }

        private void CLOSEbtn_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            if (serialPort1.IsOpen == false)
                MessageBox.Show("Connection closed!");
        }

        private void ONbtn_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Write("1");
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void SerialConnection ()
        {
            try
            {
                serialPort1.PortName = PortTB.Text;
                serialPort1.BaudRate = 9600;
                serialPort1.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}