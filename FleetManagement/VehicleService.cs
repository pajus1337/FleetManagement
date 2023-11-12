using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

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
            var addNewVehicleMenu = actionService.GetMenuActionByMenuName("AddNewVehicleMenu");
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
            int vehicleId;
            string vehicleLicensPlate = string.Empty;

            int.TryParse(vehicleType.ToString(), out vehicleTypeId);           
            Console.WriteLine("Please enter the ID for new vehicle");
            string Id = Console.ReadLine();
            int.TryParse(Id, out vehicleId);

            while (string.IsNullOrWhiteSpace(vehicleLicensPlate))
            {
                Console.WriteLine("Enter license plate"); 
                vehicleLicensPlate = Console.ReadLine();
            }

            vehicle.TypeID = vehicleTypeId;
            vehicle.VehicleLicensePlate = vehicleLicensPlate;
            vehicle.Id = vehicleId;

            Vehicles.Add(vehicle);
            return vehicleId;
        }

        public int RemoveVehicleView()
        {
            int vehicleIdToRemove;
            Console.WriteLine("Please enter the ID for the vehicle you want to remove.");
            ConsoleKeyInfo vehicleId = Console.ReadKey();
            int.TryParse(vehicleId.KeyChar.ToString(), out vehicleIdToRemove);

            return vehicleIdToRemove;
        }

        public void RemoveVehicle(int vehicleIdToRemove)
        {
            Vehicle vehicleToRemove = new();
            foreach (Vehicle vehicle in Vehicles)
            {
                if (vehicle.Id == vehicleIdToRemove)
                {
                    vehicleToRemove= vehicle;
                    break;
                }
            }
            Vehicles.Remove(vehicleToRemove);
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
            Console.WriteLine($"Selected Vehicle with ID : {vehicleToShow.Id}.\nIs a vehicle of type : {Enum.GetName(typeof(VehicleType), vehicleToShow.TypeID)}");
            Console.WriteLine($"Has a license plate: {vehicleToShow.VehicleLicensePlate}");

        }

        public int VehicleTypeSelectionView()
        {
            int vehicleIdToDetailView;
            Console.WriteLine("Please enter the type ID of the vehicle type.");
            ConsoleKeyInfo vehicleId = Console.ReadKey();
            int.TryParse(vehicleId.KeyChar.ToString(), out vehicleIdToDetailView);

            return vehicleIdToDetailView;

        }

        public void VehiclesByTypedIdView(int vehicleTypeId)
        {
            List<Vehicle> vehiclesByType = new List<Vehicle>();
            foreach (Vehicle vehicle in Vehicles)
            {
                if (vehicle.TypeID == vehicleTypeId)
                {
                    vehiclesByType.Add(vehicle);
                }
            }
            // Add display by type ID of vehicels in the table or some other way.
        }
    }
}
