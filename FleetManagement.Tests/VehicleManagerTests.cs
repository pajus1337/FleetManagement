
using FleetManagement.App.Abstract;
using FleetManagement.App.Concrete;
using FleetManagement.App.Managers;
using FleetManagement.Domain.Entity;
using FluentAssertions;
using Moq;

namespace FleetManagement.Tests
{
    public class VehicleManagerTests
    {
        [Fact]
        public void Get_GetItemById()
        {
            // Arrange 
            Vehicle vehicle = new Vehicle(1, "ABC12", 1);
            var mock = new Mock<IService<Vehicle>>();
            mock.Setup(s => s.GetItemByID(1)).Returns(vehicle);
            var manager = new VehicleManager(new MenuActionService(), mock.Object);

            // Act
            var returnedVehicle = manager.GetVehicleById(vehicle.Id);

            // Assert 
            Assert.IsType<Vehicle>(returnedVehicle);
            Assert.NotNull(returnedVehicle);
            Assert.Equal(vehicle, returnedVehicle); // Sprawdza tylko czy sa rowne wartosci ale nie czy sa tymi samymi obj w pamieci.

            returnedVehicle.Should().BeOfType(typeof(Vehicle));
            returnedVehicle.Should().NotBeNull();
            returnedVehicle.Should().BeSameAs(vehicle); // sprawdza tez czy sa takim samym obj. pod wzgledem referencji = ten sam obj w pamieci.

        }

        public void Add_CheckIfCreatedVehicleIsAddedCorrectToTheList()
        {
            // Arrange
            Vehicle vehicle = new Vehicle(1, "DD-D12", 1);
            var mock = new Mock<IService<Vehicle>>();
            var VehicleManager = new VehicleManager(new MenuActionService(), mock.Object);
            mock.Setup(s => s.Items).Returns(new List<Vehicle> { vehicle });

            // Act
            var addedVehicle = mock.Object.Items.First();

            // Assert
            Assert.NotNull(addedVehicle);
            Assert.IsType<Vehicle>(addedVehicle);
            Assert.NotNull(addedVehicle);
            Assert.Equal(vehicle.Id, addedVehicle.Id);
            Assert.Equal(vehicle.VehicleLicensePlate, addedVehicle.VehicleLicensePlate);
            Assert.Equal(vehicle.TypeId, addedVehicle.TypeId);
        }

        [Fact] 
        public void Select_CheckIfSelectedMenuIdEqualCorrectEnumVehicleValueType()
        {
            // Arrange
            MenuAction menuActionSelectedCar = new MenuAction(1, "AddNewVehicleMenu");
            MenuAction menuActionSelectedBus = new MenuAction(2, "AddNewVehicleMenu");
            MenuAction menuActionSelectedTruck = new MenuAction(3, "AddNewVehicleMenu");
            MenuAction menuActionSelectedTrailer = new MenuAction(4, "AddNewVehicleMenu");

            var enumValueForCar = VehicleType.Car;
            var enumValueForBus = VehicleType.Bus;
            var enumValueForTruck = VehicleType.Truck;
            var enumValueForTrailer = VehicleType.Trailer;

            //Act
            var resultCar = menuActionSelectedCar.VehicleType;
            var resultBus = menuActionSelectedBus.VehicleType;
            var resultTruck = menuActionSelectedTruck.VehicleType;
            var resultTrailer = menuActionSelectedTrailer.VehicleType;

            //Assert
            Assert.Equal(enumValueForCar, resultCar);
            Assert.Equal(enumValueForBus, resultBus);
            Assert.Equal(enumValueForTruck, resultTruck);
            Assert.Equal(enumValueForTrailer, resultTrailer);

        }
    }
}
