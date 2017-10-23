using System;
using System.Collections.Generic;
using System.Linq;

namespace MemberRegistry
{
    class Application
    {
        static void Main(string[] args)
        {
            persistance.IPersistance persistance = new persistance.JSONFilePersistance("saved.json");
            model.MemberLedger ledger = new model.MemberLedger(persistance);
			view.MainView view = new view.MainView();
			IEnumerable<model.IMenuItem> menu = PopulateMenu(view, ledger);
			controller.UserController controller = new controller.UserController(view, ledger, menu);

			controller.StartProgram();
        }

        static IEnumerable<model.IMenuItem> PopulateMenu(view.IView view, model.MemberLedger ledger)
        {
			List<model.IMenuItem> menu = new List<model.IMenuItem>();
			List<model.ISearchCriteria> criteria = PopulateSearchCriteriaList();


			controller.ViewMemberCommand viewMemberUseCase = new controller.ViewMemberCommand("View Member", view, ledger);
			controller.ListMembersCommand listMembersUseCase = new controller.ListMembersCommand("List Members", view, ledger);
			controller.SearchCommand searchUseCase = new controller.SearchCommand("Search Members", view, ledger, criteria);

			controller.AddMemberCommand addMemberUseCase = new controller.AddMemberCommand("Create Member", view, ledger);
			controller.UpdateMemberCommand updateMemberUseCase = new controller.UpdateMemberCommand("Update Member", view, ledger);
			controller.DeleteMemberCommand deleteMemberUseCase = new controller.DeleteMemberCommand("Delete Member", view, ledger);
			controller.AddBoatCommand addBoatUseCase = new controller.AddBoatCommand("Add Boat", view, ledger);
			controller.UpdateBoatCommand updateBoatUseCase = new controller.UpdateBoatCommand("Update Boat", view, ledger);
			controller.DeleteBoatCommand deleteBoatUseCase = new controller.DeleteBoatCommand("Delete Boat", view, ledger);

			controller.LogoutUserCommand logoutUserUseCase = new controller.LogoutUserCommand("Logout User", view, ledger);
			controller.ExitProgramCommand exitProgramUseCase = new controller.ExitProgramCommand("Exit Program", view, ledger);

			menu.Add(addMemberUseCase);
			menu.Add(viewMemberUseCase);
			menu.Add(updateMemberUseCase);
			menu.Add(deleteMemberUseCase);
			menu.Add(listMembersUseCase);
			menu.Add(searchUseCase);
			menu.Add(addBoatUseCase);
			menu.Add(updateBoatUseCase);
			menu.Add(deleteBoatUseCase);
			menu.Add(logoutUserUseCase);
			menu.Add(exitProgramUseCase);

			return menu;
        }

		public static List<model.ISearchCriteria> PopulateSearchCriteriaList()
		{
			List<model.ISearchCriteria> criteria = new List<model.ISearchCriteria>();

			criteria.Add(new model.HasCanoeCriteria());

			return criteria;
		}
    }
}