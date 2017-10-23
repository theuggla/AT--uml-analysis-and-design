using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MemberRegistry.view
{
	class ConsoleUtil
	{
        public void DisplaySuccessMessage(string prompt)
        {
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine($"*********{prompt}********");
            Console.WriteLine();

            Console.ResetColor();
            Console.WriteLine();

            this.PauseUntilProceedIsIndicated();
        }

        public void DisplayFailureMessage(string prompt)
        {
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine($"*********{prompt}********");
            Console.WriteLine();

            Console.ResetColor();
            Console.WriteLine();

            this.PauseUntilProceedIsIndicated();
        }

        public void PauseUntilProceedIsIndicated()
        {
            System.Console.Write("Press enter to return to menu.");
            System.Console.ReadLine();
        }

        public int GetUserInt(string prompt, int minValue = int.MinValue, int maxValue = int.MaxValue)
        {
            string input;
            int result;

            do
            {
                System.Console.Write($"{prompt} ");
                input = System.Console.ReadLine();
                System.Console.Clear();

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

                System.Console.Clear();
            }
        }

        public TEnum GetUserEnum<TEnum>(string prompt) where TEnum : struct
        {
            string input;
            TEnum resultInputType = default(TEnum);

            do
            {
                System.Console.Write($"{prompt} ");
                input = System.Console.ReadLine();
                System.Console.Clear();

            } while (!((Enum.TryParse(input, true, out resultInputType)) && (Enum.IsDefined(resultInputType.GetType(), resultInputType))));

            return resultInputType;
        }

        public string GetUserString(string prompt)
        {
            string input;

            System.Console.Write($"{prompt} ");
            input = System.Console.ReadLine();

            return input;
        }
	}
}