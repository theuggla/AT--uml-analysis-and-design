using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            model.Game g = new model.Game(model.rules.RulesFactoryProducer.RuleType.PlayerFavoured);
            view.IView v = new view.SimpleView();
            controller.PlayGame ctrl = new controller.PlayGame(g, v);

            while (ctrl.Play());
        }
    }
}
