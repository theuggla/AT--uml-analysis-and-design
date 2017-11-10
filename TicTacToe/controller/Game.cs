using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToe.View;
using TicTacToe.Model;

namespace TicTacToe.Controller
{
    public class Game
    {
        private AI ai;
        private Board board;
        private ConsoleView view;

        public Game(ConsoleView view, Board board, AI ai)
        {
            this.view = view;
            this.board = board;
            this.ai = ai;
        }

        public void PlayGame()
        {
            this.view.DisplayInstructions("Welcome to TicTacToe!");
            this.view.DisplayBoard(this.board);
            Square userSquare = this.view.GetSquareToPlayOn(this.board);
            userSquare.PlayOn(PlayerSign.X);
        }

        public bool IsGameOver()
        {
            List<Square> boardAsList = this.board.GetBoard().ToList();
            return this.board.IsFull()
            || boardAsList.ElementAt(0).IsPlayedOn() && boardAsList.ElementAt(0).Sign.Equals(boardAsList.ElementAt(1).Sign) && boardAsList.ElementAt(0).Sign.Equals(boardAsList.ElementAt(2).Sign);
        }
    }
}