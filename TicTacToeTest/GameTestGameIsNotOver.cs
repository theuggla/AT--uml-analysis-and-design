using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using TicTacToe.Model;
using TicTacToe.View;
using TicTacToe.Controller;

namespace TicTacToeTest
{
    public class GameTestGameIsNotOver
    {
        private Game sut;
        private Mock<ConsoleView> mockView;
        private Mock<Board> mockBoard;
        private Mock<AI> mockAI;
        private Mock<Square> mockSquarePlayer;
        private Mock<Square> mockSquareAI;

        public GameTestGameIsNotOver()
        {
            mockView = new Mock<ConsoleView>();
            mockBoard = new Mock<Board>();
            mockAI = new Mock<AI>();
            mockSquarePlayer = new Mock<Square>(SquareValue.A1);
            mockSquareAI = new Mock<Square>(SquareValue.A2);

            List<int[]> winningRows = GetWinningRows();

            mockView.Setup(view => view.GetSquareToPlayOn(It.IsAny<Board>())).Returns(mockSquarePlayer.Object);
            mockAI.Setup(AI => AI.GetSquareToPlayOn(It.IsAny<Board>())).Returns(mockSquareAI.Object);
            mockBoard.Setup(board => board.IsFull()).Returns(false);
            mockBoard.Setup(board => board.GetBoard()).Returns(GetFullCollectionOfSquares());
            mockBoard.Setup(board => board.WinningRows()).Returns(winningRows);

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
            mockSquarePlayer.Verify(square => square.PlayOn(It.IsAny<PlayerSign>()), Times.AtLeastOnce());
        }

        [Fact]
        public void ShouldAskAIForSquareIfGameIsNotOver()
        {
            sut.PlayGame();
            mockSquareAI.Verify(square => square.PlayOn(It.IsAny<PlayerSign>()), Times.AtLeastOnce());
        }

        [Fact]
        public void IsGameOverShouldReturnFalseIfBoardIsNotFull()
        {
            bool result = sut.IsGameOver();
            Assert.False(result);
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

        private List<int[]> GetWinningRows()
        {
            List<int[]> winningRows = new List<int[]>();
            winningRows.Add(new int[] {0, 1, 2});
            winningRows.Add(new int[] {3, 4, 5});
            winningRows.Add(new int[] {6, 7, 8});
            winningRows.Add(new int[] {0, 3, 6});
            winningRows.Add(new int[] {1, 4, 7});
            winningRows.Add(new int[] {2, 5, 8});
            winningRows.Add(new int[] {0, 4, 8});
            winningRows.Add(new int[] {6, 4, 2});
            return winningRows;
        }
    }
}