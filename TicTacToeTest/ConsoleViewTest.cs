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
                string instructions = "Please choose a square to play on.";
                sut.DisplayInstructions(instructions);
        
                string result = sw.ToString();
                Assert.Contains(instructions, result);
            }
        }
    }
}
