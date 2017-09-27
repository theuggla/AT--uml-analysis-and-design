using System;
using System.Linq;
using System.Collections.Generic;

namespace MemberRegistry.model
{
    public class Member
    {
        public string Name {get; set;}
        public int PersonalNumber {get; set;}
        public int MemberID {get; set;}
        public List<Boat> Boats {get; set;}

        public Member(string name, int number, int id)
        {
            this.Name = name;
            this.PersonalNumber = number;
            this.MemberID = id;

            this.Boats = new List<Boat>();
        }

        public void AddBoat(BoatType type, int length)
        {
            int newId = GetNextBoatID();
			Boat newBoat = new Boat(type, length, newId);
			this.Boats.Add(newBoat);
        }

        public void RemoveBoat(int id) {
            this.Boats.RemoveAll(x => x.BoatID == id);
        }

        public void UpdateBoat(int boatID, BoatType type, int length) {
            Boat boat = this.Boats
                .Where(x => x.BoatID == boatID)
                .ToList()[0];

            boat.Update(type, length);
        }

        private int GetNextBoatID()
        {
            int next = this.Boats.Count > 0 ? this.Boats[this.Boats.Count - 1].BoatID + 1 : 1;
			return next;
        } 
    }
}