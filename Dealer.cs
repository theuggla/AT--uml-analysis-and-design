using System;

namespace TwentyOneCardGame
{
    /// <summary>
    /// A class to simulate a dealer in the TwentyOne Card Game.
    /// </summary>
    public class Dealer : TwentyOneParticipant
    {
        /// <summary>
        /// Initiates the Dealer with a name.
        /// </summary>
        public Dealer(string name = "The Dealer")
        :base(name)
        {}

    }
}