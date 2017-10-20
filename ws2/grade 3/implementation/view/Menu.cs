using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MemberRegistry.view 
{
    class Menu
    { 
       private List<controller.BaseCommand> _menu;

       public List<controller.BaseCommand> MenuItems
       {
           get
           {
               return this._menu;
           }
       }

       public Menu()
       {
           this._menu = new List<controller.BaseCommand>();
       }

       public void Add(controller.BaseCommand command) 
       {
           this._menu.Add(command);
       }

       public IEnumerable<controller.BaseCommand> GetMenuSubset(bool isLoggedIn)
       {
           if (isLoggedIn) {
               return this._menu
                        .OfType<controller.LoggedInCommand>()
                        .Cast<controller.BaseCommand>();
           } else {
               return this._menu
                        .OfType<controller.LoggedOutCommand>()
                        .Cast<controller.BaseCommand>();
           }
       }
    }
}