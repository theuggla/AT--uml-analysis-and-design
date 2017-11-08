using System;
using Xunit;
using TicTacToe.Model;

namespace TicTacToeTest
{
    public class SquareTest
    {
        private Square sut = new Square("a1");

        [Fact]
        public void PlayOnShouldMarkSquareAsTaken()
        {
            Assert.False(sut.IsPlayedOn());
            sut.PlayOn();
            Assert.True(sut.IsPlayedOn());
        }

        [Fact]
        public void NameShouldReturnNameOfSquare()
        {
            Assert.Equal(sut.Name, "a1");
        }

        [Fact]
        public void EqualsShouldReturnTrueIfNameIsEqual()
        {
            Assert.True(sut.Equals(new Square("a1")));
        }

        [Fact]
        public void EqualsShouldReturnTrueIfNameIsEqualIgnoringCase()
        {
            Assert.True(sut.Equals(new Square("A1")));
        }
    }
}