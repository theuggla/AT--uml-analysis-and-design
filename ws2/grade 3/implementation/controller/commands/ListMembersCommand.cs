using System;
using System.Collections.Generic;

namespace MemberRegistry.controller 
{
    class ListMembersCommand : BaseCommand, LoggedInCommand, LoggedOutCommand
    {
        private bool _verboseList;
        private List<model.Member> _currentMemberList;

        public ListMembersCommand(string description, view.IView view, model.MemberLedger ledger) 
        : base(description, view, ledger)
        {}

        public override void ExecuteCommand() {

            this._currentMemberList = _ledger.GetMembers();
            this._verboseList = GetUserBoolean("Would you like a detailed list?");

            if (this.ThereAreMembersInTheSystem())
            {
                this.DisplayMembers();
            }
            else
            {
                DisplayMessage("No members of the club in the system.");
            }
        }

        private bool ThereAreMembersInTheSystem()
        {
            return this._currentMemberList.Count != 0;
        }

        private void DisplayMembers()
        {
            foreach (model.Member member in this._currentMemberList) {
                this.DisplayMember(member);
            }
        }

        private void DisplayMember(model.Member member)
        {
            dynamic displayModel = GetMemberDisplayModel(member, this._verboseList);
            DisplayMember(displayModel);

            if (this._verboseList)
            {
                this.DisplayBoats(member);
            }
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