using System;
using System.Collections.Generic;

namespace MemberRegistry.controller 
{
    class UpdateBoat : BaseCommand, IMenuItemCommand
    {
        public MenuCategory[] Tags {get;}

        public UpdateBoat(MenuCategory[] tags, string description, view.Console view) 
        : base(description, view)
        {
            this.Tags = tags;
        }

        public void ExecuteCommand(model.MemberLedger ledger) {
            int memberID = GetMemberID();
            
            model.Member member = ledger.GetMember(memberID);

            if (member.Boats.Count > 0) 
            {

                DisplayMessage("FInd the ID of the boat you would like to delete.");

                for (int i = 0; i < member.Boats.Count; i++)
                {
                    dynamic viewModelBoat = GetBoatDisplayModel(member.Boats[i]);
                    DisplayBoat(viewModelBoat);
                } 

                int boatID = GetBoatID();
                BoatType boatType = GetBoatType();
                int boatLength = GetBoatLength();

                ledger.UpdateBoat(memberID, boatID, boatType, boatLength);

            } 
            else 
            {
                DisplayMessage("Member has no boats.");
            }
        }
    }
}