using System;
using System.Text;
using System.IO;
using TicTacToe.Model;

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

        public Square GetSquareToPlayOn(Board board)
        {
            string squareValue = Console.ReadLine();
            return board.GetSquare(squareValue);
        }
    }
}