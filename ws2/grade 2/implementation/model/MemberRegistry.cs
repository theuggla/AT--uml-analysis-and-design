using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistry.model
{
	class MemberRegistry
	{
		public List<model.Member> members;
		public Persistance persistance;

		public MemberRegistry()
		{
			try
            {
				this.persistance = new Persistance();
				this.members = InitiateMemberList();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
			
		}

		private List<model.Member> InitiateMemberList()
		{

			var data = persistance.ReadJson("saved.json") ?? new List<Member>();
			return data;
		}

		public void CreateMember(Dictionary<string, string> data)
		{
			int newId = getNextMemberID();
			Console.WriteLine(newId);
			int personalNumber;
			int.TryParse(data["number"], out personalNumber);
			Member newMember = new Member(data["name"], personalNumber, newId);
			members.Add(newMember);
		}

		public List<Member> ListMembers()
		{
			return members;
		}

		public Member GetMember(int id)
		{
			return members
				.Where(x => x.MemberID == id)
				.ToList()[0];
		}

		public void DeleteMember(int id)
		{
			members
				.RemoveAll(x => x.MemberID == id);
		}

		public void UpdateMember(int id, Dictionary<string, string> data)
		{
			var member = members
				.Where(x => x.MemberID == id)
				.ToList()[0];

				int personalNumber;
				int.TryParse(data["number"], out personalNumber);

				member.Name = data["name"];
				member.PersonalNumber = personalNumber;
		}

		public void RegisterBoat(int memberID, Dictionary<string, string> data)
		{
			var member = members
				.Where(x => x.MemberID == memberID)
				.ToList()[0];

				member.AddBoat(data);
		}

		public void DeleteBoat(int memberID, int boatPos)
		{
			var member = members
				.Where(x => x.MemberID == memberID)
				.ToList()[0];

				member.RemoveBoat(boatPos);


		}

		public void UpdateBoat(int memberID, int boatPos, Dictionary<string, string> data)
		{
			var member = members
				.Where(x => x.MemberID == memberID)
				.ToList()[0];

				member.UpdateBoat(boatPos, data);
		}


		public void SaveMemberList()
		{
			persistance.WriteJson("saved.json", members);
		}

		private int getNextMemberID() {
			int newt = members.Count > 0 ? members[members.Count - 1].MemberID + 1 : 1;
			return newt;
		}
	}
}