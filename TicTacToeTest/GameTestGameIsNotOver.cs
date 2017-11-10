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
        private Mock<Square> mockSquareOnePlayer;
        private Mock<Square> mockSquareTwoPlayer;
        private Mock<Square> mockSquareOneAI;
        private Mock<Square> mockSquareTwoAI;

        public GameTestGameIsNotOver()
        {
            mockView = new Mock<ConsoleView>();
            mockBoard = new Mock<Board>();
            mockAI = new Mock<AI>();
            mockSquareOnePlayer = new Mock<Square>(SquareValue.A1);
            mockSquareTwoPlayer = new Mock<Square>(SquareValue.A3);
            mockSquareOneAI = new Mock<Square>(SquareValue.A2);
            mockSquareTwoAI = new Mock<Square>(SquareValue.B1);

            List<int[]> winningRows = GetWinningRows();

            mockView.SetupSequence(view => view.GetSquareToPlayOn(It.IsAny<Board>()))
            .Returns(mockSquareOnePlayer.Object)
            .Returns(mockSquareTwoPlayer.Object);

            mockAI.SetupSequence(AI => AI.GetSquareToPlayOn(It.IsAny<Board>()))
            .Returns(mockSquareOneAI.Object)
            .Returns(mockSquareTwoAI.Object);

            mockBoard.SetupSequence(board => board.IsFull())
            .Returns(false)
            .Returns(true);

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
        public void ShouldAskUserForSquareToPlayLeastTwiceWhenGameIsNotOver()
        {
            sut.PlayGame();
            mockView.Verify(view => view.GetSquareToPlayOn(It.IsAny<Board>()), Times.AtLeast(2));
        }

        [Fact]
        public void ShouldPlayOnThatPlayerSquare()
        {
            sut.PlayGame();
            mockSquareOnePlayer.Verify(square => square.PlayOn(It.IsAny<PlayerSign>()), Times.AtLeastOnce());
        }

        [Fact]
        public void ShouldAskAIForSquareIfGameIsNotOver()
        {
            sut.PlayGame();
            mockAI.Verify(ai => ai.GetSquareToPlayOn(It.IsAny<Board>()), Times.AtLeastOnce());
        }

        [Fact]
        public void ShouldPlayOnThatAISquare()
        {
            sut.PlayGame();
            mockSquareOneAI.Verify(square => square.PlayOn(It.IsAny<PlayerSign>()), Times.AtLeastOnce());
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