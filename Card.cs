using System;

namespace TwentyOneCardGame
{
    /// <summary>
    /// A Card struct with suit, rank and changeble Ace-value.
    /// </summary>
    public struct Card : IModifiableAceValue, IEquatable<Card>
    {
        private int? _aceValue;
        public readonly Suit Suit;
        public readonly Rank Rank;

        /// <summary>
        /// Returns the value of the card.
        /// </summary>
        public int Value 
        {
            get
            {
                return this.AceValue ?? (int)this.Rank;
            }
        }


        /// <summary>
        /// Keeps track of wether the ace is counted as 1 or 14. Returns null if the Rank is not Ace.
        /// </summary>
        public int? AceValue 
        {
            get
            {
                return this._aceValue;
            }
            set
            {
                if (!(this.Rank == Rank.Ace)) 
                {
                    throw new InvalidOperationException("Cannot set AceValue for Card of other Rank than Ace.");
                } 
                else if ((value == 1 || value == 14))
                {
                    this._aceValue = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        /// <summary>
        /// Initializes a card witha suit and a rank.
        /// AceValue will start out as 14 if card is an Ace.
        /// </summary>
        public Card(Suit suit, Rank rank)
        {
            this._aceValue = null;
            
            this.Suit = suit;
            this.Rank = rank;

            if (this.Rank == Rank.Ace)
            {
                this.AceValue = (int)this.Rank;
            }
        }

        /// <summary>
        /// Compares two Card's ranks.
        /// </summary>
        /// <param name="other"> The card to compare with.</param>
        ///<returns>1 if value of other Rank is larger than this Rank, 0 if equal, -1 if this is larger than other.</returns>
        public int CompareTo(Card other)
        {
            return this.Value.CompareTo(other.Value);
        }

        ///<summary>
        ///Returns a string representation of the card.
        ///</summary>
        ///<returns>Rank and suit as a string.</returns>
        public override string ToString()
        {
            string rank = (int)this.Rank > 10 ? this.Rank.ToString()[0].ToString() : ((int)this.Rank).ToString();
            char suit = (char)this.Suit;

            return $"{rank}{suit}";
        }

        ///<summary>
        ///Checks if this card equals another card.
        ///</summary>
        ///<param name="card"> The card to compare to.</param>
        ///<returns>True if the other card has the same suit and rank.</returns>
        public bool Equals(Card card)
        {    
            return this.Rank == card.Rank && this.Suit == card.Suit;
        }
    }
}