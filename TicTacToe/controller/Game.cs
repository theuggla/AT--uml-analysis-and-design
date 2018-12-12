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
            PlayerSign winner = PlayerSign.None;

            this.view.DisplayInstructions("Welcome to TicTacToe!");
            
            do
            {
                this.view.DisplayBoard(this.board);
                this.view.DisplayInstructions("Please choose a square to play on: ");
                Square userSquare = this.view.GetSquareToPlayOn(this.board);
                userSquare.PlayOn(PlayerSign.X);

                if (IsGameOver(ref winner)) break;
                 
                Square AISquare = this.ai.GetSquareToPlayOn(this.board);
                AISquare.PlayOn(PlayerSign.O);this.view.DisplayBoard(this.board);

            } while (!IsGameOver(ref winner));

            this.view.DisplayBoard(this.board);
            if (!winner.Equals(PlayerSign.None)) 
            {
                this.view.DisplayInstructions($"Player {winner.ToString()} won!");
            }
            else 
            {
                this.view.DisplayInstructions("It's a draw!");
            }
        }

        private bool IsGameOver(ref PlayerSign winner)
        {
            bool isWon = false;

            foreach (int[] row in this.board.WinningRows())
            {
                if (IsRowWon(row, ref winner))
                {
                    isWon = true;
                    break;
                }
            }

            if (!isWon) winner = PlayerSign.None;

            return isWon || this.board.IsFull();
        }

        private bool IsRowWon(int[] row, ref PlayerSign winner)
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
                        winner = PlayerSign.None;
                        break;
                    }

                    winner = this.board.GetBoard().ElementAt(row[0]).Sign;
                }
            }

            return rowIsEqual;
        }
    }
}