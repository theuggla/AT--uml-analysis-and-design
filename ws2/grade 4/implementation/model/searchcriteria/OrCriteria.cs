using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistry.model.searchcriteria
{
	class OrCriteria : ISearchCriteria
	{
        private ISearchCriteria _firstCriteria;
        private ISearchCriteria _otherCriteria;

        public OrCriteria(ISearchCriteria firstCriteria, ISearchCriteria otherCriteria)
        {
            this._firstCriteria = firstCriteria;
            this._otherCriteria = otherCriteria;
        }

        public IEnumerable<model.Member> MeetCriteria(IEnumerable<model.Member> memberList)
        {
            IEnumerable<model.Member> firstCriteriaMembers = this._firstCriteria.MeetCriteria(memberList);
            IEnumerable<model.Member> otherCriteriaMembers = this._otherCriteria.MeetCriteria(memberList);
            return firstCriteriaMembers.Union(otherCriteriaMembers).ToList();
        }

        public string GetDescription()
        {
            return this._firstCriteria.GetDescription() + " or " + this._otherCriteria.GetDescription() + " ";
        }
    }
}