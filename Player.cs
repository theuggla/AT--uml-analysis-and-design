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

        /// <summary>
        /// Reset hand after the turn.
        /// </summary>
        /// <param name="won">Indicate whether the player won the round.</param>
        public override void SettleTurn(bool won)
        {
            this.Reset();
        }

        /// <summary>
        /// Checks if the player has won the round.
        /// </summary>
        protected override bool IsWinner()
        {
            return (this.Points == 21) || (this.Hand.Count == 5 && this.Points < 21);
        }

    }
}