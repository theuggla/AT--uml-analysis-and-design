using System;
using System.Linq;
using System.Collections.Generic;

namespace TwentyOneCardGame
{
    /// <summary>
    /// An abstract class to simulate a participant in the TwenttOne Card Game.
    /// </summary>
    public abstract class TwentyOneParticipant
    {
        private List<Card> _hand = new List<Card>();
        private int _limit;

        public string Name {get; set;}
        
        /// <summary>
        /// The player's hand as a readonly list
        /// </summary>
        public  IReadOnlyList<Card> Hand
        {
            get
            {
                return _hand.AsReadOnly();
            }
        }

        /// <summary>
        /// The player's Points adjusted for aces - if the points are over 21, the value of any aces will be changed to 1 until
        /// the points are below 21, if possible.
        /// </summary>
        public int Points
        {
            get
            {
                return (this.GetPoints() > 21) ? this.AdjustPointsForAce().GetPoints() : this.GetPoints();
            }
        }

        /// <summary>
        /// The player's Limit for when to stop requesting cards.
        /// </summary>
        public int Limit
        {
            get
            {
                return this._limit;
            }

            set
            {
                if (value > 0 && value < 22)
                {
                    this._limit = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
            }
        }

        /// <summary>
        /// Indicates whether or not the particpant
        /// is still in play.
        /// </summary>
        /// <returns>True if the participants points are below 21.</returns>
        public virtual bool InPlay
        {
            get
            {
                return this.Points < 21;
            }
        }

        /// <summary>
        /// Sets the name of the participant.
        /// </summary>
        /// <param name="name">The name of the player.</param>
        public TwentyOneParticipant(string name, int limit = 21)
        {
            this.Name = name;
            this.Limit = limit;
        }

        /// <summary>
        /// Plays a turn.
        /// </summary>
        /// <param name="deck">The deck to play the turn with.</param>
        public virtual bool PlayTurn(Deck deck)
        {
            while (this.RequestCard() && !(this.IsWinner())) 
            {
                if (deck.CardsLeft == 1) 
                {
                    deck.Shuffle();
                }
                
                this.AddToHand((Card)deck.Deal());
            }

            return (this.IsWinner());
        }

        /// <summary>
        /// What to do when the turn is won or lost.
        /// </summary>
        /// <param name="won">A boolean to indicade whether the turn was won.</param>
        public abstract void SettleTurn(bool won);

        /// <summary>
        /// Resets the participant by emptying the hand.
        /// </summary>
        /// <returns>This.</returns>
        public virtual TwentyOneParticipant Reset()
        {
            this._hand.Clear();

            return this;
        }

        /// <summary>
        /// Adds a Card to the hand.
        /// </summary>
        /// <returns>This.</returns>
        public TwentyOneParticipant AddToHand(Card card)
        {
            this._hand.Add(card);

            return this;
        }

        /// <summary>
        /// A string representation of the participant.
        /// </summary>
        /// <returns>The participant's name, hand and points.</returns>
        public override string ToString()
        {
            string hand = !(this.Hand.Count > 0) ? "-" :
                String.Join(" ",
                    this.Hand
                    .Select(x => x.ToString())
                    .ToArray());

            string busted = this.Points < 22 ? "" : "BUSTED!";

            return $"{this.Name}: {hand} ({this.Points}) {busted}";
        }

        /// <summary>
        /// Checks if the participant has won the round.
        /// </summary>
        protected abstract bool IsWinner();

        /// <summary>
        /// Indicates whether or not the particpant
        /// should request another card.
        /// </summary>
        /// <returns>True if the player is in play.</returns>
        protected virtual bool RequestCard()
        {
            return this.InPlay && this.Points < this.Limit;
        }

        /// <summary>
        /// The sum of the player's hand.
        /// </summary>
        /// <returns>A sum of the cards on hand.</returns>
        private int GetPoints()
        {
            return this.Hand
            .Select(x => x.Value)
            .Sum();
        }

        /// <summary>
        /// Adjusts the player's acevalues - if the player's points are over 21, the value of any aces will be changed to 1 until
        /// the points are below 21, if possible.
        /// </summary>
        /// <returns>This.</returns>
        private TwentyOneParticipant AdjustPointsForAce()
        {
            for (int i = 0; i < this._hand.Count; i++)
            {
                Card card = this._hand.ElementAt(i);
                if (card.Rank == Rank.Ace && this.GetPoints() > 21)
                {
                    card.AceValue = 1;
                    this._hand.RemoveAt(i);
                    this._hand.Insert(i, card);
                }
            }
        
            return this;
        }

    }
}