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
            Square square = new Square("a1");
            Assert.False(square.IsPlayedOn());
            square.PlayOn();
            Assert.True(square.IsPlayedOn());
        }

        [Fact]
        public void NameShoulReturnNameOfSquare()
        {
            Square square = new Square("a1");
            Assert.Equal(square.Name, "a1");
        }
    }
}