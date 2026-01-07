using System;
using NationalInstruments.DAQmx;

// a class for interfacing with the usb-6501 Digital IO board from national instruments.
// allows for reading and writing of bits on the device
// also should report its device name when asked
namespace IctCustomControlBoard
{
    public class CustomDIOBoard(string deviceName) : IDisposable
    {
        private readonly string deviceName = deviceName;

        // SetBits: write an 8-bit value to a digital output port
        public void SetBits(string portName, byte value)
        {
            using (NationalInstruments.DAQmx.Task doTask = new())
            {
                string channel = $"{deviceName}/{portName}";

                doTask.DOChannels.CreateChannel(
                    channel,
                    "",
                    ChannelLineGrouping.OneChannelForAllLines);

                DigitalSingleChannelWriter writer = new(doTask.Stream);
                writer.WriteSingleSamplePort(true, value);

                Console.WriteLine($"[{deviceName}] Set {portName} = 0x{value:X2}");
            }
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

            Console.WriteLine($"[{deviceName}] Read {portName} = 0x{value:X2}");
            return value;
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
