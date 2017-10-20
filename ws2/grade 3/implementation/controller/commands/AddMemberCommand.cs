using System;
using System.Collections.Generic;

namespace MemberRegistry.controller 
{
    class AddMemberCommand : BaseCommand, LoggedInCommand
    {
        public AddMemberCommand(string description, view.IView view, model.MemberLedger ledger) 
        : base(description, view, ledger)
        {}

        public override void ExecuteCommand() 
        {
            DisplayMessage("Please give the member details:");
            string memberName = GetMemberName();
            string memberPassword = GetMemberPassword();
            int personalNumber = GetMemberPersonalNumber();

            _ledger.CreateMember(memberName, memberPassword, personalNumber);
        }
    }
}