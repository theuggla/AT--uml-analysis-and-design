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
    public abstract class GameTest
    {
        protected Game sut;
        protected Mock<ConsoleView> mockView;
        protected Mock<Board> mockBoard;
        protected Mock<AI> mockAI;
        protected Mock<Square> mockSquareOnePlayer;
        protected Mock<Square> mockSquareTwoPlayer;
        protected Mock<Square> mockSquareOneAI;
        protected Mock<Square> mockSquareTwoAI;

        public GameTest()
        {
            mockView = new Mock<ConsoleView>();
            mockBoard = new Mock<Board>(){ CallBase = true };
            mockAI = new Mock<AI>();

            mockSquareOnePlayer = new Mock<Square>(SquareValue.A1);
            mockSquareTwoPlayer = new Mock<Square>(SquareValue.A3);
            mockSquareOneAI = new Mock<Square>(SquareValue.A2);
            mockSquareTwoAI = new Mock<Square>(SquareValue.B1);

            Setup();

            sut = new Game(mockView.Object, mockBoard.Object, mockAI.Object);
        }

        public abstract void Setup();
    }
}