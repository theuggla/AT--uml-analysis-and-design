using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistry.model
{
	class MemberLedger
	{
		private List<model.Member> _members;
		private persistance.IPersistance _persistance;

		public MemberLedger(persistance.IPersistance persistance)
		{
			this._persistance = persistance;
			this._members = InitiateMemberList();
		}

		public void CreateMember(string name, int personalNumber)
		{
			int newId = getNextMemberID();
	
			Member newMember = new Member(name, personalNumber, newId);
			this._members.Add(newMember);
		}

		public Member GetMember(int id)
		{
			try
			{
				return this._members
				.Where(x => x.MemberID == id)
				.ToList()[0];
			}
			catch (ArgumentOutOfRangeException e)
			{
				return null;
			}
		}

		public void DeleteMember(int id)
		{
			this._members
				.RemoveAll(x => x.MemberID == id);
		}

		public void UpdateMember(int id, string newName, int newPersonalNumber)
		{
			model.Member member = GetMember(id);

			if (member != null)
			{
				member.Name = newName;
            	member.PersonalNumber = newPersonalNumber;
			}
		}

        public List<Member> GetMembers()
		{
			return this._members;
		}

		public void RegisterBoat(int memberID, BoatType boatType, int boatLength)
		{
			model.Member member = GetMember(memberID);

			if (member != null)
			{
				member.AddBoat(boatType, boatLength);
			}
		}

		public void DeleteBoat(int memberID, int boatID)
		{
			model.Member member = GetMember(memberID);

			if (member != null)
			{
				member.RemoveBoat(boatID);
			}
		}

		public void UpdateBoat(int memberID, int boatID, BoatType type, int length)
		{
			model.Member member = GetMember(memberID);

			if (member != null)
			{
				member.UpdateBoat(boatID, type, length);
			}
		}

		public void SaveMemberList()
		{
			this._persistance.SaveMemberList(this._members);
		}

        private List<model.Member> InitiateMemberList()
		{
			List<model.Member> memberList = this._persistance.RetrieveMemberList() ?? new List<model.Member>();
			return memberList;
		}

		private int getNextMemberID() {
			int next = this._members.Count > 0 ? this._members[this._members.Count - 1].MemberID + 1 : 1;
			return next;
		}
	}
}