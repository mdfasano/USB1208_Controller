using System;
using System.Windows.Forms;
using MccDaq;

namespace USB1208_Controller
{
    public partial class Form1 : Form
    {
        private CustomBoard customBoard;

        public Form1()
        {
            InitializeComponent();
            customBoard = new CustomBoard(0);
        }

        private void btnGetVoltage_Click(object sender, EventArgs e)
        {
            try
            {
                double voltage = customBoard.GetVoltage(0); // Read from channel 0
                txtOutput.Text = $"Analog Ch0: {voltage:F3} V";
                lblStatus.Text = "Status: Voltage read successful";
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error: " + ex.Message;
            }
        }

        private void btnGetBits_Click(object sender, EventArgs e)
        {
            try
            {
                byte bits = customBoard.GetBits(DigitalPortType.FirstPortB);
                txtOutput.Text = $"Port B bits: {Convert.ToString(bits, 2).PadLeft(8, '0')}";
                lblStatus.Text = "Status: Digital input read successful";
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error: " + ex.Message;
            }
        }

        private void btnSetBits_Click(object sender, EventArgs e)
        {
            try
            {
                // Example: set 0b10101010 on Port A
                byte outputPattern = 0b10101010;
                customBoard.SetBits(DigitalPortType.FirstPortA, outputPattern);
                txtOutput.Text = "Port A set to 0b10101010";
                lblStatus.Text = "Status: Digital output successful";
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error: " + ex.Message;
            }
        }

        private void btnGetIOID_Click(object sender, EventArgs e)
        {
            try
            {
                string name = customBoard.GetIOId();
                txtOutput.Text = "Board ID: " + name;
                lblStatus.Text = "Status: ID retrieved successfully";
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error: " + ex.Message;
            }
        }
    }
}
