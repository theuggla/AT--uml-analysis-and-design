using System;
using System.Collections.Generic;

namespace MemberRegistry.controller 
{
    class UpdateMemberCommand : CRUDCommand
    {
        public UpdateMemberCommand(string description, view.IView view, model.MemberLedger ledger) 
        : base(description, view, ledger)
        {}

        public override void ExecuteCommand() {
            model.Member member = GetMember();
            string newName = GetMemberName();
            int newPersonalNumber = GetMemberPersonalNumber();
            
            _ledger.UpdateMember(member, newName, newPersonalNumber);
        }
    }
}