using System;
using System.Collections.Generic;

namespace MemberRegistry.controller 
{
    class ViewMemberCommand : BaseCommand, LoggedInCommand, LoggedOutCommand
    {
        private model.Member _currentMember;

       public ViewMemberCommand(string description, view.IView view, model.MemberLedger ledger) 
        : base(description, view, ledger)
        {}

        public override void ExecuteCommand() 
        {
            int memberID = GetMemberID();
            this._currentMember = _ledger.GetMember(memberID);

            if (this.MemberExists())
            {
                dynamic memberDisplayModel = GetMemberDisplayModel(this._currentMember);
                DisplayMember(memberDisplayModel);
            
                if (this._currentMember.Boats.Count > 0)
                {
                    this.DisplayMemberBoats();
                }
            }        
        }

        private bool MemberExists()
        {
            return this._currentMember != null;
        }

        private void DisplayMemberBoats()
        {
            DisplayMessage("Boats: ");
            
            foreach(model.Boat boat in this._currentMember.Boats)
            {
                dynamic boatDisplayModel = GetBoatDisplayModel(boat);
                DisplayBoat(boatDisplayModel);
            }
        }
    }
}