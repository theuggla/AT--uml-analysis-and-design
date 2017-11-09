using System;
using Xunit;
using TicTacToe.Model;

namespace TicTacToeTest
{
    public class SquareTest
    {
        private Square sut = new Square(SquareValue.A1);

        [Fact]
        public void PlayOnShouldMarkSquareAsTaken()
        {
            Assert.False(sut.IsPlayedOn());
            sut.PlayOn();
            Assert.True(sut.IsPlayedOn());
        }

        [Fact]
        public void PlayOnShouldThrowExceptionIfSquareAlreadyTaken()
        {
            Assert.False(sut.IsPlayedOn());
            sut.PlayOn();

            try
            {
                sut.PlayOn();
                Assert.True(false, "Should not be able to play the same square twice");
            }
            catch (SquareAlreadyPlayedOnException)
            {
                Assert.True(true);
            }
        }

         [Fact]
        public void SignShouldReturnEmptyStringIfSquareIsNotPlayedOn()
        {
            Assert.Equal(sut.Sign, "");
        }


        [Fact]
        public void NameShouldReturnNameOfSquare()
        {
            Assert.Equal(sut.Name, SquareValue.A1);
        }

        [Fact]
        public void EqualsShouldReturnTrueIfNameIsEqual()
        {
            Assert.True(sut.Equals(new Square(SquareValue.A1)));
        }
    }
}