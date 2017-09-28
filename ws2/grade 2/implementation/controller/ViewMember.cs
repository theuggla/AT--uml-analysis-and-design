using System;
using System.Collections.Generic;

namespace MemberRegistry.controller 
{
    class ViewMember : BaseCommand
    {
       public ViewMember(string description, view.Console view, model.MemberLedger ledger) 
        : base(description, view, ledger)
        {}

        public override void ExecuteCommand() 
        {
            int memberID = GetMemberID();
            model.Member member = _ledger.GetMember(memberID);

            dynamic memberDisplayModel = GetMemberDisplayModel(member);
            DisplayMember(memberDisplayModel);
            
            if (member.Boats.Count > 0)
            {
                DisplayMessage("Boats: ");
                foreach(model.Boat boat in member.Boats)
                {
                    dynamic boatDisplayModel = GetBoatDisplayModel(boat);
                    DisplayBoat(boatDisplayModel);
                }
            }

        }
    }
}