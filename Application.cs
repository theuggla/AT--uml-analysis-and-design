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
                List<Player> players = GetPlayers();
                PlayRounds(players, out int roundsPlayed);
                PrintResult(players, roundsPlayed);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Makes a list of players with different limits.
        /// </summary>
        /// <returns>Returns the List of players.</returns>
        private static List<Player> GetPlayers()
        {
            List<Player> players = new List<Player>();

            for (int i = 0, limit = 8; i < 5; i += 1, limit += 2) 
            {
                players.Add(new BettingPlayer($"Player #{(i + 1)}", limit)); //give them different limits
            }

            return players;
        }

        /// <summary>
        /// Plays loops of rounds with five players until
        /// only one has money left.
        /// </summary>
        private static void PlayRounds(List<Player> players, out int roundsPlayed)
        {
            var theGame = new GameTable();
            int round = 0;

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

            roundsPlayed = round;
        }

        /// <summary>
        /// Prints the result of the game.
        /// </summary>
        /// <param name="players">The players that played</param>
        /// <param name="roundsPlayed">The amount of rounds played.</param>
        private static void PrintResult(List<Player> players, int roundsPlayed)
        {
            if (players.Count > 0)
            {
                Console.WriteLine($"{players.ElementAt(0).Name} with the limit {players.ElementAt(0).Limit} is the last one with any money left!"); 
            }
            else                
            {
                Console.WriteLine($"No one is left with money.");
            }
                   
            Console.WriteLine($"{roundsPlayed} rounds were played.");
        }
    }
}