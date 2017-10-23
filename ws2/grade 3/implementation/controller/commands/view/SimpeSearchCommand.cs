using System;
using System.Linq;
using System.Collections.Generic;

namespace MemberRegistry.controller 
{
    class SimpleSearchCommand : DisplayCommand, ILoggedOutCommand
    {
        private IEnumerable<model.ISearchCriteria> _searchCriteriaList;

        public SimpleSearchCommand(string description, view.IView view, model.MemberLedger ledger, IEnumerable<model.ISearchCriteria> searchCriteriaList) 
        : base(description, view, ledger)
        {
            this._searchCriteriaList = searchCriteriaList;
        }

        public override void ExecuteCommand() {
            model.ISearchCriteria criteria = GetSearchCriteria(this._searchCriteriaList);
            base._currentMemberList = (List<model.Member>)_ledger.Search(criteria);

            base.DisplayMembers();
        }
    }
}