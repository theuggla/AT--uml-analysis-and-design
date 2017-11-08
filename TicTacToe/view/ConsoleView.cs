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

        public void DisplayBoard(string board)
        {
            Console.WriteLine(board);
        }
    }
}