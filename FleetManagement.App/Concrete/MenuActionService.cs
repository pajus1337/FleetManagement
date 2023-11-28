using FleetManagement.App.Common;
using FleetManagement.Domain.Entity;


namespace FleetManagement.App.Concrete
{
    public  class MenuActionService : BaseService<MenuAction>
    {
        public MenuActionService()
        {
            Initialize();
        }

        public List<MenuAction> GetMenuActionByMenuName(string menuName)
        {

            return Items.Where<MenuAction>(menu => menu.MenuName == menuName).ToList();

            //List<MenuAction> result = new List<MenuAction>();
            //foreach (MenuAction menuAction in Items)
            //{
            //    if (menuAction.MenuName == menuName)
            //    {
            //        result.Add(menuAction);
            //    }
            //}
            //return result;
        }

        public bool ChosenOptionExist(List<MenuAction> menuActions, int chosenOption)
        {
            if (menuActions.Any(p => p.Id == chosenOption))
            {
                return true;
            }
            else
            {
                Console.WriteLine("A menu item was selected that does not exist");
                return false;
            }
        }

        private void Initialize()
        {
            AddItem(new MenuAction(1, "Add a new vehicle", "MainMenu"));
            AddItem(new MenuAction(2, "Remove added vehicle", "MainMenu"));
            AddItem(new MenuAction(3, "Display information about a specific vehicle", "MainMenu"));
            AddItem(new MenuAction(4, "Search for all vehicles of a specific type", "MainMenu"));
            AddItem(new MenuAction(0, "Terminate the program", "MainMenu"));

            AddItem(new MenuAction(1, "AddNewVehicleMenu"));
            AddItem(new MenuAction(2, "AddNewVehicleMenu"));
            AddItem(new MenuAction(3, "AddNewVehicleMenu"));
            AddItem(new MenuAction(4, "AddNewVehicleMenu"));

            AddItem(new MenuAction(1, "FindByTypeMenu"));
            AddItem(new MenuAction(2, "FindByTypeMenu"));
            AddItem(new MenuAction(3, "FindByTypeMenu"));
            AddItem(new MenuAction(4, "FindByTypeMenu"));
        }
    }
}
