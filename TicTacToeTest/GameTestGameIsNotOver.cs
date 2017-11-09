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
    public class GameTest
    {
        private Game sut;
        private Mock<ConsoleView> mockView;
        private Mock<Board> mockBoard;
        private Mock<AI> mockAI;
        private Mock<Square> mockSquare;


        public GameTest()
        {
            mockView = new Mock<ConsoleView>();
            mockBoard = new Mock<Board>();
            mockAI = new Mock<AI>();
            mockSquare = new Mock<Square>(SquareValue.A1);

            mockView.Setup(view => view.GetSquareToPlayOn(It.IsAny<Board>())).Returns(mockSquare.Object);
            mockBoard.Setup(board => board.IsFull()).Returns(false);

            sut = new Game(mockView.Object, mockBoard.Object, mockAI.Object);
        }

        [Fact]
        public void ShouldDisplayWelcomeInstructionsOnce()
        {
            sut.PlayGame();
            mockView.Verify(view => view.DisplayInstructions("Welcome to TicTacToe!"), Times.Once());
        }

        [Fact]
        public void ShouldDisplayBoardAtLeastOnce()
        {
            sut.PlayGame();
            mockView.Verify(view => view.DisplayBoard(It.IsAny<Board>()), Times.AtLeastOnce());
        }

        [Fact]
        public void ShouldAskUserForSquareToPlayLeastOnce()
        {
            sut.PlayGame();
            mockView.Verify(view => view.GetSquareToPlayOn(It.IsAny<Board>()), Times.AtLeastOnce());
        }

        [Fact]
        public void ShouldPlayOnThatSquare()
        {
            sut.PlayGame();
            mockSquare.Verify(square => square.PlayOn(It.IsAny<PlayerSign>()), Times.AtLeastOnce());
        }

        [Fact]
        public void IsGameOverShouldReturnFalseIfBoardIsNotFullAndThereIsNoWinner()
        {
            bool result = sut.IsGameOver();
            Assert.False(result);
        }
    }
}