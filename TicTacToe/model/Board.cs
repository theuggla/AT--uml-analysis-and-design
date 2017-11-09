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

        public Board()
        {
            NewBoard();
        }

        public virtual Square GetSquare(string nameOfSquare)
        {
            if (Enum.GetNames(typeof(SquareValue)).Contains(nameOfSquare.ToUpper()))
            {
                Enum.TryParse(nameOfSquare, out SquareValue squareValue);
                return squares.Find(x => x.Name.Equals(squareValue));
            }

            throw new NoSuchSquareException("Tries to retrieve nonexsistent square.");   
        }

        public virtual void NewBoard()
        {
            squares = new List<Square>();

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
            return squares.All(x => x.IsPlayedOn());
        }
    }
}