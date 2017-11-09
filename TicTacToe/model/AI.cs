using System;
using System.Linq;
using System.Collections.Generic;

namespace TicTacToe.Model
{
    public class AI
    {
        public Square GetSquareToPlayOn(Board board)
        {
            return board.GetBoard().First(x => x.IsPlayedOn() == false);
        }
    }
}