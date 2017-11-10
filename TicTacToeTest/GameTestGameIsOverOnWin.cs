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
    public class GameIsOverOnWin : GameTest
    {
        public override void Setup()
        {;
            List<Square> wonBoard = (List<Square>)mockBoard.Object.GetBoard();
            wonBoard.ElementAt(0).PlayOn(PlayerSign.X);
            wonBoard.ElementAt(2).PlayOn(PlayerSign.O);
            wonBoard.ElementAt(3).PlayOn(PlayerSign.X);
            wonBoard.ElementAt(4).PlayOn(PlayerSign.X);
            wonBoard.ElementAt(5).PlayOn(PlayerSign.X);

           mockView.SetupSequence(view => view.GetSquareToPlayOn(It.IsAny<Board>()))
            .Returns(mockSquareOnePlayer.Object)
            .Returns(mockSquareTwoPlayer.Object);

            mockAI.SetupSequence(AI => AI.GetSquareToPlayOn(It.IsAny<Board>()))
            .Returns(mockSquareOneAI.Object)
            .Returns(mockSquareTwoAI.Object);

            mockBoard.Setup(board => board.IsFull()).Returns(false);
            mockBoard.Setup(board => board.GetBoard()).Returns(wonBoard);
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
    }
}