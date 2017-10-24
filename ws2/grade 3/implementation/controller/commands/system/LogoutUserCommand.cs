using System;
using System.Collections.Generic;

namespace MemberRegistry.controller.commands 
{
    class LogoutUserCommand : BaseCommand, ILoggedInCommand
    {
        public LogoutUserCommand(string description, view.IView view, model.MemberLedger ledger) 
        : base(description, view, ledger)
        {}

        public override void ExecuteCommand() 
        {
            _ledger.LogoutMember();
        }
    }
}