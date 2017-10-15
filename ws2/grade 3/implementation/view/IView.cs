using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MemberRegistry.view
{
	interface IView
	{
		void DisplayMessage(string prompt);

        void ShowMenu(List<controller.BaseCommand> menuItems);

        void DisplayUserInfo(dynamic info);

        int GetUserInt(string prompt, int minValue = int.MinValue, int maxValue = int.MaxValue);

        bool GetUserBoolean(string question);

        TEnum GetUserEnum<TEnum>(string prompt) where TEnum : struct;

        string GetUserString(string prompt);
	}
}