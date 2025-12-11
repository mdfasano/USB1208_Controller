using System;
using System.Windows.Forms;
using MccDaq;

namespace USB1208_Controller
{
    public partial class Form1 : Form
    {
        private MccBoard daqBoard;
        private DigitalPortType port = DigitalPortType.FirstPortA;
        private bool[] bitState = new bool[4];  // store state for A0–A3

        public Form1()
        {
            InitializeComponent();
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            try
            {
                int boardNum = 0;
                daqBoard = new MccBoard(boardNum);

                // Configure Port A as output
                ErrorInfo err = daqBoard.DConfigPort(port, DigitalPortDirection.DigitalOut);
                if (err.Value != ErrorInfo.ErrorCode.NoErrors)
                    MessageBox.Show("Error configuring port: " + err.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Initialization error: " + ex.Message);
            }
        }

        private void ToggleBit(int bit, Label lbl)
        {
            bitState[bit] = !bitState[bit];
            DigitalLogicState state = bitState[bit] ? DigitalLogicState.High : DigitalLogicState.Low;

            daqBoard.DBitOut(port, bit, state);
            lbl.Text = $"A{bit}: {(bitState[bit] ? "ON" : "OFF")}";
            lbl.ForeColor = bitState[bit] ? System.Drawing.Color.Green : System.Drawing.Color.Red;
        }

        private void btnA0_Click(object sender, EventArgs e) => ToggleBit(0, lblA0);
        private void btnA1_Click(object sender, EventArgs e) => ToggleBit(1, lblA1);
        private void btnA2_Click(object sender, EventArgs e) => ToggleBit(2, lblA2);
        private void btnA3_Click(object sender, EventArgs e) => ToggleBit(3, lblA3);

        private void btnExit_Click(object sender, EventArgs e)
        {
            daqBoard = null;
            Close();
        }
    }
}
