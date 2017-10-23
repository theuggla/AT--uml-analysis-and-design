using System;
using System.Collections.Generic;

namespace MemberRegistry.controller 
{
    class ListMembersCommand : DisplayCommand, ILoggedOutCommand
    {
        public ListMembersCommand(string description, view.IView view, model.MemberLedger ledger) 
        : base(description, view, ledger)
        {}

        public override void ExecuteCommand() {

            base._currentMemberList = (List<model.Member>)_ledger.GetMembers();
            base.DisplayMembers();
        }
    }
}