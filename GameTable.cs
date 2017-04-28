using System;
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
        /// Returns a string-representation of the dealer's hand at any given moment.
        /// </summary>
        public string DealerHand
        {
            get
            {
                return $"{this._dealer}";
            }
        }

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
                    this.ReshuffleDeck();
                }
                    
                players.ElementAt(i).AddToHand((Card)this._deck.Deal());
            }
            
            return this;
        }

        /// <summary>
        /// Plays a round with a player and the dealer.
        /// </summary>
        /// <param name="player">The player to play the round with.</param>
        /// <returns>The winner's name.</returns>
        public string PlayRound(Player player)
        {
            // Make sure the dealer's and the player's hands are empty and reset the dealers limit.
            this._dealer.Reset();
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

            // Return cards to used-pile.
            this._usedCards = this._usedCards
            .Concat(player.Hand)
            .Concat(this._dealer.Hand)
            .ToList();

            return winner;
        }

        /// <summary>
        /// Plays a Turn with a Player or a Dealer.
        /// </summary>
        /// <param name="player">The participant to play the turn with.</param>
        /// <returns>Returns true if the provided participant wins the round with this turn.</returns>
        private bool WinsTurn(TwentyOneParticipant player)
        {
            while (player.RequestCard() && !(this.IsWinner(player))) 
            {
                if (this._deck.CardsLeft == 1) 
                {
                    this.ReshuffleDeck();
                }
                
                player.AddToHand((Card)this._deck.Deal());
            }

            return (this.IsWinner(player));    
        }

        /// <summary>
        /// Checks if a participant has won the round.
        /// </summary>
        /// <param name="player">The player to check.</param>
        private bool IsWinner(TwentyOneParticipant player)
        {
            if (player.GetType() == typeof(Player)) 
            {
                return (player.Points == 21) || (player.Hand.Count() == 5 && player.Points < 21);
            } 
            else
            {
                return ((player.Points <= 21 && player.Points >= player.Limit));
            }
        }

        /// <summary>
        /// Returns all the used cards to the deck and reshuffles.
        /// </summary>
        /// <returns>This.</returns>
        private GameTable ReshuffleDeck()
        {
            this._deck.ReturnToDeck(this._usedCards);
            this._deck.Shuffle();

            return this;
        }
    }
}