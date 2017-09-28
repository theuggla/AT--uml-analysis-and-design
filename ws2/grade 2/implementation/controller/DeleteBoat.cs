using System;
using System.Collections.Generic;

namespace MemberRegistry.controller 
{
    class DeleteBoat : BaseCommand
    {
        public DeleteBoat(string description, view.Console view, model.MemberLedger ledger) 
        : base(description, view, ledger)
        {}
        public override void ExecuteCommand() {
            int memberID = GetMemberID();

            model.Member member = _ledger.GetMember(memberID);

            if (member.Boats.Count > 0) {

                DisplayMessage("Find the ID of the boat you would like to delete.");

                for (int i = 0; i < member.Boats.Count; i++)
                {
                    dynamic viewModelBoat = GetBoatDisplayModel(member.Boats[i]);
                    DisplayBoat(viewModelBoat);
                } 

                int boatID = GetBoatID();
                _ledger.DeleteBoat(memberID, boatID);

            } else {
                DisplayMessage("Member has no boats.");
            }
        }
    }
}