using System;
using System.Collections.Generic;

namespace MemberRegistry.controller 
{
    class ExitProgramCommand : BaseCommand, LoggedOutCommand, LoggedInCommand
    {
        public ExitProgramCommand(string description, view.IView view, model.MemberLedger ledger) 
        : base(description, view, ledger)
        {}

        public override void ExecuteCommand() {
            DisplayMessage("Program will be exited and changes saved.");
            _ledger.SaveMemberList();
            System.Environment.Exit(0);
        }
    }
}