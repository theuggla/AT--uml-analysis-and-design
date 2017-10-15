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
			controller.User controller = new controller.User(view, menu);

            PopulateMenu(view, ledger, menu);
			controller.StartProgram();
        }

        static void PopulateMenu(view.IView view, model.MemberLedger ledger, view.Menu menu)
        {
            controller.AddMember addMemberUseCase = new controller.AddMember("Create Member", view, ledger);
			controller.ViewMember viewMemberUseCase = new controller.ViewMember("View Member", view, ledger);
			controller.UpdateMember updateMemberUseCase = new controller.UpdateMember("Update Member", view, ledger);
			controller.DeleteMember deleteMemberUseCase = new controller.DeleteMember("Delete Member", view, ledger);
			controller.ListMembers listMembersUseCase = new controller.ListMembers("List Members", view, ledger);
			controller.AddBoat addBoatUseCase = new controller.AddBoat("Add Boat", view, ledger);
			controller.UpdateBoat updateBoatUseCase = new controller.UpdateBoat("Update Boat", view, ledger);
			controller.DeleteBoat deleteBoatUseCase = new controller.DeleteBoat("Delete Boat", view, ledger);
			controller.SaveChanges saveChangesUseCase = new controller.SaveChanges("Save Changes", view, ledger);
			controller.ExitProgram exitProgramUseCase = new controller.ExitProgram("Exit Program", view, ledger);

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