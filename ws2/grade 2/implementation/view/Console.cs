using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MemberRegistry.view
{
	class Console
	{
		public void DisplayInstructions(string prompt) {
            System.Console.WriteLine($"{prompt}");
        }

        public void ShowMenu(List<controller.IMenuItemCommand> menuItems) {
            int i = 1;
            foreach (controller.IMenuItemCommand item in menuItems) {
                System.Console.WriteLine($"{i}. {item.Description}");
                i++;
            }
        }

        public void DisplayUserInfo(dynamic userInfo) {

            foreach(var prop in userInfo.GetType().GetProperties())
            {
                System.Console.WriteLine($"{prop.Name}: {prop.GetValue(userInfo, null)}");
            }

            System.Console.WriteLine();
        }

        public int GetUserInt(string prompt, int minValue = int.MinValue, int maxValue = int.MaxValue)
        {
            string input;
            int result;

            do
            {
                System.Console.Write($"{prompt}: ");
                input = System.Console.ReadLine();

            } while (!(int.TryParse(input, out result)) || (result < minValue) || (result > maxValue));

            return result;
        }


        public string GetUserString(string prompt)
        {
            string input;

            System.Console.Write($"{prompt}: ");
            input = System.Console.ReadLine();

            return input;
        }

	}
}