using System;

namespace MemberRegistry
{
    class Program
    {
        static void Main(string[] args)
        {
            model.MemberRegistry r = new model.MemberRegistry();
			view.Console v = new view.Console();
			controller.User c = new controller.User(v, r);

			c.StartProgram();
        }
    }
}
