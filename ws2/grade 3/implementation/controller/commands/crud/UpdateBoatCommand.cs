using System;
using System.Collections.Generic;

namespace MemberRegistry.controller.commands 
{
    class UpdateBoatCommand : CRUDCommand
    {
        public UpdateBoatCommand(string description, view.IView view, model.MemberLedger ledger) 
        : base(description, view, ledger)
        {}

        public override void ExecuteCommand() 
        {
            base._currentlySelectedMember = base.GetMember();

            base.DisplayBoats();
            this.UpdateBoat();
    }

    private void UpdateBoat()
    {
        model.Boat boat = base.GetBoat();
        BoatType boatType = base.GetBoatType();
        int boatLength = base.GetBoatLength();

        _ledger.UpdateBoat(this._currentlySelectedMember, boat, boatType, boatLength);
    }
}
}