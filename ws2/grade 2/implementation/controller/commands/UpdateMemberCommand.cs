using System;
using System.Collections.Generic;

namespace MemberRegistry.controller 
{
    class UpdateMemberCommand : BaseCommand
    {
        public UpdateMemberCommand(string description, view.IView view, model.MemberLedger ledger) 
        : base(description, view, ledger)
        {}

        public override void ExecuteCommand() {
            int memberID = GetMemberID();
            string newName = GetMemberName();
            int newPersonalNumber = GetMemberPersonalNumber();
            
            _ledger.UpdateMember(memberID, newName, newPersonalNumber);
        }
    }
}