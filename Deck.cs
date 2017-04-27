using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace TwentyOneCardGame
{
    /// <summary>
    /// A Deck class to simulate a Card Deck.
    /// </summary>
    public class Deck
    {
        private List<Card> _cardsInPlay = new List<Card>();
        private List<Card> _usedCards = new List<Card>();
        private Stack<Card> _unusedCards = new Stack<Card>();

        /// <summary>
        /// Initates a Deck with 52 cards.
        /// </summary>
        public Deck()
        {
            foreach (Rank r in Enum.GetValues(typeof(Rank))) 
            {
                 foreach (Suit s in Enum.GetValues(typeof(Suit))) 
                 {
                    this._unusedCards.Push(new Card(s, r));
                 }
            }
        }

        /// <summary>
        /// Returns a String-representation of the Deck.
        /// </summary>
        /// <returns>A sequence of the string representations of all the cards in the unused part of the deck.</returns>
        public override string ToString()
        {
            StringBuilder deckString = new StringBuilder();

            foreach (Card card in this._unusedCards)
            {
                deckString.Append(card);
                deckString.Append(" ");
            }
            
            return deckString.ToString();
        }

        /// <summary>
        /// Shuffles the deck. If some of the cards are in the used cards-pile, reshuffles them into the unused pile.
        /// </summary>
        /// <returns>Returns the deck.</returns>
        public Deck Shuffle()
        {
            Card[] _deck = this._unusedCards
                    .Concat(this._usedCards)
                    .ToArray();

            Random random = new Random();

            for (int i = _deck.Length - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                Card temp = _deck[i];
                _deck[i] = _deck[j];
                _deck[j] = temp;
            }

            this._unusedCards = new Stack<Card>(_deck);

            return this;
        }

        /// <summary>
        /// Deals the top card from the unused pile of the deck.
        /// If unused pile empty, returns null.
        /// </summary>
        /// <returns>The dealt card or null.</returns>
        public Card? Deal()
        {
            Card toDeal;

            if (this._unusedCards.Count == 0) 
            {
                return null;
            } 
            else 
            {
                //move the card to cardsInPlay
                toDeal = this._unusedCards.Pop();
                this._cardsInPlay.Add(toDeal);

                return toDeal;
            }
        }

        /// <summary>
        /// Returns cards to the deck. If the cards are already in the deck, throws exception.
        /// </summary>
        /// <param name="cards">The cards to return.</param>
        /// <returns>The deck.</returns>
        public Deck ReturnToDeck(IEnumerable<Card> cards)
        {
            if (cards.Count() > 0) 
            {
                foreach (Card card in cards) 
                {
                    if (this._cardsInPlay.Contains(card))
                    {
                        this._cardsInPlay.Remove(card);
                        this._usedCards.Add(card);
                    }
                    else
                    {
                        throw new InvalidOperationException("Trying to return cards that are already in the deck.");
                    }
                }
            }

            return this;
        }
    }
}