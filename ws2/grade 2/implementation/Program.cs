using System;

namespace MemberRegistry
{
    class Program
    {
        static void Main(string[] args)
        {
            persistance.IPersistance p = new persistance.JSONFilePersistance("saved.json");
            model.MemberLedger r = new model.MemberLedger(p);
			view.Console v = new view.Console();
			controller.User c = new controller.User(v, r);

			c.StartProgram();
        }
    }
}
