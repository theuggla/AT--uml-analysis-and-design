using System;
using System.Linq;
using System.Collections.Generic;

namespace MemberRegistry.controller 
{
    class SearchCommand : DisplayCommand, ILoggedInCommand, ILoggedOutCommand
    {
        private IEnumerable<model.ISearchCriteria> _searchCriteriaList;

        public SearchCommand(string description, view.IView view, model.MemberLedger ledger) 
        : base(description, view, ledger)
        {}

        public override void ExecuteCommand() {
            this._searchCriteriaList = _ledger.GetSearchCriteriaList();
            model.ISearchCriteria criteria = GetSearchCriteria(this._searchCriteriaList);
            base._currentMemberList = (List<model.Member>)_ledger.Search(criteria);

            if (base.ThereAreMembersInTheSystem())
            {
                base.DisplayMembers();
            }
            else
            {
                base.DisplayFailureMessage("No members of the club match your search.");
            }
        }
    }
}