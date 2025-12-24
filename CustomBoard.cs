using System;
using MccDaq;

namespace USB1208_Controller
{
    public class CustomBoard
    {
        private readonly MccBoard daqBoard;

        public CustomBoard(int boardNum = 0)
        {
            daqBoard = new MccBoard(boardNum);
        }

        /// <summary>
        /// Reads an analog input voltage from the specified channel (0–7)
        /// </summary>
        public double GetVoltage(int channel)
        {
            float dataValue = 0;
            Range range = Range.Bip5Volts; // ±5 V typical
            ErrorInfo error = daqBoard.AIn(channel, range, out ushort adValue);

            if (error.Value != ErrorInfo.ErrorCode.NoErrors)
                throw new Exception("Analog input error: " + error.Message);

            // Convert raw A/D value to voltage
            daqBoard.ToEngUnits(range, adValue, out dataValue);
            return dataValue;
        }

        /// <summary>
        /// Reads the current digital port value (0–255)
        /// </summary>
        public byte GetBits(DigitalPortType port)
        {
            ErrorInfo error = daqBoard.DIn(port, out byte value);
            if (error.Value != ErrorInfo.ErrorCode.NoErrors)
                throw new Exception("Digital input error: " + error.Message);

            return value;
        }

        /// <summary>
        /// Writes a byte (0–255) to a digital port
        /// </summary>
        public void SetBits(DigitalPortType port, byte value)
        {
            ErrorInfo error = daqBoard.DOut(port, value);
            if (error.Value != ErrorInfo.ErrorCode.NoErrors)
                throw new Exception("Digital output error: " + error.Message);
        }

        /// <summary>
        /// Returns the board name or identifier string
        /// </summary>
        public string GetIOId()
        {
            return daqBoard.BoardName;
        }
    }
}
