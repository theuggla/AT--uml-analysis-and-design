using System;
using System.Collections.Generic;

namespace MemberRegistry.controller 
{
    class DeleteMember : BaseCommand, IMenuItemCommand
    {
        public MenuCategory[] Tags {get;}

        public DeleteMember(MenuCategory[] tags, string description, view.Console view) 
        : base(description, view)
        {
            this.Tags = tags;
        }

        public void ExecuteCommand(model.MemberLedger ledger) {
            int memberID = GetMemberID();
            ledger.DeleteMember(memberID);
        }
    }
}