using System;
using System.Collections.Generic;

namespace TwentyOneCardGame
{
    /// <summary>
    /// A console application for simulating a twenty-one card game.
    /// </summary>
    public class Application
    {
        /// <summary>
        /// Runs the application.
        /// </summary>
        public static void Run()
        {

            try
            {
                List<Card> hand = new List<Card>();
                List<Card> badHand = new List<Card>();
                Deck deck = new Deck();
                Card card = new Card(Suit.Clubs, Rank.Ace);
                badHand.Add(card);



                Console.WriteLine(deck);
                deck.Shuffle();
                Console.WriteLine(deck);
                hand.Add(deck.Deal());
                hand.Add(deck.Deal());
                hand.Add(deck.Deal());
                hand.Add(deck.Deal());
                hand.Add(deck.Deal());
                Console.WriteLine(deck);
                foreach(Card c in hand)
                {
                    Console.Write(c);
                }
                Console.WriteLine();
                deck.ReturnToDeck(hand);
                deck.Shuffle();
                Console.WriteLine(deck);
                deck.ReturnToDeck(badHand);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}