using System.Text;

namespace FleetManagement
{
    public class VehicleService
    {
        public List<Vehicle> Vehicles { get; set; }

        public VehicleService()
        {
            Vehicles = new List<Vehicle>();
        }

        public ConsoleKeyInfo AddNewVehicleView(MenuActionService actionService)
        {
            Console.Clear();
            Console.WriteLine("Select the type of vehicle you want to add :");
            List<MenuAction> addNewVehicleMenu = actionService.GetMenuActionByMenuName("AddNewVehicleMenu");
            for (int i = 0; i < addNewVehicleMenu.Count; i++)
            {
                Console.WriteLine($"{addNewVehicleMenu[i].Id}. {addNewVehicleMenu[i].Name}");
            }
            ConsoleKeyInfo choseOperation = Console.ReadKey(true);

            return choseOperation;
        }

        public int AddNewVehicle(char vehicleType)
        {
            Vehicle vehicle = new Vehicle();
            int vehicleTypeId;
            int highestId;
            string vehicleLicensPlate = string.Empty;

            // Linq Check for last highest Id value
            highestId = Vehicles.Any() ? Vehicles.Max(x => x.Id) : 0;

            Console.WriteLine($"The selected vehicle type is : {Enum.GetName(typeof(VehicleType), (int)char.GetNumericValue(vehicleType))}");
            int.TryParse(vehicleType.ToString(), out vehicleTypeId);           

            while (string.IsNullOrWhiteSpace(vehicleLicensPlate))
            {
                Console.WriteLine("Enter license plate"); 
                vehicleLicensPlate = Console.ReadLine();
            }
            vehicle.TypeID = vehicleTypeId;
            vehicle.VehicleLicensePlate = vehicleLicensPlate;
            vehicle.Id = highestId + 1;

            Vehicles.Add(vehicle);
            Console.WriteLine($"New vehicle with ID number : {vehicle.Id}\nType : {Enum.GetName(typeof(VehicleType), (vehicle.TypeID))}\nhas been successfully added");

            return vehicle.Id;
        }

        public int RemoveVehicleView()
        {
            int vehicleIdToRemove;
            Console.WriteLine("Please enter the ID for the vehicle you want to remove.");
            string userKeyboardInputID = Console.ReadLine();
            if (!int.TryParse(userKeyboardInputID, out vehicleIdToRemove))
            {
                Console.WriteLine("The ID should consist only of digits");
            }

            return vehicleIdToRemove;
        }

        public void RemoveVehicle(int vehicleIdToRemove)
        {
            Vehicle vehicleToRemove = new();

            foreach (Vehicle vehicle in Vehicles)
            {
                if (vehicle.Id == vehicleIdToRemove)
                {
                    vehicleToRemove = vehicle;
                    break;
                }
            }

            if (!Vehicles.Contains(vehicleToRemove) )
            {
                Console.WriteLine($"There is no vehicle with ID {vehicleIdToRemove} in the database : ");
                return;
            }
            Vehicles.Remove(vehicleToRemove);
            Console.WriteLine($"Vehicle with ID {vehicleToRemove.Id} - Has been successfully deleted from the database.");
        }

        public int VehicleDetailSelectionView()
        {
            int vehicleIdToDetailView;
            Console.WriteLine("Please enter the ID of the vehicle you want to display details for.");
            ConsoleKeyInfo vehicleId = Console.ReadKey();
            int.TryParse(vehicleId.KeyChar.ToString(), out vehicleIdToDetailView);

            return vehicleIdToDetailView;
        }

        public void VehicleDetailView(int vehicleIdToGetDetail)
        {
            Vehicle vehicleToShow = new Vehicle();
            foreach (Vehicle vehicle in Vehicles)
            {
                if (vehicle.Id == vehicleIdToGetDetail)
                {
                    vehicleToShow = vehicle;
                    break;
                }
            }

            if (!Vehicles.Contains(vehicleToShow))
            {
                Console.WriteLine($"There is no vehicle with ID {vehicleIdToGetDetail} in the database :");
                return;
            }
            Console.WriteLine($"Selected Vehicle with ID : {vehicleToShow.Id}.\nIs a vehicle of type : {Enum.GetName(typeof(VehicleType), vehicleToShow.TypeID)}");
            Console.WriteLine($"Has a license plate: {vehicleToShow.VehicleLicensePlate}");
        }

        public int VehicleTypeIdSelectionView(MenuActionService actionService)
        {
            int vehiclesTypeIdToView;
            Console.WriteLine("Please enter the type ID of the vehicle type.");
            List<MenuAction> FindByTypeMenu = actionService.GetMenuActionByMenuName("FindByTypeMenu");
            for (int i = 0; i < FindByTypeMenu.Count; i++)
            {
                Console.WriteLine($"{FindByTypeMenu[i].Id}. {FindByTypeMenu[i].Name}");
            }
            ConsoleKeyInfo chosenVehicleTypeId = Console.ReadKey(true);
            int.TryParse(chosenVehicleTypeId.KeyChar.ToString(), out vehiclesTypeIdToView);

            return vehiclesTypeIdToView;
        }

        public void VehiclesByTypedIdView(int vehicleTypeId)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"| Veh. ID | Veh. Type | License plate |");

            List<Vehicle> vehiclesByType = new List<Vehicle>();
            foreach (Vehicle vehicle in Vehicles)
            {
                if (vehicle.TypeID == vehicleTypeId)
                {
                    vehiclesByType.Add(vehicle);
                    builder.AppendLine($"|{vehicle.Id,9}|{Enum.GetName(typeof(VehicleType),vehicle.TypeID),11}|{vehicle.VehicleLicensePlate, 15}|");
                }
            }
            Console.WriteLine(builder);
        }
    }
}
