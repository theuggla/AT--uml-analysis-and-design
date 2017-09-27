using System;
using System.Collections.Generic;

namespace MemberRegistry.controller 
{
    class UpdateBoat : IMenuItemCommand
    {
        public string Description {get;}
        public MenuCategory[] Tags {get;}

        private view.Console view;

        public UpdateBoat(MenuCategory[] tags, string description, view.Console view) {
            this.Tags = tags;
            this.Description = description;
            this.view = view;
        }

        public void ExecuteCommand(model.MemberRegistry registry, Dictionary<string, string> data) {
            int memberID;
            int.TryParse(data["id"], out memberID);
            model.Member member = registry.GetMember(memberID);

            if (member.boats.Count > 0) {
                    int i = 1;
                    view.DisplayInstructions("Boats:");
                    foreach (model.Boat boat in member.boats) {
                    dynamic viewModelBoat = new {Number = i, Length = boat.Length, BoatType = boat.Type.ToString()};
                    i++;
                    view.DisplayUserInfo(viewModelBoat);
                    } 

                    int boatID = view.GetUserInt("Which boat would you like to update?", 1, member.boats.Count);

                    view.DisplayInstructions("Please give the new boat details:");
                    string type = view.GetUserString("What is the type of the boat?");
                    string length = view.GetUserString("What is the length of the boat?");

                    data.Add("type", type);
                    data.Add("length", length);

                    registry.UpdateBoat(memberID, boatID - 1, data);

                    } else {
                        view.DisplayInstructions("Member has no boats.");
                    }


        }

        public Dictionary<string, string> GetData(view.Console view) {

            string number = view.GetUserString("What is the id of the member whose boat you would like to update?");

            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("id", number);

            return data;
        }
    }
}