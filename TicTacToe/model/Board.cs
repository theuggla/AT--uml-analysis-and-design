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
        private List<int[]> winningRows = new List<int[]>();

        public Board()
        {
            this.NewBoard();
            this.SetWinningRows();
        }

        public virtual List<int[]> WinningRows()
        {
            return this.winningRows;
        }

        public virtual Square GetSquare(string nameOfSquare)
        {
            if (Enum.GetNames(typeof(SquareValue)).Contains(nameOfSquare.ToUpper()))
            {
                SquareValue squareValue = (SquareValue) Enum.Parse(typeof(SquareValue), nameOfSquare, true);     
                return this.squares.Find(x => x.Name.Equals(squareValue));
            }

            throw new NoSuchSquareException("Tries to retrieve nonexsistent square.");   
        }

        public virtual void NewBoard()
        {
            this.squares = new List<Square>();

            foreach (SquareValue squareValue in Enum.GetValues(typeof(SquareValue)))
            {
                this.squares.Add(new Square(squareValue));
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

        public virtual void SetWinningRows()
        {
            this.winningRows.Add(new int[] {0, 1, 2});
            this.winningRows.Add(new int[] {3, 4, 5});
            this.winningRows.Add(new int[] {6, 7, 8});
            this.winningRows.Add(new int[] {0, 3, 6});
            this.winningRows.Add(new int[] {1, 4, 7});
            this.winningRows.Add(new int[] {2, 5, 8});
            this.winningRows.Add(new int[] {0, 4, 8});
            this.winningRows.Add(new int[] {6, 4, 2});
        }
    }
}