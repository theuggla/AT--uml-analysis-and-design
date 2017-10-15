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

		public UserController(view.IView view, view.Menu menu)
		{
			_view = view;
			_menu = menu;
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
	}
}