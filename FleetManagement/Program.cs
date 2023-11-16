using FleetManagement.App.Abstract;
using FleetManagement.App.Concrete;
using FleetManagement.App.Managers;
using FleetManagement.Domain.Entity;
using FleetManagement.Helpers;

namespace FleetManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string version = "v0.1a";
            MenuActionService actionService = new MenuActionService();
            VehicleManager vehicleManager = new VehicleManager(actionService);

            Console.WriteLine($"Welcome to Fleet Management {version}");
            while (true)
            {
                List<MenuAction> mainMenu = actionService.GetMenuActionByMenuName("MainMenu");
                for (int i = 0; i < mainMenu.Count; i++)
                {
                    Console.WriteLine($"{mainMenu[i].Id}. {mainMenu[i].Name}");
                }

                ConsoleKeyInfo choseOperation = Console.ReadKey(true);
                switch (choseOperation.KeyChar)
                {
                    case '1':
                        int vehicleIdOnCreate; // variable without use
                        vehicleIdOnCreate = vehicleManager.AddNewVehicle();
                        break;
                    case '2':
                        vehicleManager.RemoveVehicle();
                        break;
                    case '3':
                        vehicleManager.ShowVehicleDetail();
                        break;
                        
                    case '4':
                        vehicleManager.ShowVehiclesOfCategory();
                        break;
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine($"The selected key [{choseOperation.KeyChar}], does not match the ID in the menu, try again");
                        break;
                }
            }
        }
    }
}