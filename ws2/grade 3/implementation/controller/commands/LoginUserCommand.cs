using System;
using System.Collections.Generic;

namespace MemberRegistry.controller 
{
    class LoginUserCommand : BaseCommand, LoggedOutCommand
    {
        public LoginUserCommand(string description, view.IView view, model.MemberLedger ledger) 
        : base(description, view, ledger)
        {}

        public override void ExecuteCommand() {
            int memberID = GetMemberID();
            string password = GetMemberPassword();

            _ledger.LoginMember(memberID, password);
        }
    }
}