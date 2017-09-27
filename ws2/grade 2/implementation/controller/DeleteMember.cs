using System;
using System.Collections.Generic;

namespace MemberRegistry.controller 
{
    class DeleteMember : IMenuItemCommand
    {
        public string Description {get;}
        public MenuCategory[] Tags {get;}

        public DeleteMember(MenuCategory[] tags, string description) {
            this.Tags = tags;
            this.Description = description;
        }

        public void ExecuteCommand(model.MemberRegistry registry, Dictionary<string, string> data) {
            int id;
            int.TryParse(data["number"], out id);
            registry.DeleteMember(id);
        }

        public Dictionary<string, string> GetData(view.Console view) {

            string number = view.GetUserString("What is the id of the member you would like to delete?");

            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("number", number);

            return data;
        }
    }
}