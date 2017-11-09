using System;
using Xunit;
using TicTacToe.Model;

namespace TicTacToeTest
{
    public class AITest
    {
        [Fact]
        public void GetSquareToPlayOnShouldReturnSquareThatIsNotPlayedOn()
        {
            AI sut = new AI();
            Square square = sut.GetSquareToPlayOn();
            Assert.False(square.IsPlayedOn());
        }
    }
}