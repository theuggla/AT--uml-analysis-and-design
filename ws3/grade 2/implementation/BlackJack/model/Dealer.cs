using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    class Dealer : Player
    {
        private Deck m_deck = null;
        private rules.INewGameStrategy m_newGameRule;
        private rules.IHitStrategy m_hitRule;
        private rules.IWinnerStrategy m_winnerRule;

        public Dealer(rules.RulesFactory a_rulesFactory)
        {
            m_newGameRule = a_rulesFactory.GetNewGameRule();
            m_hitRule = a_rulesFactory.GetHitRule();
            m_winnerRule = a_rulesFactory.GetWinnerRule();
        }

        public bool NewGame(Player a_player)
        {
            if (!this.GameIsGoingOn() || IsGameOver(a_player))
            {
                m_deck = new Deck();
                this.ClearHand();
                a_player.ClearHand();

                return m_newGameRule.NewGame(m_deck, this, a_player);   
            }

            return false;
        }

        public bool Hit(Player a_player)
        {
            if (this.GameIsGoingOn() && a_player.CalcScore() < g_maxScore && !this.IsGameOver(a_player))
            {
                this.GiveCardToPlayer(a_player);
                return true;
            }

            return false;
        }

        public bool Stand()
        {
            if (this.GameIsGoingOn())
            {
                this.ShowHand();

                while (m_hitRule.DoHit(this))
                {
                    this.GiveCardToPlayer(this);
                }

                return true;
            }


            return false;
        }

        public bool IsDealerWinner(Player a_player)
        {
            return m_winnerRule.IsDealerWinner(a_player, this);
        }

        public bool IsGameOver(Player a_player)
        {
            if (this.GameIsGoingOn() && this.DealerWantsToStand() || a_player.CalcScore() >= g_maxScore)
            {
                return true;
            }
            return false;
        }

        private bool GameIsGoingOn()
        {
            return m_deck != null;
        }

        private bool DealerWantsToStand()
        {
            return m_hitRule.DoHit(this) != true;
        }

        private bool GiveCardToPlayer(Player a_playerToReceiveCard)
        {
            Card c = m_deck.GetCard();
            c.Show(true);
            a_playerToReceiveCard.DealCard(c);

            return true;
        }
    }
}
