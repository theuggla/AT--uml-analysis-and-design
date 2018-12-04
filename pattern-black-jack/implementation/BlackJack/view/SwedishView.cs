using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BlackJack.view
{
    class SwedishView : IView
    {
        private int action;

        public void DisplayWelcomeMessage()
        {
            System.Console.Clear();
            System.Console.WriteLine("Hej Black Jack Världen");
            System.Console.WriteLine("----------------------");
            System.Console.WriteLine("Skriv 'p' för att Spela, 'h' för nytt kort, 's' för att stanna 'q' för att avsluta\n");
        }

        public void DisplayNewGameSetup()
        {
            System.Console.Clear();
        }

        public void CollectDesiredPlayerAction()
        {
            this.action = this.GetInput();
        }

        public bool WantsToPlay()
        {
            return action == 'p';
        }

        public bool WantsToHit()
        {
            return action == 'h';
        }

        public bool WantsToStand()
        {
            return action == 's';
        }

        public bool WantsToQuit()
        {
           return action == 'q';
        }

        public void DisplayCard(model.Card a_card)
        {
            if (a_card.GetColor() == model.Card.Color.Hidden)
            {
                System.Console.WriteLine("Dolt Kort");
            }
            else
            {
                String[] colors = new String[(int)model.Card.Color.Count]
                    { "Hjärter", "Spader", "Ruter", "Klöver" };
                String[] values = new String[(int)model.Card.Value.Count] 
                    { "två", "tre", "fyra", "fem", "sex", "sju", "åtta", "nio", "tio", "knekt", "dam", "kung", "ess" };
                System.Console.WriteLine("{0} {1}", colors[(int)a_card.GetColor()], values[(int)a_card.GetValue()]);
            }
        }

        public void DisplayPlayerHand(IEnumerable<model.Card> a_hand, int a_score)
        {
            DisplayHand("Spelare", a_hand, a_score);
        }

        public void DisplayDealerHand(IEnumerable<model.Card> a_hand, int a_score)
        {
            DisplayHand("Croupier", a_hand, a_score);
        }

        public void DisplayCardIsBeingDealt()
        {
            System.Console.WriteLine("Delar ut kort...");
            Thread.Sleep(2000);
            System.Console.Clear();
        }

        public void DisplayGameOver(bool a_dealerIsWinner)
        {
            System.Console.Write("Slut: ");
            if (a_dealerIsWinner)
            {
                System.Console.WriteLine("Croupiern Vann!");
            }
            else
            {
                System.Console.WriteLine("Du vann!");
            }
        }

        public void VisitDealerFavoured(model.rules.DealerFavouredFactory factory)
        {
            Console.WriteLine("Reglerna är till favör för Croupiern, vilket betyder:");
            Console.WriteLine("\t \t * Amerikansk start på spelet, där Croupierns andra kort är dolt.");
            Console.WriteLine("\t \t * Croupiern tar nytt kort vid 17 poäng om ett kort på handen är ett ess.");
            Console.WriteLine("\t \t * Croupiern vinner vid lika ställning.");
        }

        public void VisitPlayerFavoured(model.rules.PlayerFavouredFactory factory)
        {
            Console.WriteLine("Reglerna är till favör för dig, vilket betyder:");
            Console.WriteLine("\t \t * Internationell start på spelet, där Croupierns andra kort är synligt.");
            Console.WriteLine("\t \t * Croupiern tar inte nytt kort vid 17 poäng, även om ett kort på handen är ett ess.");
            Console.WriteLine("\t \t * Du vinner vid lika ställning.");
        }

        public void VisitMixAndMatch(model.rules.MixAndMatchFactory factory)
        {
            Console.WriteLine("Reglerna är till favör för Croupiern, vilket betyder:");
            Console.WriteLine("\t \t * Amerikansk start på spelet, där Croupierns andra kort är dolt.");
            Console.WriteLine("\t \t * Croupiern tar nytt kort vid 17 poäng om ett kort på handen är ett ess.");
            Console.WriteLine("\t \t * Du vinner vid lika ställning.");
        }

        private int GetInput()
        {
            return System.Console.In.Read();
        }

        private void DisplayHand(String a_name, IEnumerable<model.Card> a_hand, int a_score)
        {
            System.Console.WriteLine("{0} Har: ", a_name);
            foreach (model.Card c in a_hand)
            {
                DisplayCard(c);
            }
            System.Console.WriteLine("Poäng: {0}", a_score);
            System.Console.WriteLine("");
        }
    }
}
