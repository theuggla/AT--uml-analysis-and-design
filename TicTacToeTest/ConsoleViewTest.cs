using System;
using System.Text;
using System.IO;
using Xunit;
using TicTacToe.View;

namespace TicTacToeTest
{
    public class ConsoleViewTest
    {
        [Fact]
        public void DisplayInstructionsShouldOutputCorrectString()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                ConsoleView sut = new ConsoleView();
                sut.DisplayInstructions();
        
                string result = sw.ToString();
                Assert.Equal("Please choose a square to play on.", result);
            }
        }
    }
}
