using System;
using System.Collections.Generic;

namespace MemberRegistry.controller
{
    interface IMenuItemCommand
    {
        string Description {get;}
        MenuCategory[] Tags {get;}

        void ExecuteCommand(model.MemberLedger ledger);
    }
}