using System;
using System.Text;
using System.IO;
using TicTacToe.Model;

namespace TicTacToe.View
{
    public class ConsoleView
    {
        public const string emptyBoardString = "A1 | A2 | A3\nB1 | B2 | B3\nC1 | C2 | C3";

        public void DisplayInstructions(string instructions)
        {
            Console.WriteLine(instructions);
        }

        public void DisplayBoard(Board board)
        {
            if (board.IsEmpty())
            {
                Console.WriteLine(emptyBoardString);
            }
            else
            {
                Console.WriteLine("X |  |  \n  |  |  \n  |  |  ");
            }
        }

        public string GetDisplaySquare(Square square)
        {
            if (square.IsPlayedOn())
            {
                return "| X |";
            }
            else
            {
                return "|   |";
            }
            
        }

        public Square GetSquareToPlayOn(Board board)
        {
            string squareValue = Console.ReadLine();
            Square square = null;

            try
            {
                square = board.GetSquare(squareValue);
            }
            catch (NoSuchSquareException)
            {
                Console.WriteLine("Square does not exist!");
                DisplayInstructions("Please pick an actual square: ");
                GetSquareToPlayOn(board);
            }

            return square;
        }
    }
}