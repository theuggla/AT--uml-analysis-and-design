using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    abstract class AbstractRulesFactory
    {
        public abstract IHitStrategy GetHitRule();

        public abstract INewGameStrategy GetNewGameRule();

        public abstract IWinnerStrategy GetWinnerRule();
    }
}