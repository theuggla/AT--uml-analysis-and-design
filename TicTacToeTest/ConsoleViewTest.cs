using System;
using System.Text;
using System.IO;
using System.Linq;
using System.Collections.Generic;
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

                var stubBoard = new Mock<Board>();
                stubBoard.Setup(board => board.IsEmpty()).Returns(true);

                sut.DisplayBoard(stubBoard.Object);

                string expected = ConsoleView.emptyBoardString;
                string actual = sw.ToString();
                Assert.Contains(expected, actual);
            }
        }

        [Fact]
        public void DisplayBoardShouldDisplayBoardWhenNotEmpty()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                var stubBoard = new Mock<Board>();

                stubBoard.Setup(board => board.IsEmpty()).Returns(false);
                List<Square> squares = GetFullCollectionOfSquares();
                squares.First().PlayOn(PlayerSign.X);;
                stubBoard.Setup(board => board.GetBoard()).Returns(squares);

                sut.DisplayBoard(stubBoard.Object);

                string expected = "| X |   |   |\n|   |   |   |\n|   |   |   |";
                string actual = sw.ToString();
                Assert.Contains(expected, actual);
            }
        }

        [Fact]
        public void GetSquareToPlayOnShouldReturnChosenSquare()
        {
            using (var sw = new StringWriter())
            {
                using (var sr = new StringReader("a1"))
                {
                    var stubBoard = new Mock<Board>();
                    stubBoard.Setup(board => board.GetSquare("a1")).Returns(new Square(SquareValue.A1));

                    Console.SetOut(sw);
                    Console.SetIn(sr);
            
                    Square square = sut.GetSquareToPlayOn(stubBoard.Object);
                    Assert.True(new Square(SquareValue.A1).Equals(square));
                }
            }
        }

        [Fact]
        public void GetSquareToPlayOnShouldPrintErrorMessageIfSquareDoesNotExist()
        {
            using (var sw = new StringWriter())
            {
                using (var sr = new StringReader("a1"))
                {
                    var mockBoard = new Mock<Board>();
                    var mockSquare = new Mock<Square>(SquareValue.A1);

                    mockBoard.SetupSequence(board => board.GetSquare(It.IsAny<string>()))
                    .Throws(new NoSuchSquareException())
                    .Returns(mockSquare.Object);

                    Console.SetOut(sw);
                    Console.SetIn(sr);
            
                    Square square = sut.GetSquareToPlayOn(mockBoard.Object);
                    string result = sw.ToString();
                    Assert.Contains("Square does not exist!", result);
                }
            }
        }

        [Fact]
        public void GetSquareToPlayOnShouldPrintErrorMessageIfSquareIsAlreadyPlayedOn()
        {
            using (var sw = new StringWriter())
            {
                using (var sr = new StringReader("a1"))
                {
                    var mockBoard = new Mock<Board>();
                    var takenMockSquare = new Mock<Square>(SquareValue.A1);
                    var notTakenMockSquare = new Mock<Square>(SquareValue.A2);
                    
                    takenMockSquare.Setup(sq => sq.IsPlayedOn()).Returns(true);
                    notTakenMockSquare.Setup(sq => sq.IsPlayedOn()).Returns(false);
                    
                    mockBoard.SetupSequence(board => board.GetSquare(It.IsAny<string>()))
                    .Returns(takenMockSquare.Object)
                    .Returns(notTakenMockSquare.Object);

                    Console.SetOut(sw);
                    Console.SetIn(sr);
            
                    Square square = sut.GetSquareToPlayOn(mockBoard.Object);
                    string result = sw.ToString();
                    Assert.Contains("Square is already taken!", result);
                }
            }
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
    }
}
