using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    interface IRulesFactoryVisitor
    {
        void VisitDealerFavoured(DealerFavouredFactory factory);

        void VisitPlayerFavoured(PlayerFavouredFactory factory);

        void VisitMixAndMatch(MixAndMatchFactory factory);
    }
}