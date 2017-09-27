using System;
using System.Collections.Generic;

namespace MemberRegistry.controller 
{
    class ListMembers : BaseCommand, IMenuItemCommand
    {
        public MenuCategory[] Tags {get;}

        public ListMembers(MenuCategory[] tags, string description, view.Console view) 
        : base(description, view)
        {
            this.Tags = tags;
        }

        public void ExecuteCommand(model.MemberLedger ledger) {

            List<model.Member> members = (List<model.Member>)ledger.ListMembers();
            bool verbose = GetUserBoolean("Would you like a detailed list?");

            foreach (model.Member member in members) {
                dynamic displayModel = GetMemberDisplayModel(member, verbose);
                DisplayMember(displayModel);

                if (verbose)
                {
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
    }
}