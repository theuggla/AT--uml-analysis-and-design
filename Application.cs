using System;
using System.Text;
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
                Console.WriteLine("Hi! Yes it works.");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}