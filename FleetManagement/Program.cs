namespace FleetManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string version = "v0.1a";
            MenuActionService actionService = new MenuActionService();
            VehicleService vehicleService = new VehicleService();

            actionService = Initialize(actionService);

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
                        ConsoleKeyInfo consoleKey = vehicleService.AddNewVehicleView(actionService);
                        int vehicleIdOnCreate = vehicleService.AddNewVehicle(consoleKey.KeyChar);
                        break;
                    case '2':
                        int vehicleIdToRemove = vehicleService.RemoveVehicleView();
                        vehicleService.RemoveVehicle(vehicleIdToRemove);
                        break;
                    case '3':
                        int vehicleIdToGetDetail = vehicleService.VehicleDetailSelectionView();
                        vehicleService.VehicleDetailView(vehicleIdToGetDetail);
                        break;
                    case '4':
                        int vehicleTypeId = vehicleService.VehicleTypeSelectionView();
                        vehicleService.VehiclesByTypedIdView(vehicleTypeId);
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

        private static MenuActionService Initialize(MenuActionService actionService)
        {
            actionService.AddNewAction(1, "Add a new vehicle", "MainMenu");
            actionService.AddNewAction(2, "Remove added vehicle", "MainMenu");
            actionService.AddNewAction(3, "Display information about a specific vehicle", "MainMenu");
            actionService.AddNewAction(4, "Search for all vehicles of a specific type", "MainMenu");
            actionService.AddNewAction(0, "Terminate the program", "MainMenu");

            actionService.AddNewAction(1, "Car", "AddNewVehicleMenu");
            actionService.AddNewAction(2, "Bus", "AddNewVehicleMenu");
            actionService.AddNewAction(3, "Truck", "AddNewVehicleMenu");
            actionService.AddNewAction(4, "Trailer", "AddNewVehicleMenu");
            actionService.AddNewAction(0, "Terminate the program", "AddNewVehicleMenu");

            return actionService;
        }
    }
}