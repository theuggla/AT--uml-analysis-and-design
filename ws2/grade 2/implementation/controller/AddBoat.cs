using System;
using System.Collections.Generic;

namespace MemberRegistry.controller 
{
    class AddBoat : BaseCommand, IMenuItemCommand
    {
        public MenuCategory[] Tags {get;}

        public AddBoat(MenuCategory[] tags, string description, view.Console view) 
        : base(description, view)
        {
            this.Tags = tags;
        }

        public void ExecuteCommand(model.MemberLedger ledger) {
            int memberID = GetMemberID();
            BoatType boatType = GetBoatType();
            int boatLength = GetBoatLength();

            ledger.RegisterBoat(memberID, boatType, boatLength);
        }
    }
}