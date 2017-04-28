using System;
using System.Linq;
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
        /// Plays loops of rounds with five players until
        /// only one has money left.
        /// </summary>
        public static void Run()
        {

            try
            {
                List<Player> players = new List<Player>();
                var theGame = new GameTable();
                int round = 0;

                for (int i = 0, limit = 8; i < 5; i += 1, limit += 2) 
                {
                    players.Add(new BettingPlayer($"Player #{(i + 1)}", limit)); //give them different limits
                }

                while (players.Count > 1) 
                {
                    round++;

                    var originalColor = Console.BackgroundColor;
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"Round {round}");
                    Console.BackgroundColor = originalColor;

                    theGame.DealInitialCards(players);

                    foreach (Player player in players)
                    {
                        Console.WriteLine(theGame.PlayRound(player));
                        Console.WriteLine();
                    }

                    players = players
                    .Where(x => x.InPlay)
                    .ToList();

                    Console.WriteLine();
                }

                // Print result.
                if (players.Count > 0)
                {
                    Console.WriteLine($"{players.ElementAt(0).Name} with the limit {players.ElementAt(0).Limit} is the last one with any money left!"); 
                }
                else
                {
                    Console.WriteLine($"No one is left with money.");
                }
                   
                Console.WriteLine($"{round} rounds were played.");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}