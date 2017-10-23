using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MemberRegistry.view
{
	interface IView
	{
		void DisplayWelcomeMessage();
		void DisplaySuccessMessage(string prompt);
		void DisplayFailureMessage(string prompt);
        void DisplayMembers(IEnumerable<model.Member> members);
		void DisplayBoats(IEnumerable<model.Boat> boats);
		model.Member GetCurrentUserLoginCredentials(model.MemberLedger ledger, ref string password);
		model.Member GetSelectedMember(model.MemberLedger ledger);
		model.Boat GetSelectedBoat(model.Member member);
		model.IMenuItem GetSelectedMenuItem<TMenuInterface>(string menuName, IEnumerable<model.IMenuItem> completeSelection);
		string GetMemberPassword();
		string GetMemberName();
		int GetMemberPersonalNumber();
        int GetBoatLength();
        BoatType GetBoatType();
	}
}