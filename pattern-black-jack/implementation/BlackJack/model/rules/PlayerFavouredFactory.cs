using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class PlayerFavouredFactory : AbstractRulesFactory
    {
        public override IHitStrategy GetHitRule()
        {
            return new BasicHitStrategy();
        }

        public override INewGameStrategy GetNewGameRule()
        {
            return new InternationalNewGameStrategy();
        }

        public override IWinnerStrategy GetWinnerRule()
        {
            return new PlayerWinsOnEqualWinnerStrategy();
        }

        public override void Accept(IRulesFactoryVisitor visitor)
        {
            visitor.VisitPlayerFavoured(this);
        }
    }
}
