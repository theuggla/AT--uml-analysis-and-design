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
            stubBoard.Setup(board => board.IsEmpty()).Returns(false);
            List<Square> squares = GetFullCollectionOfSquares();
            stubBoard.Setup(board => board.GetBoard()).Returns(squares);

            Square square = sut.GetSquareToPlayOn(stubBoard.Object);
            Assert.False(square.IsPlayedOn());
        }

        private List<Square> GetFullCollectionOfSquares()
        {
            List<Square> squares = new List<Square>();
            foreach (SquareValue squareValue in Enum.GetValues(typeof(SquareValue)))
            {
                squares.Add(new Square(squareValue));
            }
            return squares;
        }
    }
}