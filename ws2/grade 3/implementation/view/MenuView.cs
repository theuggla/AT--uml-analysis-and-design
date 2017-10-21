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

       public model.IMenuItem GetSelectedMenuItem<TMenuInterface>(string menuName, IEnumerable<model.IMenuItem> completeSelection)
       {
           IEnumerable<model.IMenuItem> itemsToDisplay = this.GetMenuSubset<TMenuInterface>(completeSelection);
           this.DisplayMenu(menuName, itemsToDisplay);
           int choice = console.GetUserInt($"Select number from {menuName}: ", 1, itemsToDisplay.Count());

           return itemsToDisplay.ElementAt(choice);
       }

       private IEnumerable<model.IMenuItem> GetMenuSubset<TMenuInterface>(IEnumerable<model.IMenuItem> completeSelection)
       {
           return completeSelection
           .OfType<TMenuInterface>()
           .Cast<model.IMenuItem>();
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