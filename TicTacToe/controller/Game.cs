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
            return this.board.IsFull();
        }
    }
}