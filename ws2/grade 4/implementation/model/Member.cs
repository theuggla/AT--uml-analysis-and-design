using System;
using System.Linq;
using System.Collections.Generic;

namespace MemberRegistry.model
{
    public class Member
    {
        private Password _password;
        private bool _isLoggedIn;
        private string _name;
        private List<Boat> _boats;
        private PersonalNumber _personalNumber;

        public string Name 
        {
            get
            {
                return this._name;
            }
        }

        public string Password
        {
            get
            {
                return this._password.GetPassword();
            }
        }

        public string PersonalNumber
        {
            get
            {
                return this._personalNumber.Number;
            }
            set
            {
                this._personalNumber.Number = value;
            }
        }

        public bool IsLoggedIn 
        {
            get
            {
                return this._isLoggedIn;
            }
        }
        
        public int MemberID {get; set;}

        public IReadOnlyCollection<Boat> Boats 
        {
            get
            {
                return this._boats.AsReadOnly();
            } 
        }

        public Member(string name, string password, string number, int id)
        {
            this._isLoggedIn = false;
            this.MemberID = id;
            this._boats = new List<Boat>();

            this._name = name;
            this._password = new Password(password);
            this._personalNumber = new PersonalNumber(number);
        }

        public void LoginMember(string attemptedPassword)
        {
            if (this.PasswordIsCorrect(attemptedPassword))
            {
                this._isLoggedIn = true;
            }
            else
            {
                throw new IncorrectCredentialsException();
            }
        }

        public void LogoutMember()
        {
            this._isLoggedIn = false;
        }

        public void UpdateMember(string newName, string newPersonalNumber)
        {
            this._name = newName;
            this.PersonalNumber = newPersonalNumber;
        }

        public model.Boat GetBoat(int id)
        {
			return this._boats.Where(boat => boat.BoatID == id).ToList()[0];
        }

        public void AddBoat(BoatType type, int length)
        {
            int newId = GetNextBoatID();
			Boat newBoat = new Boat(type, length, newId);
			this._boats.Add(newBoat);
        }

        public void RemoveBoat(model.Boat boat) 
        {
            this._boats.Remove(boat);
        }

        public void UpdateBoat(model.Boat boat, BoatType type, int length) 
        {
            boat.Update(type, length);
        }

        private bool PasswordIsCorrect(string attemptedPassword)
        {
            return this._password.IsPasswordCorrect(attemptedPassword);
        }

        private int GetNextBoatID()
        {
            int next = this._boats.Count > 0 ? this._boats[this._boats.Count - 1].BoatID + 1 : 1;
			return next;
        }
    }
}