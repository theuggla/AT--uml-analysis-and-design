using System;
using System.Collections.Generic;

namespace MemberRegistry.controller 
{
    class DeleteMemberCommand : CRUDCommand
    {
        public DeleteMemberCommand (string description, view.IView view, model.MemberLedger ledger) 
        : base(description, view, ledger)
        {}

        public override void ExecuteCommand() {
            model.Member member = GetMember();
            _ledger.DeleteMember(member);
        }
    }
}