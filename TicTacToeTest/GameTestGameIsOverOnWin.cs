using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Xunit;
using Moq;
using TicTacToe.Model;
using TicTacToe.View;
using TicTacToe.Controller;

namespace TicTacToeTest
{
    public class GameTestGameIsOverOnWin
    {
        private Game sut;
        private Mock<ConsoleView> mockView;
        private Mock<Board> mockBoard;
        private Mock<AI> mockAI;
        private Mock<Square> mockSquare;

        public GameTestGameIsOverOnWin()
        {
            mockView = new Mock<ConsoleView>();
            mockBoard = new Mock<Board>();
            mockAI = new Mock<AI>();
            mockSquare = new Mock<Square>(SquareValue.A1);

            List<Square> wonBoard = GetFullCollectionOfSquares();
            wonBoard.ElementAt(0).PlayOn(PlayerSign.X);
            wonBoard.ElementAt(1).PlayOn(PlayerSign.X);
            wonBoard.ElementAt(2).PlayOn(PlayerSign.X);

            mockView.Setup(view => view.GetSquareToPlayOn(It.IsAny<Board>())).Returns(mockSquare.Object);
            mockBoard.Setup(board => board.IsFull()).Returns(false);
            mockBoard.Setup(board => board.GetBoard()).Returns(wonBoard);

            sut = new Game(mockView.Object, mockBoard.Object, mockAI.Object);
        }

        [Fact]
        public void IsGameOverShouldReturnTrueIfPlayerHasWon()
        {
            bool result = sut.IsGameOver();
            Assert.True(result);
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