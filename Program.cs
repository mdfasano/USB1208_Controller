using System;
using USB1208_Controller;

class Program
{
    static void Main()
    {
        BoardManager manager = new BoardManager();

        while (true)
        {
            Console.WriteLine($"\nSelect a board (0 to {manager.BoardCount - 1}) or 'exit':");
            string input = Console.ReadLine();
            if (input.Trim().ToLower() == "exit") break;

            if (!int.TryParse(input, out int boardIndex)) continue;

            try
            {
                CustomBoard board = manager.GetBoard(boardIndex);

                Console.WriteLine("Action: 1 = Read Port A, 2 = Write Port B");
                string action = Console.ReadLine();

                switch (action)
                {
                    case "1":
                        short valueA = board.GetBits("A");
                        Console.WriteLine($"Port A: {Convert.ToString(valueA & 0xFF, 2).PadLeft(8, '0')}");
                        break;
                    case "2":
                        Console.WriteLine("Enter value (0-255) for Port B:");
                        string valStr = Console.ReadLine();
                        if (byte.TryParse(valStr, out byte valueB))
                        {
                            board.SetBits("B", valueB);
                            Console.WriteLine($"Port B set to {Convert.ToString(valueB, 2).PadLeft(8, '0')}");
                        }
                        break;
                    default:
                        Console.WriteLine("Unknown action.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        Console.WriteLine("Exiting program...");
    }
}
