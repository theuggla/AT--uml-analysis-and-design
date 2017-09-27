using System;
using System.Collections.Generic;

namespace MemberRegistry.controller 
{
    class UpdateMember : IMenuItemCommand
    {
        public string Description {get;}
        public MenuCategory[] Tags {get;}

        public UpdateMember(MenuCategory[] tags, string description) {
            this.Tags = tags;
            this.Description = description;
        }

        public void ExecuteCommand(model.MemberRegistry registry, Dictionary<string, string> data) {
            int id;
            int.TryParse(data["id"], out id);

            registry.UpdateMember(id, data);
        }

        public Dictionary<string, string> GetData(view.Console view) {
            Dictionary<string, string> data = new Dictionary<string, string>();

            string id = view.GetUserString("What is the id of the member you would like to update?");
            data.Add("id", id);


            view.DisplayInstructions("Please give the new member details:");
            string name = view.GetUserString("What is the name of the member?");
            string number = view.GetUserString("What is the personal number of the member?");

            data.Add("name", name);
            data.Add("number", number);

            return data;

        }
    }
}