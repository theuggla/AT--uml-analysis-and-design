using System;
using System.Collections.Generic;

namespace TicTacToe.Model
{
    public class Square
    {
        private bool taken;
        public string Name {get;}

        public Square(string name)
        {
            this.Name = name;
        }

        public void PlayOn()
        {
            this.taken = true;
        }

        public virtual bool IsPlayedOn()
        {
            return this.taken;
        }

        public bool Equals(Square x)
        {
            if (Object.ReferenceEquals(x, this)) return true;
            return x != null && x.Name.Equals(this.Name, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}