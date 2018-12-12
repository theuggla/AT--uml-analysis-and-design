using System.Linq;
using System.Collections.Generic;

namespace TwentyOneCardGame
{
    /// <summary>
    /// A class to simulate a TwenytOne Card Game-Table, with a Dealer and a Deck.
    /// </summary>
    public class GameTable
    {
        private List<Card> _usedCards = new List<Card>();
        private Dealer _dealer;
        private Deck _deck;

        /// <summary>
        /// Initiates the table with a dealer and a deck.
        /// </summary>
        public GameTable()
        {
            this._dealer = new Dealer();
            this._deck = new Deck().Shuffle();
        }

        /// <summary>
        /// Deals out an initial Card to each of the players in the provided collection.
        /// </summary>
        /// <param name="players">A collection of players.</param>
        /// <returns>This.</returns>
        public GameTable DealInitialCards(IEnumerable<Player> players)
        {
            for (int i = 0; i < players.Count(); i++)
            {
                if (this._deck.CardsLeft == 1)
                {
                    this._deck.Shuffle();
                }
                    
                players.ElementAt(i).AddToHand((Card)this._deck.Deal());
            }
            
            return this;
        }

        /// <summary>
        /// Plays a round with a player and the dealer.
        /// </summary>
        /// <param name="player">The player to play the round with.</param>
        /// <returns>A strinf representation of the round's result.</returns>
        public string PlayRound(Player player)
        {
            string result;
            string winner;

            if (this.WinsTurn(player))
            {
                winner = player.Name;
            }
            else if (player.Points > 21)
            {
                winner = this._dealer.Name;
            }
            else
            {
                this._dealer.Limit = player.Points + 1;

                if (this.WinsTurn(this._dealer))
                {
                    winner = this._dealer.Name;
                }
                else
                {
                    winner = player.Name;
                }
            }

            // Record result.
            result = $"{player} \n{this._dealer} \n{winner} won!";

            // Return cards to used-pile.
            this._deck
            .ReturnToDeck(player.Hand
            .Concat(this._dealer.Hand)
            .ToList());

            // Settle turns.
            player.SettleTurn(winner == player.Name);
            this._dealer.SettleTurn((winner == this._dealer.Name));

            return result;
        }

        /// <summary>
        /// Plays a Turn with a Player or a Dealer.
        /// </summary>
        /// <param name="player">The participant to play the turn with.</param>
        /// <returns>Returns true if the provided participant wins the round with this turn.</returns>
        private bool WinsTurn(TwentyOneParticipant player)
        {
            return player.PlayTurn(this._deck);  
        }
    }
}