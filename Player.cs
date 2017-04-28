using System;

namespace TwentyOneCardGame
{
    /// <summary>
    /// A class to simulate a player in the TwentyOne Card Game.
    /// </summary>
    public class Player : TwentyOneParticipant
    {
        /// <summary>
        /// Initiates the Player with a name and a limit.
        /// </summary>
        public Player(string name = "A Player", int limit = 15)
        :base(name, limit)
        {}

    }
}