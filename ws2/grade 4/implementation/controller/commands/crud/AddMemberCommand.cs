using System;
using System.Collections.Generic;

namespace MemberRegistry.controller.commands 
{
    class AddMemberCommand : CRUDCommand
    {
        public AddMemberCommand(string description, view.IView view, model.MemberLedger ledger) 
        : base(description, view, ledger)
        {}

        public override void ExecuteCommand() 
        {
            string memberName = base.GetMemberName();
            string memberPassword = base.GetMemberPassword();
            string personalNumber = base.GetMemberPersonalNumber();

            _ledger.CreateMember(memberName, memberPassword, personalNumber);
        }
    }
}