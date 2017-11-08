using System;
using Xunit;
using TicTacToe.Model;

namespace TicTacToeTest
{
    public class SquareTest
    {
        [Fact]
        public void PlayOnShouldMarkSquareAsTaken()
        {
            Square square = new Square();
            Assert.False(square.IsPlayedOn());
            square.PlayOn();
            Assert.True(square.IsPlayedOn());
        }
    }
}