using System;
using System.Collections.Generic;

namespace MemberRegistry.controller 
{
    class ViewMember : BaseCommand, IMenuItemCommand
    {
        public MenuCategory[] Tags {get;}

        public ViewMember(MenuCategory[] tags, string description, view.Console view) 
        : base(description, view)
        {
            this.Tags = tags;
        }

        public void ExecuteCommand(model.MemberLedger ledger) 
        {
            int memberID = GetMemberID();
            model.Member member = ledger.GetMember(memberID);

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