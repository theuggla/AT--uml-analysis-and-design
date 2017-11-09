using System;
using System.Collections.Generic;

namespace TicTacToe.Model
{
    public class AI
    {
        public Square GetSquareToPlayOn(Board board)
        {
            return new Square(SquareValue.A1);
        }
    }
}