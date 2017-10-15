using System;
using System.Collections.Generic;

namespace MemberRegistry.controller 
{
    class DeleteMemberCommand : BaseCommand
    {
        public DeleteMemberCommand (string description, view.IView view, model.MemberLedger ledger) 
        : base(description, view, ledger)
        {}

        public override void ExecuteCommand() {
            int memberID = GetMemberID();
            _ledger.DeleteMember(memberID);
        }
    }
}