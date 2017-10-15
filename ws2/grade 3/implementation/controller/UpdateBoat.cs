using System;
using System.Collections.Generic;

namespace MemberRegistry.controller 
{
    class UpdateBoat : BaseCommand
    {
        public UpdateBoat(string description, view.IView view, model.MemberLedger ledger) 
        : base(description, view, ledger)
        {}

        public override void ExecuteCommand() {
            int memberID = GetMemberID();
            model.Member member = _ledger.GetMember(memberID);

            if (member != null)
                {
                    if (member.Boats.Count > 0) 
                {

                    DisplayMessage("Find the ID of the boat you would like to update.");

                    for (int i = 0; i < member.Boats.Count; i++)
                    {
                        dynamic viewModelBoat = GetBoatDisplayModel(member.Boats[i]);
                        DisplayBoat(viewModelBoat);
                    } 

                    int boatID = GetBoatID();
                    BoatType boatType = GetBoatType();
                    int boatLength = GetBoatLength();

                    _ledger.UpdateBoat(memberID, boatID, boatType, boatLength);

                } 
                else 
                {
                    DisplayMessage("Member has no boats.");
                }
            }
        }
    }
}