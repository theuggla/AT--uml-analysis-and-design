using System;
using System.Collections.Generic;

namespace MemberRegistry.controller.commands 
{
    abstract class CRUDCommand : DisplayCommand, ILoggedInCommand
    {
        public CRUDCommand(string description, view.IView view, model.MemberLedger ledger) 
        : base(description, view, ledger)
        {}

        public void EnsureUserIsLoggedIn(model.Member member)
        {
            if (!member.IsLoggedIn)
            {
                throw new Exception();
            }
        }

        protected string GetMemberName()
        {
            return this._view.GetMemberName();
        }

        protected string GetMemberPersonalNumber()
        {
            return this._view.GetMemberPersonalNumber();
        }

        protected int GetBoatLength()
        {
            return this._view.GetBoatLength();
        }

        protected BoatType GetBoatType()
        {
            return this._view.GetBoatType();
        }
    }
}