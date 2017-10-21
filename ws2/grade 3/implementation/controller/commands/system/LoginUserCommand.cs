using System;
using System.Collections.Generic;

namespace MemberRegistry.controller 
{
    class LoginUserCommand : BaseCommand, ILoggedOutCommand
    {
        public LoginUserCommand(string description, view.IView view, model.MemberLedger ledger) 
        : base(description, view, ledger)
        {}

        public override void ExecuteCommand() {
            model.Member member = base.GetMember();
            string password = base.GetMemberPassword();

            if (member.Password == password)
            {
                _ledger.LoginMember(member);
                base.DisplaySuccessMessage("Member successfully logged in!");
            }
            else
            {
                base.DisplayFailureMessage("Wrong ID or password.");
            }
        }
    }
}