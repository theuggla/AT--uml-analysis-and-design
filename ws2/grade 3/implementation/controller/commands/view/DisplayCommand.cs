using System;
using System.Linq;
using System.Collections.Generic;

namespace MemberRegistry.controller 
{
    abstract class DisplayCommand : BaseCommand, ILoggedInCommand
    {
        protected List<model.Member> _currentMemberList;

        public DisplayCommand(string description, view.IView view, model.MemberLedger ledger) 
        : base(description, view, ledger)
        {}

        protected void DisplayMembers()
        {
            base._view.DisplayMembers(this._currentMemberList);
        }

        protected void DisplayMember()
        {
            this._currentMemberList = new List<model.Member>();
            this._currentMemberList.Add(this._currentlySelectedMember);
            base._view.DisplayMembers(this._currentMemberList);
        }

        protected void DisplayBoats()
        {
            base._view.DisplayBoats(base._currentlySelectedMember.Boats);
        }
    }
}