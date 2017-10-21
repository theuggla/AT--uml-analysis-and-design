using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistry.model
{
	interface ISearchCriteria
	{
        IEnumerable<model.Member> ExecuteCriteria(IEnumerable<model.Member> memberList);
    }
}