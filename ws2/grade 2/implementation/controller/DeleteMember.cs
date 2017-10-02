using System;
using System.Collections.Generic;

namespace MemberRegistry.controller 
{
    class DeleteMember : BaseCommand
    {
        public DeleteMember(string description, view.IView view, model.MemberLedger ledger) 
        : base(description, view, ledger)
        {}

        public override void ExecuteCommand() {
            int memberID = GetMemberID();
            _ledger.DeleteMember(memberID);
        }
    }
}