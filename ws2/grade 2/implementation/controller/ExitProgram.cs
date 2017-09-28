using System;
using System.Collections.Generic;

namespace MemberRegistry.controller 
{
    class ExitProgram : BaseCommand
    {
        public ExitProgram(string description, view.Console view, model.MemberLedger ledger) 
        : base(description, view, ledger)
        {}

        public override void ExecuteCommand() {
            DisplayMessage("Program will be exited.");
            System.Environment.Exit(0);
        }
    }
}