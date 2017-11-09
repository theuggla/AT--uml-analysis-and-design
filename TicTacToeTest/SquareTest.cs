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
            sut.PlayOn(PlayerSign.X);
            Assert.True(sut.IsPlayedOn());
        }

        [Fact]
        public void PlayOnShouldThrowExceptionIfSquareAlreadyTaken()
        {
            Assert.False(sut.IsPlayedOn());
            sut.PlayOn(PlayerSign.X);

            try
            {
                sut.PlayOn(PlayerSign.X);
                Assert.True(false, "Should not be able to play the same square twice");
            }
            catch (SquareAlreadyPlayedOnException)
            {
                Assert.True(true);
            }
        }

        [Fact]
        public void SignShouldReturnNoneIfSquareIsNotPlayedOn()
        {
            Assert.Equal(sut.Sign, PlayerSign.None);
        }

        [Fact]
        public void SignShouldReturnSignIfSquareIsPlayedOn()
        {
            sut.PlayOn(PlayerSign.X);
            Assert.False(sut.Sign.Equals(PlayerSign.None));
        }

        [Fact]
        public void SignShouldReturnDifferentSignIfSquareIsPlayedOnByDifferentPlayer()
        {
            Square otherSquare = new Square(SquareValue.B2);
            sut.PlayOn(PlayerSign.X);
            otherSquare.PlayOn(PlayerSign.O);
            PlayerSign signOne = sut.Sign;
            PlayerSign signTwo = sut.Sign;
            Assert.False(signOne.Equals(signTwo));
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