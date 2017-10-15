using System;
using System.Collections.Generic;

namespace MemberRegistry.controller 
{
    class UpdateBoatCommand : BaseCommand
    {
        private model.Member _currentMember;

        public UpdateBoatCommand(string description, view.IView view, model.MemberLedger ledger) 
        : base(description, view, ledger)
        {}

        public override void ExecuteCommand() 
        {
            int memberID = GetMemberID();
            this._currentMember = _ledger.GetMember(memberID);

            if (this.MemberExists())
            {
                if (this.MemberHasBoats()) 
                {
                    DisplayMessage("Find the ID of the boat you would like to update.");
                    this.DisplayBoats();
                    this.UpdateBoat();
                } 
                else 
                {
                    DisplayMessage("Member has no boats.");
                }
        }
    }

    private bool MemberExists()
    {            
        return this._currentMember != null;
    }

    private bool MemberHasBoats()
    {            
        return this._currentMember.Boats.Count > 0;
    }

    private void DisplayBoats()
    {
        DisplayMessage("Boats: ");
        foreach(model.Boat boat in this._currentMember.Boats)
        {
            dynamic boatDisplayModel = GetBoatDisplayModel(boat);
            DisplayBoat(boatDisplayModel);
        }
    }

    private void UpdateBoat()
    {
        int boatID = GetBoatID();
        BoatType boatType = GetBoatType();
        int boatLength = GetBoatLength();

        _ledger.UpdateBoat(this._currentMember.MemberID, boatID, boatType, boatLength);
    }
}
}