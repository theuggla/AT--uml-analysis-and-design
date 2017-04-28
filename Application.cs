using System;
using System.Collections.Generic;

namespace TwentyOneCardGame
{
    /// <summary>
    /// A console application for simulating a twenty-one card game.
    /// </summary>
    public class Application
    {
        /// <summary>
        /// Runs the application.
        /// </summary>
        public static void Run()
        {

            try
            {
                var player = new TwentyOneParticipant("Karlsson");
                Console.WriteLine(player.Points);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}