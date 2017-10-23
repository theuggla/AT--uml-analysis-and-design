using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class DealerFavouredFactory : AbstractRulesFactory
    {
        public override IHitStrategy GetHitRule()
        {
            return new Soft17HitStrategy();
        }

        public override INewGameStrategy GetNewGameRule()
        {
            return new AmericanNewGameStrategy();
        }

        public override IWinnerStrategy GetWinnerRule()
        {
            return new DealerWinsOnEqualWinnerStrategy();
        }
    }
}
