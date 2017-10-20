using System;
using System.Collections.Generic;

namespace MemberRegistry.controller 
{
    class LogoutUserCommand : BaseCommand, LoggedInCommand
    {
        public LogoutUserCommand(string description, view.IView view, model.MemberLedger ledger) 
        : base(description, view, ledger)
        {}

        public override void ExecuteCommand() {
            _ledger.LogoutMember();
        }
    }
}