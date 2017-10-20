using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MemberRegistry.controller
{
	class UserController
	{
		private view.IView _view;
		private view.Menu _menu;
		private IEnumerable<controller.BaseCommand> _currentMenu;
		private model.MemberLedger _ledger;

		public UserController(view.IView view, view.Menu menu, model.MemberLedger ledger)
		{
			this._view = view;
			this._menu = menu;
			this._ledger = ledger;
		}

		public void StartProgram()
		{
			_view.DisplayMessage("Hi.");

			while (true)
			{
				bool userIsLoggedIn = this._ledger.ThereIsLoggedInMember();
				this._currentMenu = this._menu.GetMenuSubset(userIsLoggedIn);

				_view.ShowMenu(this._currentMenu);
				controller.BaseCommand useCase = this.GetCorrectUseCase();
				PlayOutUseCase(useCase);
			}
		}

		private controller.BaseCommand GetCorrectUseCase()
		{
			int userChoice = this._view.GetUserInt("Chose a number in the menu", 1, this._currentMenu.Count());
			return this._currentMenu.ElementAt(userChoice - 1);
		}

		private void PlayOutUseCase(controller.BaseCommand useCase)
		{
			useCase.ExecuteCommand();
		}
	}
}