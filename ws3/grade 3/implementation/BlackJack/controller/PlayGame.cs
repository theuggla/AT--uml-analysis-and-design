using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BlackJack.controller
{
    class PlayGame : model.ICardDealtObserver
    {
        private model.Game m_game;
        private view.IView m_view;

        public PlayGame(model.Game a_game, view.IView a_view)
        {
            this.m_game = a_game;
            this.m_view = a_view;

            this.m_game.AddCardDealtObserver(this);
        }

        public bool Play()
        {
            m_view.DisplayWelcomeMessage();
            this.DisplayHands();

            if (m_game.IsGameOver())
            {
                m_view.DisplayGameOver(m_game.IsDealerWinner());
            }

            m_view.CollectDesiredPlayerAction();

            if (m_view.WantsToPlay())
            {
                m_view.DisplayNewGameSetup();
                m_game.NewGame();
            }
            else if (m_view.WantsToHit())
            {
                m_game.Hit();
            }
            else if (m_view.WantsToStand())
            {
                m_game.Stand();
            }

            return !m_view.WantsToQuit();
        }

        public void CardDealt()
        {
            this.m_view.DisplayCardIsBeingDealt();
            this.DisplayHands();
        }

        private void DisplayHands()
        {
            m_view.DisplayDealerHand(m_game.GetDealerHand(), m_game.GetDealerScore());
            m_view.DisplayPlayerHand(m_game.GetPlayerHand(), m_game.GetPlayerScore());
        }
    }
}
