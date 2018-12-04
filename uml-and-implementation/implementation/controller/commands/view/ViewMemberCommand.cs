using System;
using System.Collections.Generic;

namespace MemberRegistry.controller.commands
{
    class ViewMemberCommand : DisplayCommand
    {
       public ViewMemberCommand(string description, view.IView view, model.MemberLedger ledger) 
        : base(description, view, ledger)
        {}

        public override void ExecuteCommand() 
        {
            base._currentlySelectedMember = base.GetMember();
            base.DisplayMember();      
        }
    }
}