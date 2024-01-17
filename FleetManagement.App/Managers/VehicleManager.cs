using FleetManagement.App.Concrete;
using FleetManagement.App.Abstract;
using FleetManagement.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using FleetManagement.Domain.Enums;

namespace FleetManagement.App.Managers;

public class VehicleManager
{
    private readonly MenuActionService _actionService;

    private IService<Vehicle> _vehicleService;

    public VehicleManager(MenuActionService actionService, IService<Vehicle> vehicleService)
    {
        _actionService = actionService;
        _vehicleService = vehicleService;
        _vehicleService.ReadDataFromJsonFileToList();
    }

    public int AddNewVehicle()
    {
        int typeId;
        List<MenuAction> addNewVehicleMenu = _actionService.GetMenuActionByMenuName("AddNewVehicleMenu");

        do
        {
            Console.WriteLine("Select the type of vehicle you want to add :");
            foreach (var item in addNewVehicleMenu)
            {
                Console.WriteLine($"{item.Id}. {item.VehicleType}");
            }

            ConsoleKeyInfo choseOperation = Console.ReadKey(true);
            int.TryParse(choseOperation.KeyChar.ToString(), out typeId);

        } while (!_actionService.ChosenOptionExist(addNewVehicleMenu, typeId));

        string vehicleLicensePlate = string.Empty;
        while (string.IsNullOrWhiteSpace(vehicleLicensePlate))
        {
            Console.WriteLine("Enter license plate");
            vehicleLicensePlate = Console.ReadLine();
        }
        int lastId = _vehicleService.GetLastId();
        Vehicle vehicle = new Vehicle(lastId + 1, vehicleLicensePlate, typeId);
        _vehicleService.AddItem(vehicle);
        Console.WriteLine($"New vehicle with ID number : {vehicle.Id}\nType : {Enum.GetName(typeof(VehicleType), (vehicle.TypeId))}\nhas been successfully added");

        _vehicleService.SaveSerializedStringInJsonToAFile(_vehicleService.SerializeListToStringInJsonFormat()); // Test only

        return vehicle.Id;
    }

    public void RemoveVehicle()
    {
        Console.WriteLine("Please enter the ID for the vehicle you want to remove.");
        string userKeyboardInputID = string.Empty;
        userKeyboardInputID = Console.ReadLine();
        Vehicle vehicleToRemove = new Vehicle();
        int vehicleIdToRemove;

        if (!int.TryParse(userKeyboardInputID, out vehicleIdToRemove))
        {
            Console.WriteLine("The ID should consist only of digits");
        }

        vehicleToRemove = _vehicleService.GetItemByID(vehicleIdToRemove);
        if (vehicleToRemove != null)
        {
            _vehicleService.RemoveItem(vehicleToRemove);
            Console.WriteLine($"Vehicle with ID {vehicleToRemove.Id} - Has been successfully deleted from the database.");
            _vehicleService.SaveSerializedStringInJsonToAFile(_vehicleService.SerializeListToStringInJsonFormat());
        }
        else
        {
            Console.WriteLine($"There is no vehicle with ID {vehicleIdToRemove} in the database : ");
        }
    }

    public void ShowVehicleDetail()
    {
        Console.WriteLine("Please enter the ID of the vehicle you want to display details for.");
        string userKeyboardInput = string.Empty;
        userKeyboardInput = Console.ReadLine();
        int vehicleIdToShowDetail;
        Vehicle vehicleToShow = new Vehicle();
        if (!int.TryParse(userKeyboardInput, out vehicleIdToShowDetail))
        {
            Console.WriteLine("The ID should consist only of digits");
            return;
        }

        vehicleToShow = _vehicleService.GetItemByID(vehicleIdToShowDetail);
        if (vehicleToShow != null)
        {
            Console.WriteLine($"Selected Vehicle with ID : {vehicleToShow.Id}.\nIs a vehicle of type : {Enum.GetName(typeof(VehicleType), vehicleToShow.TypeId)}");
            Console.WriteLine($"Has a license plate: {vehicleToShow.VehicleLicensePlate}");
        }
        else
        {
            Console.WriteLine($"There is no vehicle with ID {vehicleIdToShowDetail} in the database :");
        }
    }

    public void ShowVehiclesOfCategory()
    {
        int vehiclesTypeIdToView;
        List<MenuAction> FindByTypeMenu = _actionService.GetMenuActionByMenuName("FindByTypeMenu");
        do
        {
            Console.WriteLine("Please enter the type ID of the vehicle type.");
            
            for (int i = 0; i < FindByTypeMenu.Count; i++)
            {
                Console.WriteLine($"{FindByTypeMenu[i].Id}. {FindByTypeMenu[i].VehicleType}");
            }
            ConsoleKeyInfo chosenVehicleTypeId = Console.ReadKey(true);

            int.TryParse(chosenVehicleTypeId.KeyChar.ToString(), out vehiclesTypeIdToView);
        } while (!_actionService.ChosenOptionExist(FindByTypeMenu, vehiclesTypeIdToView));

        StringBuilder builder = new StringBuilder();
        List<Vehicle> vehiclesByType = _vehicleService.GetItemsByTypeId(vehiclesTypeIdToView);
        builder.AppendLine($"| Veh. ID | Veh. Type | License plate |");
        foreach (Vehicle vehicle in vehiclesByType)
        {
                builder.AppendLine($"|{vehicle.Id,9}|{Enum.GetName(typeof(VehicleType), vehicle.TypeId),11}|{vehicle.VehicleLicensePlate,15}|");
        }

        Console.WriteLine(vehiclesByType.Count == 0 ? "There are no vehicles in the selected category" : builder); 
    }

    public Vehicle GetVehicleById(int id)
    {
        var vehicle = _vehicleService.GetItemByID(id);
        return vehicle;
    }
}
