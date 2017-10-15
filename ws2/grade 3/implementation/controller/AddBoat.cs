using System;
using System.Collections.Generic;

namespace MemberRegistry.controller 
{
    class AddBoat : BaseCommand
    {
        public AddBoat(string description, view.IView view, model.MemberLedger ledger) 
        : base(description, view, ledger)
        {}

        public override void ExecuteCommand() {
            int memberID = GetMemberID();
            BoatType boatType = GetBoatType();
            int boatLength = GetBoatLength();

            _ledger.RegisterBoat(memberID, boatType, boatLength);
        }
    }
}