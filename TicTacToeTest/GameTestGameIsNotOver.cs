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
    public class GameIsNotOver : GameTest
    {
        public override void Setup()
        {
            mockView.SetupSequence(view => view.GetSquareToPlayOn(It.IsAny<Board>()))
            .Returns(mockSquareOnePlayer.Object)
            .Returns(mockSquareTwoPlayer.Object);

            mockAI.SetupSequence(AI => AI.GetSquareToPlayOn(It.IsAny<Board>()))
            .Returns(mockSquareOneAI.Object)
            .Returns(mockSquareTwoAI.Object);

            mockBoard.SetupSequence(board => board.IsFull())
            .Returns(false)
            .Returns(false)
            .Returns(true);
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
    }
}