using System;

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
            Card card = new Card(Suit.Clubs, Rank.Jack);
            Card card2 = new Card(Suit.Diamonds, Rank.Ace);
            card2.AceValue = 1;
            Card[] array = {card, card2};

            try
            {
                Console.WriteLine("Hi! Yes it works.");
                Console.WriteLine(card);
                Console.WriteLine(card2);
                Console.WriteLine("comparing");
                Console.WriteLine(card.CompareTo(card2));
                Console.WriteLine(card.Equals(card2));
                Card[] array2 = (Card[])array.Clone();
                Console.WriteLine("comparing acevalues");
                Console.WriteLine(array[1].AceValue);
                Console.WriteLine(array2[1].AceValue);
                Console.WriteLine(array[1].Equals(array2[1]));
                Console.WriteLine("change acevalue");
                array[1].AceValue = 14;
                Console.WriteLine("comparing acevalues");
                Console.WriteLine(array[1].AceValue);
                Console.WriteLine(array2[1].AceValue);
                Console.WriteLine(array[1].Equals(array2[1]));
                
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}