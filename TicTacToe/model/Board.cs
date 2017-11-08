using System;

namespace TicTacToe.Model
{
    public class Board
    {
        public Square GetSquare(string nameOfSquare)
        {
            return new Square(nameOfSquare);
        }
    }
}