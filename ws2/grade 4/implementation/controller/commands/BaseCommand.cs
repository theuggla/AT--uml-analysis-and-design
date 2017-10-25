using System;
using System.Linq;
using System.Collections.Generic;

namespace MemberRegistry.controller.commands 
{
    abstract class BaseCommand : model.IMenuItem
    {
        private string _description;
        protected model.MemberLedger _ledger;
        protected view.IView _view;
        protected model.Member _currentlySelectedMember;

        public BaseCommand(string description, view.IView view, model.MemberLedger ledger) 
        {
            this._description = description;
            this._view = view;
            this._ledger = ledger;
        }

        public abstract void ExecuteCommand();

        public string GetDescription()
        {
            return this._description;
        }

        protected model.Member GetMember()
        {
            return this._view.GetSelectedMember(this._ledger);
        }

        protected string GetMemberPassword()
        {
            return this._view.GetMemberPassword();
        }

        protected void DisplaySuccessMessage(string prompt)
        {
            this._view.DisplaySuccessMessage(prompt);
        }

        protected void DisplayFailureMessage(string prompt)
        {
            this._view.DisplayFailureMessage(prompt);
        }

        protected bool MemberHasBoats()
        {
            return this._currentlySelectedMember.Boats.Count > 0;
        }

        protected model.Boat GetBoat()
        {
            return this._view.GetSelectedBoat(this._currentlySelectedMember);
        }
    }
}