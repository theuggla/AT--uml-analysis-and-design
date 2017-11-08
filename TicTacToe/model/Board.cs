using System;
using System.Linq;
using System.Collections.Generic;

namespace TicTacToe.Model
{
    public enum SquareValue
    {
        A1,
        A2,
        A3,
        B1,
        B2,
        B3,
        C1,
        C2,
        C3
    }

    public class Board
    {
        private List<Square> squares = new List<Square>();

        public virtual Square GetSquare(string nameOfSquare)
        {
            try
            {
                return squares.Where(x => x.Name.Equals(nameOfSquare, StringComparison.InvariantCultureIgnoreCase)).ElementAt(0);
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new NoSuchSquareException("Tries to retrieve nonexsistent square.");
            }
            
        }

        public void NewBoard()
        {
            foreach (string squareValue in Enum.GetNames(typeof(SquareValue)))
            {
                squares.Add(new Square(squareValue));
            }
        }

        public IEnumerable<Square> GetBoard()
        {
            return squares;
        }
    }
}