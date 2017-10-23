using System;
using System.Collections.Generic;
using System.Linq;

namespace MemberRegistry.model
{
	class StartsWithNCriteria : ISearchCriteria
	{
        public IEnumerable<model.Member> MeetCriteria(IEnumerable<model.Member> memberList)
        {
            return memberList
                    .Where(x => char.ToUpperInvariant(x.Name[0]) == 'N')
                    .ToList();
        }

        public string GetDescription()
        {
            return "members who's name starts with an N";
        }
    }
}