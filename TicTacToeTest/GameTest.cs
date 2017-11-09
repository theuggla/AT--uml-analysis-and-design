using System;
using System.IO;
using System.Text;
using System.Linq;
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

        public GameTest()
        {
            mockView = new Mock<ConsoleView>();
            mockBoard = new Mock<Board>();
            mockAI = new Mock<AI>();

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
            Assert.Equal(mockBoard.Object.GetBoard().ToList().Exists(x => x.IsPlayedOn()), true);
        }
    }
}