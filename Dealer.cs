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

        /// <summary>
        /// Resets the participant by emptying the hand and setting the limit to 21.
        /// </summary>
        /// <returns>This.</returns>
        public override TwentyOneParticipant Reset()
        {
            base.Reset();
            this.Limit = 21;

            return this;
        }

    }
}