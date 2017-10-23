using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    class Game
    {
        private model.Dealer m_dealer;
        private model.Player m_player;

        public Game(rules.RulesFactoryProducer.RuleType ruleType)
        {
            m_dealer = new Dealer(rules.RulesFactoryProducer.GetFactory(ruleType));
            m_player = new Player();
        }

        public bool IsGameOver()
        {
            return m_dealer.IsGameOver(m_player);
        }

        public bool IsDealerWinner()
        {
            return m_dealer.IsDealerWinner(m_player);
        }

        public bool NewGame()
        {
            return m_dealer.NewGame(m_player);
        }

        public bool Hit()
        {
            return m_dealer.Hit(m_player);
        }

        public bool Stand()
        {
            return m_dealer.Stand();
        }

        public IEnumerable<Card> GetDealerHand()
        {
            return m_dealer.GetHand();
        }

        public IEnumerable<Card> GetPlayerHand()
        {
            return m_player.GetHand();
        }

        public int GetDealerScore()
        {
            return m_dealer.CalcScore();
        }

        public int GetPlayerScore()
        {
            return m_player.CalcScore();
        }

        public void AddCardDealtObserver(ICardDealtObserver a_subscriber)
        {
            m_dealer.AddSubscriber(a_subscriber);
        }
    }
}
