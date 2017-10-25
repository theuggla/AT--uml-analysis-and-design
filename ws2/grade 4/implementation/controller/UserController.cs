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
		private IEnumerable<commands.BaseCommand> _completeMenuSelection;
		private model.Member _currentUser;

		public UserController(view.IView mainView, model.MemberLedger ledger, IEnumerable<commands.BaseCommand> completeMenuSelection)
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
				string menuName;
				IEnumerable<commands.BaseCommand> menuItems;

				this.GetCurrentMenu(out menuName, out menuItems);
				commands.BaseCommand useCase = (commands.BaseCommand) this._view.GetSelectedMenuItem(menuName, menuItems);
				
				PlayOutUseCase(useCase);
			}
		}

		private void TryToLogInUser()
		{
			try
			{
				string password = "";
				this._currentUser = _view.GetCurrentUserLoginCredentials(this._ledger, ref password);

				if (this._currentUser != null)
				{
					this._ledger.LoginMember(this._currentUser, password);
				}	
			}
			catch (IncorrectCredentialsException)
			{
				this._view.DisplayFailureMessage("Wrong ID or password.");
			}
			catch (NoSuchMemberException)
			{
				this._view.DisplayFailureMessage("Wrong ID or password.");
			}
		}

		private void GetCurrentMenu(out string menuName, out IEnumerable<commands.BaseCommand> menuItems)
		{
			if (this._currentUser != null && this._currentUser.IsLoggedIn)
				{
					menuName = "Logged in menu";
					menuItems = this._completeMenuSelection;
				}
				else
				{
					menuName = "Logged out menu";
					menuItems = this._completeMenuSelection
									.Where(command => !(command is commands.ILoggedInCommand))
									.ToList();
				}
		}

		private void PlayOutUseCase(commands.BaseCommand useCase)
		{
			try
			{
				if (useCase.GetType() == typeof(commands.ILoggedInCommand))
				{
					commands.ILoggedInCommand loggedInUseCase = (commands.ILoggedInCommand) useCase;
					loggedInUseCase.EnsureUserIsLoggedIn(this._currentUser);
				}
				
				useCase.ExecuteCommand();
			}
			catch(NoSuchMemberException)
			{
				this._view.DisplayFailureMessage("Sorry, that member do not exist.");
			}
			catch(PasswordIsMissingException)
			{
				this._view.DisplayFailureMessage("Password has to contain some characters.");
			}
			catch(PasswordIsTooShortException)
			{
				this._view.DisplayFailureMessage("Password is too short.");
			}
			catch(InvalidBoatLengthException)
			{
				this._view.DisplayFailureMessage("Length of boat is invalid, has to be between 10 and 100.");
			}
			catch(InvalidBoatTypeException)
			{
				this._view.DisplayFailureMessage("Type of boat does not exist.");
			}
			catch(IncorrectCredentialsException)
			{
				this._view.DisplayFailureMessage("Member credentials are incorrect.");
			}
			catch(InvalidPersonalNumberException)
			{
				this._view.DisplayFailureMessage("Personal number is invalid.");
			}
			catch (Exception)
			{
				this._view.DisplayFailureMessage("Sorry, something went wrong. Perhaps try again?");
			}
			
		}
	}
}