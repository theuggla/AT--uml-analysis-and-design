namespace TwentyOneCardGame
{
    /// <summary>
    /// A class to simulate a player that can make bets in the TwentyOne Card Game.
    /// </summary>
    public class BettingPlayer : Player
    {
        private int _bank;
        private int _bettingAmount;
        private int _currentBet;

         /// <summary>
        /// Indicates whether or not the particpant
        /// is still in play.
        /// </summary>
        /// <returns>True if the participants points are below 21 and there are funds in the bank.</returns>
        public override bool InPlay
        {
            get
            {
                return this.Points < 21 && this._bank > 0;
            }
        }

        /// <summary>
        /// Initiates the BettingPlayer with a name and a limit.
        /// </summary>
        public BettingPlayer(string name = "A Player", int limit = 15)
        :base(name, limit)
        {
            this._bank = 100;
            this._bettingAmount = 25;
        }

        /// <summary>
        /// Plays a turn.
        /// </summary>
        /// <param name="deck">The deck to play the turn with.</param>
        public override bool PlayTurn(Deck deck)
        {
            this.MakeBet();
            return base.PlayTurn(deck);
        }

        /// <summary>
        /// Settle bet after the turn.
        /// </summary>
        /// <param name="won">A boolen to indicate whether the player won the round.</param>
        public override void SettleTurn(bool won)
        {
            if (won)
            {
                this._bank += this._currentBet;
            }
            else
            {
                this._bank -= this._currentBet;
            }

            this._currentBet = 0;
            base.SettleTurn(won);
        }

        /// <summary>
        /// Returns a string representation of the player and it's funds.
        /// </summary>
        /// <returns>The players name, hand, points and funds</returns>
        public override string ToString()
        {
            string funds = this._bank > 0 ? $"(${this._bank.ToString()})" : "OUT OF FUNDS!";
            return $"{this.Name}'s Bank: {funds} \n{base.ToString()}";
        }

        /// <summary>
        /// Makes a bet.
        /// </summary>
        private void MakeBet()
        {
            if ((this._bank - this._bettingAmount) >= 0) 
            {
                this._currentBet = this._bettingAmount;
            } 
            else 
            {
                this._currentBet = this._bank;
            }
        }
    }
}