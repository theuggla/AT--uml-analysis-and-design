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
    public class GameIsOverOnDraw: GameTest
    {
        public override void Setup()
        {
            mockView.Setup(view => view.GetSquareToPlayOn(It.IsAny<Board>())).Returns(mockSquareOnePlayer.Object);
            mockBoard.Setup(board => board.IsFull()).Returns(true);
        }

        [Fact]
        public void IsGameOverShouldReturnTrueIfBoardIsFull()
        {
            bool result = sut.IsGameOver();
            Assert.True(result);
        }

        [Fact]
        public void ShouldDisplayDrawMessage()
        {
            sut.PlayGame();
            mockView.Verify(view => view.DisplayInstructions("It's a draw!"), Times.Once());
        }
    }
}