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

		public void CreateMember(string name, string password, int personalNumber)
		{
			int newId = getNextMemberID();
	
			Member newMember = new Member(name, password, personalNumber, newId);
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

		public void DeleteMember(model.Member member)
		{
			this._members
				.Remove(member);
		}

		public void UpdateMember(model.Member member, string newName, int newPersonalNumber)
		{
			if (member != null)
			{
				member.Name = newName;
            	member.PersonalNumber = newPersonalNumber;
			}
		}

        public IEnumerable<Member> GetMembers()
		{
			return this._members;
		}

		public void RegisterBoat(model.Member member, BoatType boatType, int boatLength)
		{
			if (member != null)
			{
				member.AddBoat(boatType, boatLength);
			}
		}

		public void DeleteBoat(model.Member member, model.Boat boat)
		{
			if (member != null)
			{
				member.RemoveBoat(boat);
			}
		}

		public void UpdateBoat(model.Member member, model.Boat boat, BoatType type, int length)
		{
			if (member != null)
			{
				member.UpdateBoat(boat, type, length);
			}
		}

		public void LoginMember(model.Member member)
		{
			member.IsLoggedIn = true;
		}

		public void LogoutMember()
		{
			model.Member member = this.GetLoggedInMember();
			
			if (member != null) {
				member.IsLoggedIn = false;
			}
		}
		
		public void SaveMemberList()
		{
			this._persistance.SaveMemberList(this._members);
		}

		public IEnumerable<model.ISearchCriteria> GetSearchCriteriaList()
		{
			List<model.ISearchCriteria> criteria = new List<model.ISearchCriteria>();
			criteria.Add(new model.HasCanoeCriteria());
			return criteria;
		}

		public IEnumerable<model.Member> Search(model.ISearchCriteria criteria)
		{
			return criteria.ExecuteCriteria(this._members);
		}

		private model.Member GetLoggedInMember()
		{
			try
			{
				model.Member member = this._members
				.Where(x => x.IsLoggedIn == true)
				.ToList()[0];

				return member;
			}
			catch (ArgumentOutOfRangeException e)
			{
				return null;
			}
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