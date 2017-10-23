using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MemberRegistry.view
{
	class MainView : IView
	{
        private MenuView _menuView;
        private ConsoleUtil _console;

        public MainView()
        {
            this._console = new view.ConsoleUtil();
            this._menuView = new view.MenuView(this._console);
        }

        public void DisplayWelcomeMessage()
        {
            Console.Clear();
            Console.WriteLine("*****************************************");
            Console.WriteLine("** Hi and welcome to the boat registry **");
            Console.WriteLine("*****************************************");
            Console.WriteLine();
        }

        public void DisplaySuccessMessage(string prompt)
        {
            this._console.DisplaySuccessMessage(prompt);
        }

        public void DisplayFailureMessage(string prompt)
        {
            this._console.DisplayFailureMessage(prompt);
        }

        public string GetMemberPassword()
        {
            return this._console.GetUserString("Password: ");
        }

        public string GetMemberName()
        {
            return this._console.GetUserString("What is the name of the member?");
        }

        public int GetMemberPersonalNumber()
        {
            return this._console.GetUserInt("What is the personal number of the member?", 0);
        }

        public int GetBoatLength()
        {
            return this._console.GetUserInt("What is the length of the boat?");
        }

        public BoatType GetBoatType()
        {
             return this._console.GetUserEnum<BoatType>("What is the type of the boat?");
        }

        public model.Member GetCurrentUserLoginCredentials(model.MemberLedger ledger, ref string password)
        {
            bool login = this._console.GetUserBoolean("Do you want to log in?");

            if (login == true)
            {
                model.Member member = this.GetSelectedMember(ledger);
                password = this.GetMemberPassword();

                return member;
            }

            return null;
        }

        public model.Member GetSelectedMember(model.MemberLedger ledger)
        {
            Console.Clear();
            int id = this._console.GetUserInt("ID of member: ");
            return ledger.GetMember(id);
        }

        public model.Boat GetSelectedBoat(model.Member member)
        {
            int id = this._console.GetUserInt("ID of boat: ");
            return member.GetBoat(id);
        }

        public model.IMenuItem GetSelectedMenuItem<TMenuInterface>(string menuName, IEnumerable<model.IMenuItem> completeSelection)
        {
            return this._menuView.GetSelectedMenuItem<TMenuInterface>(menuName, completeSelection);
        }
        
        public void DisplayMembers(IEnumerable<model.Member> members) 
        {
            Console.Clear();

            if (members.Count() == 0)
            {
                System.Console.WriteLine("No members in the system!");
            }

            bool verbose = this._console.GetUserBoolean("Do you want detailed information?");
            string header = members.Count() > 1 ? "Member List" : "Member Info";

            System.Console.Clear();
            System.Console.WriteLine($"**********~{header}~**********");

            foreach (model.Member member in members) {
                System.Console.WriteLine();
                this.DisplayMember(member, verbose);
                System.Console.WriteLine();
            }

            System.Console.WriteLine($"**********~{header}~**********");
            System.Console.WriteLine();
            this._console.PauseUntilProceedIsIndicated();
        }

        private void DisplayMember(model.Member member, bool verbose) 
        {
            System.Console.WriteLine($"Member ID: {member.MemberID}");
            System.Console.WriteLine($"Name: {member.Name}");

            if (verbose)
            {
                System.Console.WriteLine($"Personal Number: {member.PersonalNumber}");
                System.Console.WriteLine();
                this.DisplayBoats(member.Boats);
            }
            else
            {
                System.Console.WriteLine($"Boats: {member.Boats.Count}");
                System.Console.WriteLine();
            }

            System.Console.WriteLine("-------------------------------------");
        }

        public void DisplayBoats(IEnumerable<model.Boat> boats) 
        {
            if (boats.Count() > 0)
            {
                System.Console.WriteLine("~~~~~~~~Boats~~~~~~~ ");
                foreach(model.Boat boat in boats)
                {
                    this.DisplayBoat(boat);
                }

            }
        }

        private void DisplayBoat(model.Boat boat) 
        {
            System.Console.WriteLine($"Boat ID: {boat.BoatID}");
            System.Console.WriteLine($"Boat Type: {boat.Type}");
            System.Console.WriteLine($"Boat Length: {boat.Length}");
            System.Console.WriteLine();
        }

    }
}