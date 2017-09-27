using System;
using System.Collections.Generic;

namespace MemberRegistry.controller 
{
    class ExitProgram : IMenuItemCommand
    {
        public string Description {get;}
        public MenuCategory[] Tags {get;}

        public ExitProgram(MenuCategory[] tags, string description) {
            this.Tags = tags;
            this.Description = description;
        }

        public void ExecuteCommand(model.MemberRegistry registry, Dictionary<string, string> data) {
            System.Environment.Exit(0);
        }

        public Dictionary<string, string> GetData(view.Console view) {

            view.DisplayInstructions("Program will be exited.");

            Dictionary<string, string> data = new Dictionary<string, string>();

            return data;
        }
    }
}