using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    class Dealer : Player
    {
        private Deck m_deck = null;
        private const int g_maxScore = 21;
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
            if (this.GameIsGoingOn() && a_player.CalcScore() < 21 && !this.IsGameOver(a_player))
            {
                Card c;
                c = m_deck.GetCard();
                c.Show(true);
                a_player.DealCard(c);

                return true;
            }

            return false;
        }

        public bool Stand()
        {
            if (this.GameIsGoingOn())
            {
                ShowHand();

                while (m_hitRule.DoHit(this))
                {
                    Card c = m_deck.GetCard();
                    c.Show(true);
                    DealCard(c);
                }
            }


            return false;
        }

        public bool IsDealerWinner(Player a_player)
        {
            return m_winnerRule.IsDealerWinner(a_player, this);
        }

        public bool IsGameOver(Player a_player)
        {
            if (this.GameIsGoingOn() && this.DealerWantsToStand() || a_player.CalcScore() >= 21)
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
    }
}
