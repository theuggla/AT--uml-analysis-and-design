using System;

namespace TicTacToe.Model
{
    public class Square
    {
        private bool taken;
        
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