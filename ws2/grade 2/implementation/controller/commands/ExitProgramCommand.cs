using System;
using System.Collections.Generic;

namespace MemberRegistry.controller 
{
    class ExitProgramCommand : BaseCommand
    {
        public ExitProgramCommand(string description, view.IView view, model.MemberLedger ledger) 
        : base(description, view, ledger)
        {}

        public override void ExecuteCommand() {
            DisplayMessage("Program will be exited.");
            System.Environment.Exit(0);
        }
    }
}