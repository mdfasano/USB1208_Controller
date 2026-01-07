using System;
using NationalInstruments.DAQmx;

// a class for interfacing with the usb-6002 Digital IO board from national instruments.
// allows for reading and writing of bits on the device
// allows for reading differential voltages from an analog input
// also should report its device name when asked
namespace IctCustomControlBoard
{
    public class CustomAIBoard(string deviceName) : IDisposable
    {
        private readonly string deviceName = deviceName;

        // SetBits: write an 8-bit value to a digital output port
        public void SetBits(string portName, byte value)
        {
            using NationalInstruments.DAQmx.Task doTask = new();
            string channel = $"{deviceName}/{portName}";

            doTask.DOChannels.CreateChannel(
                channel,
                "",
                ChannelLineGrouping.OneChannelForAllLines);

            DigitalSingleChannelWriter writer = new(doTask.Stream);
            writer.WriteSingleSamplePort(true, value);

            // debug statement: remove later
            Console.WriteLine($"[{deviceName}] Set {portName} = 0x{value:X2}");
        }

        // GetBits: read an 8-bit value from a digital input port
        public byte GetBits(string portName)
        {
            using NationalInstruments.DAQmx.Task diTask = new();
            string channel = $"{deviceName}/{portName}";

            diTask.DIChannels.CreateChannel(
                channel,
                "",
                ChannelLineGrouping.OneChannelForAllLines);

            DigitalSingleChannelReader reader = new(diTask.Stream);
            byte value = reader.ReadSingleSamplePortByte();

            // debug statement: remove later
            Console.WriteLine($"[{deviceName}] Read {portName} = 0x{value:X2}");
            return value;
        }

        // ANALOG INPUT — Read voltage from an AI channel
        public double GetVoltage(int channel)
        {
            using NationalInstruments.DAQmx.Task aiTask = new NationalInstruments.DAQmx.Task();
            string channelName = $"{deviceName}/ai{channel}";

            aiTask.AIChannels.CreateVoltageChannel(
                channelName,
                "",
                AITerminalConfiguration.Differential,   // Differential mode
                -5.0, 5.0,                              // Input range
                AIVoltageUnits.Volts);

            AnalogSingleChannelReader reader = new(aiTask.Stream);
            double voltage = reader.ReadSingleSample();

            // debug statement: remove later
            Console.WriteLine($"[{deviceName}] CH{channel} = {voltage:F3} V");
            return voltage;
        }

        // GetIOID: returns device name
        public string GetIOID()
        {
            return deviceName;
        }

        public void Dispose()
        {
            // Nothing persistent yet — provided for future resource cleanup
        }
    }
}