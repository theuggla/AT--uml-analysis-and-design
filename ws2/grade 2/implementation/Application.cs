using System;

namespace MemberRegistry
{
    class Program
    {
        static void Main(string[] args)
        {
            persistance.IPersistance persistance = new persistance.JSONFilePersistance("saved.json");
            model.MemberLedger ledger = new model.MemberLedger(persistance);
			view.Console view = new view.Console();
            view.Menu menu = new view.Menu();
			controller.UserController controller = new controller.UserController(view, menu);

            PopulateMenu(view, ledger, menu);
			controller.StartProgram();
        }

        static void PopulateMenu(view.IView view, model.MemberLedger ledger, view.Menu menu)
        {
            controller.AddMemberCommand addMemberUseCase = new controller.AddMemberCommand("Create Member", view, ledger);
			controller.ViewMemberCommand viewMemberUseCase = new controller.ViewMemberCommand("View Member", view, ledger);
			controller.UpdateMemberCommand updateMemberUseCase = new controller.UpdateMemberCommand("Update Member", view, ledger);
			controller.DeleteMemberCommand deleteMemberUseCase = new controller.DeleteMemberCommand("Delete Member", view, ledger);
			controller.ListMembersCommand listMembersUseCase = new controller.ListMembersCommand("List Members", view, ledger);
			controller.AddBoatCommand addBoatUseCase = new controller.AddBoatCommand("Add Boat", view, ledger);
			controller.UpdateBoatCommand updateBoatUseCase = new controller.UpdateBoatCommand("Update Boat", view, ledger);
			controller.DeleteBoatCommand deleteBoatUseCase = new controller.DeleteBoatCommand("Delete Boat", view, ledger);
			controller.SaveChangesCommand saveChangesUseCase = new controller.SaveChangesCommand("Save Changes", view, ledger);
			controller.ExitProgramCommand exitProgramUseCase = new controller.ExitProgramCommand("Exit Program", view, ledger);

			menu.Add(addMemberUseCase);
			menu.Add(viewMemberUseCase);
			menu.Add(updateMemberUseCase);
			menu.Add(deleteMemberUseCase);
			menu.Add(listMembersUseCase);
			menu.Add(addBoatUseCase);
			menu.Add(updateBoatUseCase);
			menu.Add(deleteBoatUseCase);
			menu.Add(saveChangesUseCase);
			menu.Add(exitProgramUseCase);
        }
    }
}