using System;
using System.Collections.Generic;

namespace TicTacToe.Model
{
    public class Square
    {
        private bool taken;
        public SquareValue Name {get;}
        public PlayerSign Sign {get; set;}

        public Square(SquareValue name)
        {
            this.Name = name;
            this.Sign = PlayerSign.None;
        }

        public void PlayOn()
        {
            if (this.IsPlayedOn())
            {
                throw new SquareAlreadyPlayedOnException("Trying to play on already taken square.");
            }
            
            this.taken = true;
            this.Sign = PlayerSign.X;
        }

        public virtual bool IsPlayedOn()
        {
            return this.taken;
        }

        public bool Equals(Square x)
        {
            if (Object.ReferenceEquals(x, this)) return true;
            return x != null && x.Name.Equals(this.Name);
        }
    }
}