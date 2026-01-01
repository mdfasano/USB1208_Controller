using System;
using USB1208_Controller;

public class BoardManager
{
    public CustomBoard Board0 = new(0);
    public CustomBoard Board1 = new(1);
    public CustomBoard Board2 = new(2);

    public BoardManager()
    {
        InitializeBoards();
    }

    public void InitializeBoards()
    {
        InitializeBoard0();
        InitializeBoard1();
        InitializeBoard2();
    }

    //define what valid calls are to this board
    //this is the only board that supports voltage reads
    private void InitializeBoard0()
    {
        Board0 = new CustomBoard(0);
        // Additional configuration specific to Board0 if needed
        Console.WriteLine("Board0 initialized.");
    }

    //define what valid calls are to this board
    private void InitializeBoard1()
    {
        Board1 = new CustomBoard(1);
        // Additional configuration specific to Board1 if needed
        Console.WriteLine("Board1 initialized.");
    }

    //define what valid calls are to this board
    private void InitializeBoard2()
    {
        Board2 = new CustomBoard(2);
        // Additional configuration specific to Board2 if needed
        Console.WriteLine("Board2 initialized.");
    }

    // Methods to read from each board
    public string getVoltages()
    {
        return Board0.GetVoltage(channel);
    }

}
