using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace MemberRegistry.controller
{
	class User
	{
		private view.IView _view;
		private model.MemberLedger _ledger;
		private view.Menu _menu;

		public User(view.IView view, model.MemberLedger ledger)
		{
			_view = view;
			_ledger = ledger;
			_menu = new view.Menu();
			PopulateMenu();
		}

		public void StartProgram()
		{
			_view.DisplayMessage("Hi.");

			while (true)
			{
				_view.ShowMenu(this._menu.MenuItems);
				controller.BaseCommand useCase = this.GetCorrectUseCase();
				PlayOutUseCase(useCase);
			}
		}

		private controller.BaseCommand GetCorrectUseCase()
		{
			int userChoice = this._view.GetUserInt("Chose a number in the menu", 1, this._menu.MenuItems.Count());
			return this._menu.MenuItems.ElementAt(userChoice - 1);
		}

		private void PlayOutUseCase(controller.BaseCommand useCase)
		{
			useCase.ExecuteCommand();
		}

		private void PopulateMenu()
		{
			AddMember addMemberUseCase = new AddMember("Create Member", this._view, this._ledger);
			ViewMember viewMemberUseCase = new ViewMember("View Member", this._view, this._ledger);
			UpdateMember updateMemberUseCase = new UpdateMember("Update Member", this._view, this._ledger);
			DeleteMember deleteMemberUseCase = new DeleteMember("Delete Member", this._view, this._ledger);
			ListMembers listMembersUseCase = new ListMembers("List Members", this._view, this._ledger);
			AddBoat addBoatUseCase = new AddBoat("Add Boat", this._view, this._ledger);
			UpdateBoat updateBoatUseCase = new UpdateBoat("Update Boat", this._view, this._ledger);
			DeleteBoat deleteBoatUseCase = new DeleteBoat("Delete Boat", this._view, this._ledger);
			SaveChanges saveChangesUseCase = new SaveChanges("Save Changes", this._view, this._ledger);
			ExitProgram exitProgramUseCase = new ExitProgram("Exit Program", this._view, this._ledger);

			this._menu.Add(addMemberUseCase);
			this._menu.Add(viewMemberUseCase);
			this._menu.Add(updateMemberUseCase);
			this._menu.Add(deleteMemberUseCase);
			this._menu.Add(listMembersUseCase);
			this._menu.Add(addBoatUseCase);
			this._menu.Add(updateBoatUseCase);
			this._menu.Add(deleteBoatUseCase);
			this._menu.Add(saveChangesUseCase);
			this._menu.Add(exitProgramUseCase);

		}
	}
}