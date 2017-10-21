using System;
using System.Linq;
using System.Collections.Generic;

namespace MemberRegistry.controller 
{
    class SearchCommand : BaseCommand, LoggedInCommand, LoggedOutCommand
    {
        private IEnumerable<model.Member> _currentMemberList;
        private IEnumerable<model.ISearchCriteria> _searchCriteriaList;

        public SearchCommand(string description, view.IView view, model.MemberLedger ledger) 
        : base(description, view, ledger)
        {}

        public override void ExecuteCommand() {
            this._searchCriteriaList = _ledger.GetSearchCriteriaList();
            model.ISearchCriteria criteria = GetSearchCriteria(this._searchCriteriaList);
            this._currentMemberList = _ledger.Search(criteria);

            if (this.ThereAreMembersInTheSystem())
            {
                this.DisplayMembers();
            }
            else
            {
                DisplayMessage("No members of the club match your search.");
            }
        }

        private bool ThereAreMembersInTheSystem()
        {
            return this._currentMemberList.Count() != 0;
        }

        private void DisplayMembers()
        {
            foreach (model.Member member in this._currentMemberList) {
                this.DisplayMember(member);
            }
        }

        private void DisplayMember(model.Member member)
        {
            dynamic displayModel = GetMemberDisplayModel(member);
            DisplayMember(displayModel);
        }

        private void DisplayBoats(model.Member member)
        {
            if (member.Boats.Count > 0)
            {
                DisplayMessage("Boats: ");
                foreach(model.Boat boat in member.Boats)
                {
                    dynamic boatDisplayModel = GetBoatDisplayModel(boat);
                    DisplayBoat(boatDisplayModel);
                }
            }
        }
    }
}