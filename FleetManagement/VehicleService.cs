using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagement
{
    public class VehicleService
    {

        public ConsoleKeyInfo AddNewVehicleView(MenuActionService actionService)
        {

            var addNewVehicleMenu = actionService.GetMenuActionByMenuName("AddNewVehicleMenu");
            for (int i = 0; i < addNewVehicleMenu.Count; i++)
            {
                Console.WriteLine($"{addNewVehicleMenu[i].Id}. {addNewVehicleMenu[i].Name}");
            }
            ConsoleKeyInfo choseOperation = Console.ReadKey(true);

            return choseOperation;
        }

        public void AddNewVehicle(char vehicleType)
        {

        }
    }
}
