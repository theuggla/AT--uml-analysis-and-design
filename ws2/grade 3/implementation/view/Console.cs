using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MemberRegistry.view
{
	class Console : IView
	{
		public void DisplayMessage(string prompt) 
        {
            System.Console.WriteLine($"{prompt}");
        }

        public void ShowMenu(IEnumerable<controller.BaseCommand> menuItems) 
        {
            int i = 1;
            foreach (controller.BaseCommand item in menuItems) {
                System.Console.WriteLine($"{i}. {item.Description}");
                i++;
            }
        }

        public void DisplayUserInfo(dynamic info) 
        {
            foreach(var prop in info.GetType().GetProperties())
            {
                System.Console.WriteLine($"{prop.Name}: {prop.GetValue(info, null)}");
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

        public bool GetUserBoolean(string question)
        {
            while (true) 
            {
			    System.Console.WriteLine($"{question} (Y/N): ");
			    string answer = System.Console.ReadLine();
			
			    if (answer.Equals("Y", StringComparison.OrdinalIgnoreCase))
			    {
				    return true;
			    }
			    else if (answer.Equals("N", StringComparison.OrdinalIgnoreCase))
			    {
				    return false;
			    }
            }
        }

        public TEnum GetUserEnum<TEnum>(string prompt) where TEnum : struct
        {
            string input;
            TEnum resultInputType = default(TEnum);

            do
            {
                System.Console.Write($"{prompt}: ");
                input = System.Console.ReadLine();

            } while (!((Enum.TryParse(input, true, out resultInputType)) && (Enum.IsDefined(resultInputType.GetType(), resultInputType))));

            return resultInputType;
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