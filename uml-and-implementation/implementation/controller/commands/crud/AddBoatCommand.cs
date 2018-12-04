using System;
using System.Collections.Generic;

namespace MemberRegistry.controller.commands 
{
    class AddBoatCommand : CRUDCommand
    {
        public AddBoatCommand(string description, view.IView view, model.MemberLedger ledger) 
        : base(description, view, ledger)
        {}

        public override void ExecuteCommand() {
            model.Member member = base.GetMember();
            BoatType boatType = base.GetBoatType();
            int boatLength = base.GetBoatLength();

            base._ledger.RegisterBoat(member, boatType, boatLength);
        }
    }
}