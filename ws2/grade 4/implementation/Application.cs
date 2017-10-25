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
			IEnumerable<controller.commands.BaseCommand> menu = PopulateMenu(view, ledger);
			controller.UserController controller = new controller.UserController(view, ledger, menu);

			if (ledger.GetMembers().ToList().Count == 0)
			{
				ledger.CreateMember("admin", "password", "9010160000");
			}

			controller.StartProgram();
        }

        static IEnumerable<controller.commands.BaseCommand> PopulateMenu(view.IView view, model.MemberLedger ledger)
        {
			List<controller.commands.BaseCommand> menu = new List<controller.commands.BaseCommand>();
			List<model.searchcriteria.ISearchCriteria> simpleCriteria = PopulateSimpleSearchCriteriaList();
			List<model.searchcriteria.ISearchCriteria> complexCriteria = PopulateComplexSearchCriteriaList();

			menu.Add(new controller.commands.ViewMemberCommand("View Member", view, ledger));
			menu.Add(new controller.commands.ListMembersCommand("List Members", view, ledger));
			menu.Add(new controller.commands.SearchCommand("Simple Search of Members", view, ledger, simpleCriteria));
			menu.Add(new controller.commands.SearchCommand("Complex Search of Members", view, ledger, complexCriteria));

			menu.Add(new controller.commands.AddMemberCommand("Create Member", view, ledger));
			menu.Add(new controller.commands.UpdateMemberCommand("Update Member", view, ledger));
			menu.Add(new controller.commands.DeleteMemberCommand("Delete Member", view, ledger));
			menu.Add(new controller.commands.AddBoatCommand("Add Boat", view, ledger));
			menu.Add(new controller.commands.UpdateBoatCommand("Update Boat", view, ledger));
			menu.Add(new controller.commands.DeleteBoatCommand("Delete Boat", view, ledger));

			menu.Add(new controller.commands.LogoutUserCommand("Logout User", view, ledger));
			menu.Add(new controller.commands.ExitProgramCommand("Exit Program", view, ledger));

			return menu;
        }

		public static List<model.searchcriteria.ISearchCriteria> PopulateSimpleSearchCriteriaList()
		{
			List<model.searchcriteria.ISearchCriteria> criteria = new List<model.searchcriteria.ISearchCriteria>();

			criteria.Add(new model.searchcriteria.HasCanoeCriteria());
			criteria.Add(new model.searchcriteria.StartsWithSCriteria());
			criteria.Add(new model.searchcriteria.StartsWithNCriteria());

			return criteria;
		}

		public static List<model.searchcriteria.ISearchCriteria> PopulateComplexSearchCriteriaList()
		{
			List<model.searchcriteria.ISearchCriteria> criteria = new List<model.searchcriteria.ISearchCriteria>();

			model.searchcriteria.ISearchCriteria canoeCriteria = new model.searchcriteria.HasCanoeCriteria();
			model.searchcriteria.ISearchCriteria startsWithSCriteria = new model.searchcriteria.StartsWithSCriteria();
			model.searchcriteria.ISearchCriteria startsWithNCriteria = new model.searchcriteria.StartsWithNCriteria();

			model.searchcriteria.ISearchCriteria andCriteria = new model.searchcriteria.AndCriteria(canoeCriteria, startsWithSCriteria);
			model.searchcriteria.ISearchCriteria orCriteria = new model.searchcriteria.OrCriteria(canoeCriteria, startsWithNCriteria);
			model.searchcriteria.ISearchCriteria complexCriteria = new model.searchcriteria.OrCriteria(andCriteria, startsWithNCriteria);

			criteria.Add(andCriteria);
			criteria.Add(orCriteria);
			criteria.Add(complexCriteria);

			return criteria;
		}
    }
}