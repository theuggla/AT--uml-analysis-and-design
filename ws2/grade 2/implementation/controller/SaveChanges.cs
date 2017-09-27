using System;
using System.Collections.Generic;

namespace MemberRegistry.controller 
{
    class SaveChanges : IMenuItemCommand
    {
        public string Description {get;}
        public MenuCategory[] Tags {get;}

        public SaveChanges(MenuCategory[] tags, string description) {
            this.Tags = tags;
            this.Description = description;
        }

        public void ExecuteCommand(model.MemberRegistry registry, Dictionary<string, string> data) {
            registry.SaveMemberList();
        }

        public Dictionary<string, string> GetData(view.Console view) {

            view.DisplayInstructions("Changes will be saved.");

            Dictionary<string, string> data = new Dictionary<string, string>();

            return data;
        }
    }
}