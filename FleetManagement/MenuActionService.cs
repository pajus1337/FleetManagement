using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagement
{
    public  class MenuActionService
    {
        private List<MenuAction> menuActions; 

        public MenuActionService()
        {
            menuActions = new List<MenuAction>();
        }

        public void AddNewAction(int id, string name, string menuName)
        {
            MenuAction menuAction = new MenuAction() { Id = id, Name = name, MenuName = menuName };
            menuActions.Add(menuAction);
        }

        public List<MenuAction> GetMenuActionByMenuName(string menuName)
        {
            List<MenuAction> result = new List<MenuAction>();
            foreach (MenuAction menuAction in menuActions)
            {
                if (menuAction.MenuName == menuName)
                {
                    result.Add(menuAction);
                }
            }
            return result;
        }

        public bool ChosenOptionExist(string menuName, int chosenOption)
        {
            List<MenuAction> result = new List<MenuAction>();
            foreach (MenuAction menuAction in menuActions)
            {
                if (chosenOption == menuAction.Id && menuAction.MenuName == menuName)
                {
                    return true;
                }
            }
            Console.WriteLine("A menu item was selected that does not exist");
            return false;
        }
    }
}
