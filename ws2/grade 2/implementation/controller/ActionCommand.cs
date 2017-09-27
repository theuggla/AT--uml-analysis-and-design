using System;
using System.Collections.Generic;

namespace MemberRegistry.controller 
{
    abstract class ActionCommand : BaseCommand
    {

        public void ExecuteCommand(Action<Dictionary<string, string>> action) {
            Dictionary<string, string> data = this.GetData();
            action(data);
        }

        protected abstract Dictionary<string, string> GetData();

        protected abstract void DisplayData(Dictionary<string, string> data);
    }
}