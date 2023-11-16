using FleetManagement.App.Concrete;
using FleetManagement.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagement.App.Managers
{
    public class VehicleManager
    {
        private readonly MenuActionService _actionService;
        private VehicleService _vehicleService;

        public VehicleManager(MenuActionService actionService)
        {
            _actionService = actionService;
            _vehicleService = new VehicleService();
        }

        public int AddNewVehicle()
        {
            string vehicleLicensePlate = string.Empty;
            Console.Clear();
            int typeId = -1;

            do
            {
                Console.WriteLine("Select the type of vehicle you want to add :");
                List<MenuAction> addNewVehicleMenu = _actionService.GetMenuActionByMenuName("AddNewVehicleMenu");
                for (int i = 0; i < addNewVehicleMenu.Count; i++)
                {
                    Console.WriteLine($"{addNewVehicleMenu[i].Id}. {addNewVehicleMenu[i].VehicleType}");
                }
                ConsoleKeyInfo choseOperation = Console.ReadKey(true);
                int.TryParse(choseOperation.KeyChar.ToString(), out typeId);
            } while (!_actionService.ChosenOptionExist("AddNewVehicleMenu", typeId) && (typeId != -1));

            while (string.IsNullOrWhiteSpace(vehicleLicensePlate))
            {
                Console.WriteLine("Enter license plate");
                vehicleLicensePlate = Console.ReadLine();
            }
            int lastId = _vehicleService.GetLastId();
            Vehicle vehicle = new Vehicle(lastId + 1, vehicleLicensePlate, typeId);
            _vehicleService.AddItem(vehicle);
            Console.WriteLine($"New vehicle with ID number : {vehicle.Id}\nType : {Enum.GetName(typeof(VehicleType), (vehicle.TypeId))}\nhas been successfully added");

            return vehicle.Id;
        }

        public void RemoveVehicle()
        {
            Vehicle vehicleToRemove = new Vehicle();
            int vehicleIdToRemove;
            string userKeyboardInputID = string.Empty;

            Console.WriteLine("Please enter the ID for the vehicle you want to remove.");
            userKeyboardInputID = Console.ReadLine();
            if (!int.TryParse(userKeyboardInputID, out vehicleIdToRemove))
            {
                Console.WriteLine("The ID should consist only of digits");
            }
            foreach (Vehicle vehicle in _vehicleService.Items)
            {
                if (vehicle.Id == vehicleIdToRemove)
                {
                    vehicleToRemove = vehicle;
                    break;
                }
            }
            if (!_vehicleService.Items.Contains(vehicleToRemove))
            {
                Console.WriteLine($"There is no vehicle with ID {vehicleIdToRemove} in the database : ");
            }
            _vehicleService.RemoveItem(vehicleToRemove);
            Console.WriteLine($"Vehicle with ID {vehicleToRemove.Id} - Has been successfully deleted from the database.");
        }

        public void ShowVehicleDetail()
        {
            Vehicle vehicleToShow = new Vehicle();
            string userKeyboardInput = string.Empty;
            int vehicleIdToShowDetail;

            Console.WriteLine("Please enter the ID of the vehicle you want to display details for.");
            userKeyboardInput = Console.ReadLine();
            if (!int.TryParse(userKeyboardInput, out vehicleIdToShowDetail))
            {
                Console.WriteLine("The ID should consist only of digits");
                return;
            }
            else
            {
                foreach (Vehicle vehicle in _vehicleService.Items)
                {
                    if (vehicle.Id == vehicleIdToShowDetail)
                    {
                        vehicleToShow = vehicle;
                        break;
                    }
                }
                if (!_vehicleService.Items.Contains(vehicleToShow))
                {
                    Console.WriteLine($"There is no vehicle with ID {vehicleIdToShowDetail} in the database :");
                }
                else
                {
                    Console.WriteLine($"Selected Vehicle with ID : {vehicleToShow.Id}.\nIs a vehicle of type : {Enum.GetName(typeof(VehicleType), vehicleToShow.TypeId)}");
                    Console.WriteLine($"Has a license plate: {vehicleToShow.VehicleLicensePlate}");
                }
            }
        }

        public void ShowVehiclesOfCategory()
        {
            List<Vehicle> vehiclesByType = new List<Vehicle>();
            StringBuilder builder = new StringBuilder();
            int vehiclesTypeIdToView = -1;

            do
            {
            Console.WriteLine("Please enter the type ID of the vehicle type.");
            List<MenuAction> FindByTypeMenu = _actionService.GetMenuActionByMenuName("FindByTypeMenu");
            for (int i = 0; i < FindByTypeMenu.Count; i++)
            {
                Console.WriteLine($"{FindByTypeMenu[i].Id}. {FindByTypeMenu[i].VehicleType}");
            }
            ConsoleKeyInfo chosenVehicleTypeId = Console.ReadKey(true);

            int.TryParse(chosenVehicleTypeId.KeyChar.ToString(), out vehiclesTypeIdToView);
            } while (!_actionService.ChosenOptionExist("FindByTypeMenu", vehiclesTypeIdToView) && (vehiclesTypeIdToView != -1));

            builder.AppendLine($"| Veh. ID | Veh. Type | License plate |");
            foreach (Vehicle vehicle in _vehicleService.Items)
            {
                if (vehicle.TypeId == vehiclesTypeIdToView)
                {
                    vehiclesByType.Add(vehicle);
                    builder.AppendLine($"|{vehicle.Id,9}|{Enum.GetName(typeof(VehicleType), vehicle.TypeId),11}|{vehicle.VehicleLicensePlate,15}|");
                }
            }
            if (vehiclesByType.Count == 0)
            {
                Console.WriteLine("There are no vehicles in the selected category");
            }
            else
            {
                Console.WriteLine(builder);
            }
        }
    }
}
