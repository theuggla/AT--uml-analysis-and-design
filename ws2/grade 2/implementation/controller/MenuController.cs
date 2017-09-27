using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MemberRegistry.controller
{
	class MenuController
	{
		private view.Menu m_menu;
		private view.Console m_view;
		
		private model.MemberRegistry m_registry;

        public MenuController(model.MemberRegistry a_registry, view.Console a_view)
		{
			m_menu = new view.Menu();
			m_registry = a_registry;
			m_view = a_view;
			PopulateMenu();

			/*MenuCategory currentMenu = GetCorrectMenu();

			int userChoice = m_view.GetUserInt("Chose a number in the menu", 1, 10);
				int action = MapChoiceAgainstAction(userChoice, currentSelection);
				TakeChosenAction(action);*/
		}

		public controller.IMenuItemCommand GetCorrectUseCase()
		{
			List<controller.IMenuItemCommand> currentSelection = m_menu.GetSubset(MenuCategory.All);
			m_view.ShowMenu(currentSelection);
			int userChoice = m_view.GetUserInt("Chose a number in the menu", 1, currentSelection.Count);
			return currentSelection.ElementAt(userChoice - 1);
		}

		/*private void TakeChosenAction(int actionNumber) 
		{
			switch (actionNumber)
			{
				case 0:
				m_registry.CreateMember();
				break;
				case 1:
				m_registry.ListMembers();
				break;
				case 2:
				m_registry.DeleteMember();
				break;
				case 3:
				m_registry.UpdateMember();
				break;
				case 4:
				m_registry.ViewMember();
				break;
				case 5:
				m_registry.RegisterBoat();
				break;
				case 6:
				m_registry.DeleteBoat();
				break;
				case 7:
				m_registry.UpdateBoat();
				break;
				case 8:
				m_registry.SaveMemberList();
				break;
				case 9:
				System.Environment.Exit(0);
				break;
			}
		}*/

		private void PopulateMenu()
		{
			MenuCategory[] tags = {MenuCategory.Member, MenuCategory.All};
			MenuCategory[] boattags = {MenuCategory.Boat, MenuCategory.Member, MenuCategory.All};

			AddMember addMemberUseCase = new AddMember(tags, "Create Member");
			SaveChanges saveChangesUseCase = new SaveChanges(tags, "Save Changes");
			DeleteMember deleteMemberUseCase = new DeleteMember(tags, "Delete Member");
			ViewMember viewMemberUseCase = new ViewMember(tags, "View Member", m_view);
			UpdateMember updateMemberUseCase = new UpdateMember(tags, "Update Member");
			ListMembers listMembersUseCase = new ListMembers(tags, "List Members", m_view);
			AddBoat addBoatUseCase = new AddBoat(tags, "Add Boat");
			DeleteBoat deleteBoatUseCase = new DeleteBoat(tags, "Delete Boat", m_view);
			UpdateBoat updateBoatUseCase = new UpdateBoat(tags, "Update Boat", m_view);
			ExitProgram exitProgramUseCase = new ExitProgram(tags, "Exit Program");

			m_menu.Add(addMemberUseCase);
			m_menu.Add(saveChangesUseCase);
			m_menu.Add(deleteMemberUseCase);
			m_menu.Add(viewMemberUseCase);
			m_menu.Add(updateMemberUseCase);
			m_menu.Add(listMembersUseCase);
			m_menu.Add(addBoatUseCase);
			m_menu.Add(deleteBoatUseCase);
			m_menu.Add(updateBoatUseCase);
			m_menu.Add(exitProgramUseCase);

		}
	}
}