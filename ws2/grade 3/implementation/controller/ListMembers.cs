using System;
using System.Collections.Generic;

namespace MemberRegistry.controller 
{
    class ListMembers : BaseCommand
    {
        public ListMembers(string description, view.IView view, model.MemberLedger ledger) 
        : base(description, view, ledger)
        {}

        public override void ExecuteCommand() {

            List<model.Member> members = _ledger.GetMembers();

            bool verbose = GetUserBoolean("Would you like a detailed list?");

            if (members.Count == 0) 
            {
                DisplayMessage("No members of the club in the system.");
            }

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