using System;
using System.Linq;
using System.Collections.Generic;

namespace MemberRegistry.controller.commands 
{
    class SearchCommand : DisplayCommand
    {
        private IEnumerable<model.searchcriteria.ISearchCriteria> _searchCriteriaList;

        public SearchCommand(string description, view.IView view, model.MemberLedger ledger, IEnumerable<model.searchcriteria.ISearchCriteria> searchCriteriaList) 
        : base(description, view, ledger)
        {
            this._searchCriteriaList = searchCriteriaList;
        }

        public override void ExecuteCommand() {
            model.searchcriteria.ISearchCriteria criteria = GetSearchCriteria();
            base._currentMemberList = (List<model.Member>)_ledger.Search(criteria);

            base.DisplayMembers();
        }

        private model.searchcriteria.ISearchCriteria GetSearchCriteria()
        {
            return (model.searchcriteria.ISearchCriteria) this._view.GetSelectedMenuItem("Search Criteria", this._searchCriteriaList);
        }
    }
}