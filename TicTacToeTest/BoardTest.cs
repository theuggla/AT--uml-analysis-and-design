using System;
using Xunit;
using TicTacToe.Model;

namespace TicTacToeTest
{
    public class BoardTest
    {
        [Fact]
        public void GetSquareShouldReturnSquareWithNameMatchingString()
        {
            Board sut = new Board();
            Square square = sut.GetSquare("a1");
            Assert.Equal(square.Name, "a1");
        }
    }
}