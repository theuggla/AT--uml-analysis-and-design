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
                    new BettingPlayer("Karlsson")
                };
                var game = new GameTable();
                game.DealInitialCards(players);

                while (players[0].InPlay)
                {
                    string result = game.PlayRound(players[0]);
                    Console.WriteLine(result);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}