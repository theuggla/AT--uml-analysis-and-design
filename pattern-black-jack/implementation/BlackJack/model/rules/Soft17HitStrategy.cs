using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class Soft17HitStrategy : IHitStrategy
    {
        private const int g_hitLimit = 17;

        public bool DoHit(model.Player a_dealer)
        {
            if (this.DealerHasReachedHitLimit(a_dealer))
            {
                return (this.DealerScoreIs17(a_dealer) && this.DealerHandContainsAce(a_dealer));
            }
            else 
            {
                return true;
            }
        }

        private bool DealerHasReachedHitLimit(model.Player a_dealer)
        {
            return a_dealer.CalcScore() >= g_hitLimit;
        }

        private bool DealerScoreIs17(model.Player a_dealer)
        {
            return a_dealer.CalcScore() == 17;
        }

        private bool DealerHandContainsAce(model.Player a_dealer)
        {
            foreach (Card c in a_dealer.GetHand())
            {
                if (c.GetValue() == Card.Value.Ace)
                {
                    return true;
                }
            }

            return false;
        } 
    }
}