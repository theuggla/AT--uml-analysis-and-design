using System;
using System.Collections.Generic;

namespace MemberRegistry.controller 
{
    class SaveChanges : BaseCommand
    {
        public SaveChanges(string description, view.Console view, model.MemberLedger ledger) 
        : base(description, view, ledger)
        {}

        public override void ExecuteCommand() {
            DisplayMessage("Changes will be saved.");
            _ledger.SaveMemberList();
        }
    }
}