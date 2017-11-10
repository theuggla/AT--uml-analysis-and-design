using System;
using System.IO;
using System.Text;
using Xunit;
using Moq;
using TicTacToe.Model;
using TicTacToe.View;
using TicTacToe.Controller;

namespace TicTacToeTest
{
    public class GameTestGameIsOver
    {
        private Game sut;
        private Mock<ConsoleView> mockView;
        private Mock<Board> mockBoard;
        private Mock<AI> mockAI;
        private Mock<Square> mockSquare;


        public GameTestGameIsOver()
        {
            mockView = new Mock<ConsoleView>();
            mockBoard = new Mock<Board>();
            mockAI = new Mock<AI>();
            mockSquare = new Mock<Square>(SquareValue.A1);

            mockView.Setup(view => view.GetSquareToPlayOn(It.IsAny<Board>())).Returns(mockSquare.Object);
            mockBoard.Setup(board => board.IsFull()).Returns(true);

            sut = new Game(mockView.Object, mockBoard.Object, mockAI.Object);
        }

        [Fact]
        public void IsGameOverShouldReturnTrueIfBoardIsFull()
        {
            bool result = sut.IsGameOver();
            Assert.True(result);
        }
    }
}