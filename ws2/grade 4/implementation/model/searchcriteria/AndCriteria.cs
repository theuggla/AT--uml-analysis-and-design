using System;
using System.Collections.Generic;
using System.Linq;

namespace MemberRegistry.model
{
	class AndCriteria : ISearchCriteria
	{
        private ISearchCriteria _firstCriteria;
        private ISearchCriteria _otherCriteria;

        public AndCriteria(ISearchCriteria firstCriteria, ISearchCriteria otherCriteria)
        {
            this._firstCriteria = firstCriteria;
            this._otherCriteria = otherCriteria;
        }

        public IEnumerable<model.Member> MeetCriteria(IEnumerable<model.Member> memberList)
        {
            IEnumerable<model.Member> firstCriteriaMembers = this._firstCriteria.MeetCriteria(memberList);		
            return this._otherCriteria.MeetCriteria(firstCriteriaMembers);
        }

        public string GetDescription()
        {
            return this._firstCriteria.GetDescription() + " and " + this._otherCriteria.GetDescription() + " ";
        }
    }
}