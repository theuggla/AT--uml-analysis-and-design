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
		private model.MemberLedger _ledger;
		private IEnumerable<model.IMenuItem> _completeMenuSelection;
		private model.Member _currentUser;

		public UserController(view.IView mainView, model.MemberLedger ledger, IEnumerable<model.IMenuItem> completeMenuSelection)
		{
			this._view = mainView;
			this._ledger = ledger;
			this._completeMenuSelection = completeMenuSelection;
		}

		public void StartProgram()
		{
			_view.DisplayWelcomeMessage();
			this.TryToLogInUser();

			while (true)
			{
				commands.BaseCommand useCase;

				if (this._currentUser != null && this._currentUser.IsLoggedIn)
				{
					useCase = (commands.BaseCommand) this._view.GetSelectedMenuItem<commands.ILoggedInCommand>("Logged In Menu", this._completeMenuSelection);
				}
				else
				{
					useCase = (commands.BaseCommand) this._view.GetSelectedMenuItem<commands.ILoggedOutCommand>("Logged Out Menu", this._completeMenuSelection);
				}
				
				PlayOutUseCase(useCase);
			}
		}

		private void TryToLogInUser()
		{
			try
			{
				string password = "";
				this._currentUser = _view.GetCurrentUserLoginCredentials(this._ledger, ref password);

				if (this._currentUser.Password == password)
				{
					this._currentUser.IsLoggedIn = true;
				}
				else
				{
					throw new Exception();
				}
			}
			catch (Exception)
			{
				this._view.DisplayFailureMessage("Wrong ID or password.");
			}
		}

		private void PlayOutUseCase(commands.BaseCommand useCase)
		{
			try
			{
				useCase.ExecuteCommand();
			}
			catch (Exception)
			{
				this._view.DisplayFailureMessage("Sorry, something went wrong. Perhaps try again?");
			}
			
		}
	}
}