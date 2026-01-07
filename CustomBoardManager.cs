using System;
using IctCustomControlBoard;

namespace IctCustomControlBoard
{
    using System;

    public class BoardManager : IDisposable
    {
        public CustomDIOBoard Board0 { get; private set; } = null!;
        public CustomDIOBoard Board1 { get; private set; } = null!;
        public CustomDIOBoard Board2 { get; private set; } = null!;
        public CustomAIBoard Board3 { get; private set; } = null!;

        public BoardManager()
        {
            InitializeBoards();
        }

        private void InitializeBoards()
        {
            InitializeBoard0();
            InitializeBoard1();
            InitializeBoard2();
            InitializeBoard3();
        }

        // port 0: 0.0 - 0.7 are digital output
        // port 1: 1.0 and 1.1 and 1.4 - 1.7 are digital output. 1.2 and 1.3 are unused
        // port 2: 2.0 - 2.7 are digital output
        private void InitializeBoard0()
        {
            Board0 = new CustomDIOBoard("Dev1");

            Board0.ConfigurePort("port0", true);
            Board0.ConfigurePort("port1", true);
            Board0.ConfigurePort("port2", true);

            Console.WriteLine("Board0 (DIO) initialized as Dev1.");
        }

        // port 0:
        // port 1:
        // port 2: 
        private void InitializeBoard1()
        {
            Board1 = new CustomDIOBoard("Dev2");

            Board1.ConfigurePort("port0", true);
            Board1.ConfigurePort("port1", true);
            Board1.ConfigurePort("port2", true);

            Console.WriteLine("Board1 (DIO) initialized as Dev2.");
        }

        private void InitializeBoard2()
        {
            Board2 = new CustomDIOBoard("Dev3");

            Board2.ConfigurePort("port0", false);
            Board2.ConfigurePort("port1", false);
            Board2.ConfigurePort("port2", false);

            Console.WriteLine("Board2 (DIO) initialized as Dev3.");
        }

        private void InitializeBoard3()
        {
            Board3 = new CustomAIBoard("Dev4");

            Board3.ConfigurePort("port0", true);
            Board3.ConfigurePort("port1", false);

            Console.WriteLine("Board3 (AI board) initialized as Dev4.");
        }

        public void Dispose()
        {
            Board0?.Dispose();
            Board1?.Dispose();
            Board2?.Dispose();
            Board3?.Dispose();
        }
    }


}