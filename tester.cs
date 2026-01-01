//using MccDaq;
//using System;
//using USB1208_Controller;

//namespace USB1208_Test
//{
//    class Program
//    {
//        static void Main()
//        {
//            try
//            {
//                // Create an instances for board
//                CustomBoard board0 = new (0);

//                Console.WriteLine("Created 1 CustomBoard instances .\n");

//                //// Display board names (as reported by InstaCal)
//                Console.WriteLine($"Board 0: {board0.GetIOId()}");


//                Console.WriteLine();


//                //// Read analog channel 0 voltage from each board
//                double v0 = board0.GetVoltage(0);


//                Console.WriteLine($"Board 0 Channel 0 Voltage: {v0:F3} V");

//                //// Set all bits on Port A
//                board0.SetBits(DigitalPortType.FirstPortA, 0xFF);
//                Console.WriteLine("port A set to all high\n sleeping for 10s");

//                Thread.Sleep(10000);
//                //// Read back the port and report the result
//                short result = board0.GetBits(DigitalPortType.FirstPortA);
//                Console.WriteLine($"Port A state after setting all bits: {Convert.ToString(result & 0xFF, 2).PadLeft(8, '0')}");


//                Console.WriteLine("\nAll boards read successfully.");
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("Error: " + ex.Message);
//            }

//            Console.WriteLine("\nPress any key to exit...");
//            Console.ReadKey();
//        }
//    }
//}
