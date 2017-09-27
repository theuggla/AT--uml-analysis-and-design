using System;
using System.Collections.Generic;

namespace MemberRegistry.controller 
{
    class UpdateMember : BaseCommand, IMenuItemCommand
    {
        public MenuCategory[] Tags {get;}

        public UpdateMember(MenuCategory[] tags, string description, view.Console view) 
        : base(description, view)
        {
            this.Tags = tags;
        }

        public void ExecuteCommand(model.MemberLedger ledger) {
            int memberID = GetMemberID();
            string newName = GetMemberName();
            int newPersonalNumber = GetMemberPersonalNumber();
            

            ledger.UpdateMember(memberID, newName, newPersonalNumber);
        }
    }
}