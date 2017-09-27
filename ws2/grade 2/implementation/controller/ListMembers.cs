using System;
using System.Collections.Generic;

namespace MemberRegistry.controller 
{
    class ListMembers : IMenuItemCommand
    {
        public string Description {get;}
        public MenuCategory[] Tags {get;}

        private view.Console view; 

        public ListMembers(MenuCategory[] tags, string description, view.Console view) {
            this.Tags = tags;
            this.Description = description;
            this.view = view;
        }

        public void ExecuteCommand(model.MemberRegistry registry, Dictionary<string, string> data) {
            List<model.Member> members = registry.ListMembers();
            if (data["detailed"] == "yes") {
                foreach (model.Member member in members) {
                dynamic viewModelMember = new {Name = member.Name, PersonalNumber = member.PersonalNumber, MemberID = member.MemberID};
                view.DisplayUserInfo(viewModelMember);

                if (member.boats.Count > 0) {
                    view.DisplayInstructions("Boats:");
                    int i = 1;
                    foreach (model.Boat boat in member.boats) {
                    dynamic viewModelBoat = new {Number = i, Length = boat.Length, BoatType = boat.Type.ToString()};
                    i++;

                    view.DisplayUserInfo(viewModelBoat);
                    }
                }
                }
            } else {
                foreach (model.Member member in members) {
                dynamic viewModelMember = new {Name = member.Name, MemberID = member.MemberID, BoatCount = member.boats.Count};
                view.DisplayUserInfo(viewModelMember);
                }
            }
        }

        public Dictionary<string, string> GetData(view.Console view) {

            string answer = view.GetUserString("Would you like a detailed list? (y/n)");

            Dictionary<string, string> data = new Dictionary<string, string>();

            if (answer == "y") {
                data.Add("detailed", "yes");
            } else {
                data.Add("detailed", "no");
            }

            return data;
        }
    }
}