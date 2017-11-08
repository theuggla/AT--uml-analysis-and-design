using System;
using System.Collections.Generic;

namespace TicTacToe.Model
{
    public enum SquareValue
    {
        A1,
        A2,
        A3,
        B1,
        B2,
        B3,
        C1,
        C2,
        C3
    }

    public class Board
    {
        private List<Square> squares = new List<Square>();
        public Square GetSquare(string nameOfSquare)
        {
            return new Square(nameOfSquare);
        }

        public void NewBoard()
        {
            foreach (string squareValue in Enum.GetNames(typeof(SquareValue)))
            {
                squares.Add(new Square(squareValue));
            }
        }

        public IEnumerable<Square> GetBoard()
        {
            return squares;
        }
    }
}