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
        /// Checks if the dealer has won the round.
        /// </summary>
        protected override bool IsWinner()
        {
            return ((this.Points <= 21 && this.Points >= this.Limit));
        }

        /// <summary>
        /// Reset the dealer after the turn.
        /// </summary>
        /// <param name="won">A boolean to indicade whether the turn was won.</param>
        public override void SettleTurn(bool won)
        {
            this.Reset();
        }

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