using System;
using System.Collections.Generic;

namespace MemberRegistry.controller 
{
    class AddMember : IMenuItemCommand
    {
        public string Description {get;}
        public MenuCategory[] Tags {get;}

        public AddMember(MenuCategory[] tags, string description) {
            this.Tags = tags;
            this.Description = description;
        }

        public void ExecuteCommand(model.MemberRegistry registry, Dictionary<string, string> data) {
            registry.CreateMember(data);
        }

        public Dictionary<string, string> GetData(view.Console view) {

            view.DisplayInstructions("Please give the member details:");
            string name = view.GetUserString("What is the name of the member?");
            string number = view.GetUserString("What is the personal number of the member?");

            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("name", name);
            data.Add("number", number);

            return data;
        }
    }
}