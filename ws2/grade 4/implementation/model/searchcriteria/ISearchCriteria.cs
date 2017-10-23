using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistry.model
{
	interface ISearchCriteria : model.IMenuItem
	{
        IEnumerable<model.Member> MeetCriteria(IEnumerable<model.Member> memberList);
    }
}