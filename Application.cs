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
                Player[] players = {
                    new Player("Karlsson"), 
                    new Player("Inte Karlsson"), 
                    new Player("Karlsson #2"), 
                    new Player("Karlsson #3"), 
                    new Player("Karlsson #4"), 
                    new Player("Karlsson #5"),
                    new Player("Karlsson #6"), 
                    new Player("Karlsson #7"), 
                    new Player("Karlsson #8"), 
                    new Player("Karlsson #9"),
                    new Player("Karlsson #10"), 
                    new Player("Karlsson #11"), 
                    new Player("Karlsson #12")};
                var game = new GameTable();
                game.DealInitialCards(players);

                for (int i = 0; i < players.Length; i++)
                {
                    Console.WriteLine(players[i]);
                }

                for (int i = 0; i < players.Length; i++)
                {
                    string winner = game.PlayRound(players[i]);
                    Console.WriteLine(players[i]);
                    Console.WriteLine(game.DealerHand);
                    Console.WriteLine($"{winner} won!");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}