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

			menu.Add(new controller.ViewMemberCommand("View Member", view, ledger));
			menu.Add(new controller.ListMembersCommand("List Members", view, ledger));
			menu.Add(new controller.SimpleSearchCommand("Simple Search of Members", view, ledger, criteria));

			menu.Add(new controller.AddMemberCommand("Create Member", view, ledger));
			menu.Add(new controller.UpdateMemberCommand("Update Member", view, ledger));
			menu.Add(new controller.DeleteMemberCommand("Delete Member", view, ledger));
			menu.Add(new controller.AddBoatCommand("Add Boat", view, ledger));
			menu.Add(new controller.UpdateBoatCommand("Update Boat", view, ledger));
			menu.Add(new controller.DeleteBoatCommand("Delete Boat", view, ledger));

			menu.Add(new controller.LogoutUserCommand("Logout User", view, ledger));
			menu.Add(new controller.ExitProgramCommand("Exit Program", view, ledger));

			return menu;
        }

		public static List<model.ISearchCriteria> PopulateSearchCriteriaList()
		{
			List<model.ISearchCriteria> criteria = new List<model.ISearchCriteria>();

			criteria.Add(new model.HasCanoeCriteria());
			criteria.Add(new model.StartsWithSCriteria());

			return criteria;
		}
    }
}