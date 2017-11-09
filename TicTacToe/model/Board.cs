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

    public enum PlayerSign
    {
        X,
        O,
        None
    }

    public class Board
    {
        private List<Square> squares = new List<Square>();

        public virtual Square GetSquare(string nameOfSquare)
        {
            Enum.TryParse(nameOfSquare, out SquareValue squareValue);
            Square square = squares.Find(x => x.Name.Equals(squareValue)) ?? throw new NoSuchSquareException("Tries to retrieve nonexsistent square.");
            
            return square;
            
        }

        public void NewBoard()
        {
            foreach (SquareValue squareValue in Enum.GetValues(typeof(SquareValue)))
            {
                squares.Add(new Square(squareValue));
            }
        }

        public virtual IEnumerable<Square> GetBoard()
        {
            return squares;
        }

        public virtual bool IsEmpty()
        {
            return !squares.Exists(x => x.IsPlayedOn());
        }

        public virtual bool IsFull()
        {
            return true;
        }
    }
}