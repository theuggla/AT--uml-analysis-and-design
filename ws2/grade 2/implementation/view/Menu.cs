using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MemberRegistry.view 
{
    class Menu
    { 
       private List<controller.IMenuItemCommand> _menu;

       public Menu()
       {
           this._menu = new List<controller.IMenuItemCommand>();
       }

       public void Add(controller.IMenuItemCommand command) 
       {
           this._menu.Add(command);
       }

       public List<controller.IMenuItemCommand> GetSubset(MenuCategory tag)
       {
           return _menu.Where(item => item.Tags.Contains(tag)).ToList();
       }
    }

}