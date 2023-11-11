namespace FleetManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MenuActionService actionService = new MenuActionService();
            VehicleService vehicleService = new VehicleService();
            string version = "v0.1a";


            /* TODO :
             * Create a simple menu based on a few functions: 
             * 1) Adding a vehicle (creating it)
             * 2) Deleting a vehicle
             * 3) Displaying the fleet status
             * 4) Return vehicle lists based on a predefined filter
             * 1a) Selecting the vehicle type
             * 1b) Adding vehicle details
             * 2a) Entering the ID or registration plate of the vehicle
             * 2b) Vehicle wi ll be deleted
             * 3a) Querying the vehicle ID 
             * 3b) Displaying all information about the vehicle
             * 4a) Entering the vehicle type
             * 5a) Calling up a list of vehicles of a given type 
            */

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
                        vehicleService.AddNewVehicle(consoleKey.KeyChar);
                        break;
                    case '2':
                        break;
                    case '3':
                        break;
                    case '4':
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
            actionService.AddNewAction(1, "Add vehicle", "MainMenu");
            actionService.AddNewAction(2, "Remove vehicle", "MainMenu");
            actionService.AddNewAction(3, "Display fleet", "MainMenu");
            actionService.AddNewAction(4, "Find vehicle", "MainMenu");
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