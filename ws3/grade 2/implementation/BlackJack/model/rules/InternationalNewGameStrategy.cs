using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class InternationalNewGameStrategy : INewGameStrategy
    {

        public bool NewGame(Dealer a_dealer, Player a_player)
        {
            a_dealer.GiveCardToPlayer(a_player, true);
            a_dealer.GiveCardToPlayer(a_dealer, true);
            a_dealer.GiveCardToPlayer(a_player, true);
            a_dealer.GiveCardToPlayer(a_dealer, true);

            return true;
        }
    }
}
