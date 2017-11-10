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
        private Mock<Square> mockSquareOnePlayer;
        private Mock<Square> mockSquareTwoPlayer;

        private Mock<Square> mockSquareOneAI;
        private Mock<Square> mockSquareTwoAI;

        public GameTestGameIsOverOnWin()
        {
            mockView = new Mock<ConsoleView>();
            mockBoard = new Mock<Board>();
            mockAI = new Mock<AI>();
            mockSquareOnePlayer = new Mock<Square>(SquareValue.C1);
            mockSquareTwoPlayer = new Mock<Square>(SquareValue.C2);
            mockSquareOneAI = new Mock<Square>(SquareValue.C3);
            mockSquareTwoAI = new Mock<Square>(SquareValue.A2);

            List<Square> wonBoard = GetFullCollectionOfSquares();
            wonBoard.ElementAt(0).PlayOn(PlayerSign.X);
            wonBoard.ElementAt(2).PlayOn(PlayerSign.O);
            wonBoard.ElementAt(3).PlayOn(PlayerSign.X);
            wonBoard.ElementAt(4).PlayOn(PlayerSign.X);
            wonBoard.ElementAt(5).PlayOn(PlayerSign.X);

            List<int[]> winningRows = GetWinningRows();

           mockView.SetupSequence(view => view.GetSquareToPlayOn(It.IsAny<Board>()))
            .Returns(mockSquareOnePlayer.Object)
            .Returns(mockSquareTwoPlayer.Object);

            mockAI.SetupSequence(AI => AI.GetSquareToPlayOn(It.IsAny<Board>()))
            .Returns(mockSquareOneAI.Object)
            .Returns(mockSquareTwoAI.Object);

            mockBoard.Setup(board => board.IsFull()).Returns(false);
            mockBoard.Setup(board => board.GetBoard()).Returns(wonBoard);
            mockBoard.Setup(board => board.WinningRows()).Returns(winningRows);

            sut = new Game(mockView.Object, mockBoard.Object, mockAI.Object);
        }

        [Fact]
        public void ShouldStopAskingForSquaresWhenGameIsOver()
        {
            sut.PlayGame();
            mockView.Verify(view => view.GetSquareToPlayOn(It.IsAny<Board>()), Times.Once());
            mockAI.Verify(ai => ai.GetSquareToPlayOn(It.IsAny<Board>()), Times.Never());
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