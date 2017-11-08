using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;
using TicTacToe.Model;

namespace TicTacToeTest
{
    public class BoardTest
    {
        [Fact]
        public void GetSquareShouldReturnSquareWithNameMatchingString()
        {
            Board sut = new Board();
            Square square = sut.GetSquare("a1");
            Assert.Equal(square.Name, "a1");
        }

        [Fact]
        public void NewBoardShouldSetCollectionOfSquares()
        {
            Board sut = new Board();
            Assert.True(sut.GetBoard().Count() == 0);
            sut.NewBoard();
            Assert.True(sut.GetBoard().Count() == 9);
        }

        [Fact]
        public void GetBoardShouldReturnEmptyCollectionOfSquaresWhenNotInitialized()
        {
            Board sut = new Board();
            Assert.True(sut.GetBoard().Count() == 0);
        }

        public void GetBoardShouldReturnFullCollectionOfSquaresWhenInitialized()
        {
            Board sut = new Board();
            List<Square> expected = new List<Square>();
            expected.Add(new Square("a1"));
            expected.Add(new Square("a2"));
            expected.Add(new Square("a3"));
            expected.Add(new Square("b1"));
            expected.Add(new Square("b2"));
            expected.Add(new Square("b3"));
            expected.Add(new Square("c1"));
            expected.Add(new Square("c2"));
            expected.Add(new Square("c3"));

            sut.NewBoard();
            List<Square> actual = (List<Square>) sut.GetBoard();
            expected.OrderBy(x => x.Name);
            actual.OrderBy(x => x.Name);

            if (expected.Count != actual.Count)
            {
                Assert.True(false);
            }

            for (int i = 0; i < expected.Count; i++)
            {
                if (!(expected.ElementAt(i).Equals(actual.ElementAt(i))))
                {
                    Assert.True(false);
                }
            }
        }
    }
}