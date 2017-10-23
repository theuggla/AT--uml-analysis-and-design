using System;
using System.Collections.Generic;
using System.Linq;

namespace MemberRegistry.model
{
	class StartsWithSCriteria : ISearchCriteria
	{
        public IEnumerable<model.Member> MeetCriteria(IEnumerable<model.Member> memberList)
        {
            return memberList
                    .Where(x => char.ToUpperInvariant(x.Name[0]) == 'S')
                    .ToList();
        }

        public string GetDescription()
        {
            return "name starts with an S";
        }
    }
}