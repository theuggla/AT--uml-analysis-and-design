using System;
using System.Collections.Generic;

namespace MemberRegistry.controller 
{
    class AddBoat : IMenuItemCommand
    {
        public string Description {get;}
        public MenuCategory[] Tags {get;}

        public AddBoat(MenuCategory[] tags, string description) {
            this.Tags = tags;
            this.Description = description;
        }

        public void ExecuteCommand(model.MemberRegistry registry, Dictionary<string, string> data) {
            int memberID;
            int.TryParse(data["id"], out memberID);

            registry.RegisterBoat(memberID, data);
        }

        public Dictionary<string, string> GetData(view.Console view) {

            Dictionary<string, string> data = new Dictionary<string, string>();

            string id = view.GetUserString("What is the id of the member you would like to add boat to?");
            data.Add("id", id);


            view.DisplayInstructions("Please give the new boat details:");
            string type = view.GetUserString("What is the type of the boat?");
            string length = view.GetUserString("What is the length of the boat?");

            data.Add("type", type);
            data.Add("length", length);

            return data;
        }
    }
}