using System;
using System.Collections.Generic;

namespace TicTacToe.Model
{
    public class Board
    {
        private List<Square> squares = new List<Square>();
        public Square GetSquare(string nameOfSquare)
        {
            return new Square(nameOfSquare);
        }

        public void NewBoard()
        {
            squares.Add(new Square("a1"));
            squares.Add(new Square("a2"));
            squares.Add(new Square("a3"));
            squares.Add(new Square("b1"));
            squares.Add(new Square("b2"));
            squares.Add(new Square("b3"));
            squares.Add(new Square("c1"));
            squares.Add(new Square("c2"));
            squares.Add(new Square("c3"));
        }

        public IEnumerable<Square> GetBoard()
        {
            return squares;
        }
    }
}