using System;
using System.Collections.Generic;

namespace MemberRegistry.controller 
{
    class AddMember : BaseCommand
    {
        public AddMember(string description, view.IView view, model.MemberLedger ledger) 
        : base(description, view, ledger)
        {}

        public override void ExecuteCommand() 
        {
            DisplayMessage("Please give the member details:");
            string memberName = GetMemberName();
            int personalNumber = GetMemberPersonalNumber();

            _ledger.CreateMember(memberName, personalNumber);
        }
    }
}