using System;
using MccDaq;


// this was written for the usb1208 device, which we decided not to use for the project
namespace IctCustomControlBoard
{
    public class CustomBoard
    {
        private readonly MccBoard daqBoard;

        public CustomBoard(int boardNum = 0)
        {
            daqBoard = new MccBoard(boardNum);

            // configure ports to output when initialized
            ConfigPort(DigitalPortType.FirstPortA, DigitalPortDirection.DigitalOut);
            ConfigPort(DigitalPortType.FirstPortB, DigitalPortDirection.DigitalOut);

            // configure input mode to differential
            daqBoard.AInputMode(AInputMode.Differential);
        }

        // Array of valid digital ports for this board
        private readonly DigitalPortType[] validDigitalPorts = [
            DigitalPortType.FirstPortA,
            DigitalPortType.FirstPortB,
    ];

        // Track the direction of each port
        private readonly Dictionary<DigitalPortType, DigitalPortDirection> portDirections = new Dictionary<DigitalPortType, DigitalPortDirection>();


        /// <summary>
        /// Reads an analog input voltage from the specified channel (0–7)
        /// </summary>
        public double GetVoltage(int channel)
        {
            float dataValue = 0;

            // check what input mode is configured

            //all need to be differential, can do on init
            MccDaq.Range range = MccDaq.Range.Bip5Volts; // ±5 V typical
            ErrorInfo error = daqBoard.AIn(channel, range, out ushort adValue);

            if (error.Value != ErrorInfo.ErrorCode.NoErrors)
                throw new Exception("Analog input error: " + error.Message);

            // Convert raw A/D value to voltage
            daqBoard.ToEngUnits(range, adValue, out dataValue);
            return dataValue;
        }

        /// Reads the current digital port value (0–255)
        /// give the ability to read and write at the same time
        /// verify with tests later

        public short GetBits(string portLetter)
        {
            DigitalPortType port = ConvertPortLetter(portLetter);

            // check that 'port' is valid
            if (Array.IndexOf(validDigitalPorts, port) < 0)
                throw new ArgumentException($"Invalid digital port: {port}");

            ErrorInfo error = daqBoard.DIn(port, out short value);
            if (error.Value != ErrorInfo.ErrorCode.NoErrors)
                throw new Exception("Digital input error: " + error.Message);

            return value;
        }

        /// 
        /// Writes a byte (0–255) to a digital port
        /// 
        public void SetBits(string portLetter, byte value)
        {
            DigitalPortType port = ConvertPortLetter(portLetter);

            // check that 'port' is valid
            if (Array.IndexOf(validDigitalPorts, port) < 0)
                throw new ArgumentException($"Invalid digital port: {port}");

            // Validate that port is configured as output
            if (portDirections[port] != DigitalPortDirection.DigitalOut)
                throw new Exception($"Port {portLetter} is not configured as output.");


            ErrorInfo error = daqBoard.DOut(port, value);
            if (error.Value != ErrorInfo.ErrorCode.NoErrors)
                throw new Exception("Digital output error: " + error.Message);
        }

        /// 
        /// Returns the board name or identifier string
        /// want to return the (serial number?)
        /// return class instead. ID and board number?
        public string GetIOId()
        {
            return daqBoard.BoardName;
        }

        /// Configures a digital port (A or B) as input or output.
        /// <param name="portLetter">Port letter: 'A' or 'B'</param>
        /// <param name="directionStr">Direction string: "input" or "output"</param>
        public void ConfigurePort(string portLetter, string directionStr)
        {
            ConfigPort(ConvertPortLetter(portLetter), ConvertDirection(directionStr));
        }
        // Helper function to configure a port
        private void ConfigPort(DigitalPortType port, DigitalPortDirection direction)
        {
            ErrorInfo err = daqBoard.DConfigPort(port, direction);
            if (err.Value != ErrorInfo.ErrorCode.NoErrors)
                throw new Exception($"Failed to configure {port} as {direction}: {err.Message}");

            // Track the port's direction
            portDirections[port] = direction;
        }

        /// Converts a port letter (A/B) to DigitalPortType
        public static DigitalPortType ConvertPortLetter(string portLetter)
        {
            return portLetter.ToUpper() switch
            {
                "A" => DigitalPortType.FirstPortA,
                "B" => DigitalPortType.FirstPortB,
                _ => throw new ArgumentException("Invalid port letter. Only 'A' or 'B' are supported."),
            };
        }

        /// Converts a direction string ("input"/"output") to DigitalPortDirection
        public static DigitalPortDirection ConvertDirection(string directionStr)
        {
            return directionStr.ToLower() switch
            {
                "input" => DigitalPortDirection.DigitalIn,
                "output" => DigitalPortDirection.DigitalOut,
                _ => throw new ArgumentException("Invalid direction. Use 'input' or 'output'."),
            };
        }
    }
}
