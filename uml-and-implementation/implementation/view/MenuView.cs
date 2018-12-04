using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MemberRegistry.view 
{
    class MenuView
    { 
       private view.ConsoleUtil console;

       public MenuView(view.ConsoleUtil console)
       {
           this.console = console;
       }

       public model.IMenuItem GetSelectedMenuItem(string menuName, IEnumerable<model.IMenuItem> menuItems)
       {
           this.DisplayMenu(menuName, menuItems);
           int choice = console.GetUserInt($"Select number from {menuName}: ", 1, menuItems.Count());

           return menuItems.ElementAt(choice - 1);
       }

       private void DisplayMenu(string menuName, IEnumerable<model.IMenuItem> itemsToDisplay)
       {
           System.Console.Clear();
           System.Console.WriteLine($"******************~{menuName}~***************");
           
           int i = 1;
           foreach (model.IMenuItem item in itemsToDisplay) {
               System.Console.WriteLine($"** {i}. {item.GetDescription()} **");
               i++;
            }

            System.Console.WriteLine($"********************************************");
            System.Console.WriteLine();
       }
    }
}