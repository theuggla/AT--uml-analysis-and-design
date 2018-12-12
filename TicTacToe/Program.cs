using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            View.ConsoleView view = new View.ConsoleView();
            Model.Board board = new Model.Board();
            Model.AI ai = new Model.AI();
            Controller.Game game = new Controller.Game(view, board, ai);
            game.PlayGame();
        }
    }
}
