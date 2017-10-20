using System;
using System.Collections.Generic;

namespace MemberRegistry.controller 
{
    class DeleteBoatCommand : BaseCommand, LoggedInCommand
    {
        private model.Member _currentMember;

        public DeleteBoatCommand(string description, view.IView view, model.MemberLedger ledger) 
        : base(description, view, ledger)
        {}
        
        public override void ExecuteCommand() {
            
            int memberID = GetMemberID();
            this._currentMember = _ledger.GetMember(memberID);

            if (this.MemberExists() && this.MemberHasBoats())
            {
                this.DeleteMemberBoat();
            } else {
                DisplayMessage("Member doesn't exist or has no boats.");
            }
        }

        private bool MemberExists()
        {
            return this._currentMember != null;
        }

        private void DeleteMemberBoat()
        {
            DisplayMessage("Find the ID of the boat you would like to delete.");
            this.DisplayBoats();
            int boatID = GetBoatID();
            _ledger.DeleteBoat(this._currentMember.MemberID, boatID);
        }

        private bool MemberHasBoats()
        {
            return this._currentMember.Boats.Count > 0;
        }

        private void DisplayBoats()
        {
            for (int i = 0; i < this._currentMember.Boats.Count; i++)
            {
                dynamic viewModelBoat = GetBoatDisplayModel(this._currentMember.Boats[i]);
                DisplayBoat(viewModelBoat);
            } 
        }
    }
}