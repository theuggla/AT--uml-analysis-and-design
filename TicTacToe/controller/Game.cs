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
            Square AISquare = this.ai.GetSquareToPlayOn(this.board);
            AISquare.PlayOn(PlayerSign.O);
        }

        public bool IsGameOver()
        {
            List<Square> boardAsList = this.board.GetBoard().ToList();
            return this.board.IsFull()
            || this.board.WinningRows().Any(row => IsRowWon(row));
        }

        private bool IsRowWon(int[] row)
        {
            bool rowIsEqual = false;

            if (this.board.GetBoard().ElementAt(row[0]).IsPlayedOn())
            {
                rowIsEqual = true;

                foreach (int squarePos in row)
                {
                    if (!this.board.GetBoard().ElementAt(row[0]).Sign.Equals(this.board.GetBoard().ElementAt(squarePos).Sign))
                    {
                        rowIsEqual = false;
                        break;
                    }
                }
            }

            return rowIsEqual;
        }
    }
}