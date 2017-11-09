using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using TicTacToe.Model;

namespace TicTacToe.View
{
    public class ConsoleView
    {
        public const string emptyBoardString = "A1 | A2 | A3\nB1 | B2 | B3\nC1 | C2 | C3";

        public virtual void DisplayInstructions(string instructions)
        {
            Console.WriteLine(instructions);
        }

        public virtual void DisplayBoard(Board board)
        {
            if (board.IsEmpty())
            {
                Console.WriteLine(emptyBoardString);
            }
            else
            {
                Console.Clear();
                List<Square> squares = (List<Square>)board.GetBoard();

                string row1 = GetDisplayRow(squares.ElementAt(0), squares.ElementAt(1), squares.ElementAt(2));
                string row2 = GetDisplayRow(squares.ElementAt(3), squares.ElementAt(4), squares.ElementAt(5));
                string row3 = GetDisplayRow(squares.ElementAt(6), squares.ElementAt(7), squares.ElementAt(8));

                Console.WriteLine($"{row1}\n{row2}\n{row3}");
            }
        }

        private string GetDisplayRow(params Square[] squares)
        {
            string row = "|";
            foreach (Square square in squares)
            {
                row += GetDisplaySquare(square);
            }

            return row;
        }

        private string GetDisplaySquare(Square square)
        {
            if (square.IsPlayedOn())
            {
                return $" {square.Sign.ToString()} |";
            }
            else
            {
                return "   |";
            }
            
        }

        public virtual Square GetSquareToPlayOn(Board board)
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