using System;
using System.Collections.Generic;

namespace TicTacToe.Model
{
    public class Board
    {
        public Square GetSquare(string nameOfSquare)
        {
            return new Square(nameOfSquare);
        }

        public IEnumerable<Square> GetBoard()
        {
            throw new NotImplementedException();
        }
    }
}