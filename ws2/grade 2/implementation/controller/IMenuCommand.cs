using System;
using System.Collections.Generic;

namespace MemberRegistry.controller
{
    interface IMenuItemCommand
    {
        string Description {get;}
        MenuCategory[] Tags {get;}

        void ExecuteCommand(model.MemberRegistry registry, Dictionary<string, string> data);

        Dictionary<string, string> GetData(view.Console view);
    }
}