using System;
using System.Collections.Generic;

namespace MemberRegistry.controller 
{
    abstract class BaseCommand
    {
        public string Description {get;}

        private view.Console _view;

        public delegate void MemberActionCall(int memberID);

        public BaseCommand(string description, view.Console view) {
            this.Description = description;
            this._view = view;
        }

        protected string GetMemberName()
        {
            return this._view.GetUserString("What is the name of the member?");
        }

        protected int GetMemberPersonalNumber()
        {
            return this._view.GetUserInt("What is the personal number of the member?", 0);
        }

        protected int GetMemberID()
        {
            return this._view.GetUserInt("What is the ID of the member?");
        }

        protected int GetBoatLength()
        {
            return this._view.GetUserInt("What is the length of the boat?");
        }

        protected BoatType GetBoatType()
        {
             BoatType type = _view.GetUserEnum<BoatType>("What is the type of the boat?");
             return type;
        }

        protected int GetBoatID()
        {
            return this._view.GetUserInt("What is the ID of the boat?");
        }

        protected dynamic GetMemberDisplayModel(model.Member member, bool verbose = true)
        {
            dynamic displayModel = verbose ? GetVerboseDisplayModel(member) : GetCompactDisplayModel(member);
            return displayModel;
        }
            
        protected dynamic GetBoatDisplayModel(model.Boat boat)
        {
            dynamic displayModel = new {BoatID = boat.BoatID, Length = boat.Length, BoatType = boat.Type.ToString()};

            return displayModel;
        }

        protected void DisplayMember(dynamic memberDisplayModel)
        {
            this._view.DisplayUserInfo(memberDisplayModel);
        }

        protected void DisplayBoat(dynamic boatDisplayModel)
        {
            this._view.DisplayUserInfo(boatDisplayModel);
        }

        protected void DisplayMessage(string prompt)
        {
            this._view.DisplayMessage(prompt);
        }

        protected bool GetUserBoolean(string prompt)
        {
            return this._view.GetUserBoolean(prompt);
        }

        private dynamic GetVerboseDisplayModel(model.Member member)
        {

            string name = member.Name;
            int personalNumber = member.PersonalNumber;
            int memberID = member.MemberID;
        
            return new {
                        Name = name, 
                        PersonalNumber = personalNumber, 
                        MemberID = memberID
                    };
        }

        private dynamic GetCompactDisplayModel(model.Member member)
        {
            dynamic displayModel = new {
                                    Name = member.Name, 
                                    PersonalNumber = member.PersonalNumber, 
                                    MemberID = member.MemberID,
                                    Boats = member.Boats.Count
                                };
            return displayModel;

        }
    }
}