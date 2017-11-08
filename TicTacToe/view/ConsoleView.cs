using System;
using System.Text;
using System.IO;

namespace TicTacToe.View
{
    public class ConsoleView
    {
        public void DisplayInstructions(string instructions)
        {
            Console.WriteLine(instructions);
        }

        public void DisplayBoard()
        {
            Console.WriteLine("A1 | A2 | A3\nB1 | B2 | B3\nC1 | C2 | C3");
        }
    }
}