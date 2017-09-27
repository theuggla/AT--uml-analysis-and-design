using System;
using System.Collections.Generic;

namespace MemberRegistry.model
{
    public class Member
    {
        public string Name {get; set;}
        public int PersonalNumber {get; set;}
        public int MemberID {get; set;}

        public List<Boat> boats;

        public Member(string name, int number, int id)
        {
            this.Name = name;
            this.PersonalNumber = number;
            this.MemberID = id;

            boats = new List<Boat>();
        }

        public void AddBoat(Dictionary<string, string> data)
        {
            int newId = GetNextBoatID();

			int length;
			int.TryParse(data["length"], out length);

            BoatType type = (BoatType)Enum.Parse(typeof(BoatType), data["type"]);

			Boat newBoat = new Boat(type, length, newId);
			boats.Add(newBoat);
        }

        public void RemoveBoat(int boatPosition) {
            this.boats.RemoveAt(boatPosition);
        }

        public void UpdateBoat(int boatPosition, Dictionary<string, string> data) {
            int length;
			int.TryParse(data["length"], out length);

            BoatType type = (BoatType)Enum.Parse(typeof(BoatType), data["type"]);

            this.boats[boatPosition].Update(type, length);
        }

        private int GetNextBoatID()
        {
            int newt = boats.Count > 0 ? boats[boats.Count - 1].BoatID + 1 : 1;
			return newt;
        } 
    }
}