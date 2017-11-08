using System;

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
            taken = true;
        }

        public bool IsPlayedOn()
        {
            return taken;
        }
    }
}