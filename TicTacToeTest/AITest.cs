using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;
using Moq;
using TicTacToe.Model;

namespace TicTacToeTest
{
    public class AITest
    {
        [Fact]
        public void GetSquareToPlayOnShouldReturnFirstSquareFromBoardThatIsNotPlayedOn()
        {
            AI sut = new AI();
            var stubBoard = new Mock<Board>();
            stubBoard.Setup(board => board.IsEmpty()).Returns(true);

            Square square = sut.GetSquareToPlayOn(stubBoard.Object);
            Assert.False(square.IsPlayedOn());
        }
    }
}