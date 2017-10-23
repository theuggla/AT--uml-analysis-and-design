using System;
using System.Collections.Generic;

namespace MemberRegistry.controller 
{
    class ExitProgramCommand : BaseCommand, ILoggedOutCommand, ILoggedInCommand
    {
        public ExitProgramCommand(string description, view.IView view, model.MemberLedger ledger) 
        : base(description, view, ledger)
        {}

        public override void ExecuteCommand() {
            _ledger.SaveMemberList();
            System.Environment.Exit(0);
        }
    }
}