using System;
using System.Collections.Generic;

namespace MemberRegistry.controller 
{
    class AddMember : BaseCommand, IMenuItemCommand
    {
        public MenuCategory[] Tags {get;}

        public AddMember(MenuCategory[] tags, string description, view.Console view) 
        : base(description, view)
        {
            this.Tags = tags;
        }

        public void ExecuteCommand(model.MemberLedger ledger) 
        {
            DisplayMessage("Please give the member details:");
            string memberName = GetMemberName();
            int personalNumber = GetMemberPersonalNumber();

            ledger.CreateMember(memberName, personalNumber);
        }
    }
}