using System;
using System.Text;
using System.IO;
using Xunit;
using Moq;
using TicTacToe.View;
using TicTacToe.Model;

namespace TicTacToeTest
{
    public class ConsoleViewTest
    {
        private ConsoleView sut = new ConsoleView();

        [Fact]
        public void DisplayInstructionsShouldOutputCorrectString()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                string instructions = "Please choose a square to play on.";
                sut.DisplayInstructions(instructions);
        
                string result = sw.ToString();
                Assert.Contains(instructions, result);
            }
        }

        [Fact]
        public void DisplayBoardShouldDisplayBoardWhenEmpty()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                string board = "A1 | A2 | A3\nB1 | B2 | B3\nC1 | C2 | C3";
                sut.DisplayBoard(board);

                string actual = sw.ToString();
                Assert.Contains(board, actual);
            }
        }

        [Fact]
        public void GetSquareToPlayOnShouldReturnChosenSquare()
        {
            using (var sw = new StringWriter())
            {
                using (var sr = new StringReader("a1"))
                {
                    var mockBoard = new Mock<Board>();
                    mockBoard.Setup(board => board.GetSquare("a1")).Returns(new Square("a1"));

                    Console.SetOut(sw);
                    Console.SetIn(sr);
            
                    Square square = sut.GetSquareToPlayOn(mockBoard.Object);
                    Assert.True(new Square("A1").Equals(square));
                }
            }
        }
    }
}
