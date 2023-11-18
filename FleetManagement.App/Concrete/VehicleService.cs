using FleetManagement.App.Common;
using FleetManagement.Domain.Entity;
using System.Linq;
using System.Text;

namespace FleetManagement.App.Concrete
{
    public class VehicleService : BaseService<Vehicle>
    {
        public IEnumerable<Vehicle> Seed()
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            for (int i = 0; i < 500; i++)
            {
                Vehicle vehicle = new Vehicle()
                {
                    Id = i,
                    VehicleLicensePlate = "TE-ST" + i.ToString(),
                    TypeId = 1,
                    CreatedDataTime = DateTime.Now,
                    CreatedById = 66,
                };
                vehicles.Add(vehicle);
            }
            return vehicles;
        }

        public IQueryable<Vehicle> GetAllVehicleQuerayable()
        {
            IQueryable<Vehicle> vehicles = Seed().AsQueryable().Where(p => p.Id > 50);
            return vehicles;
        }

        public IEnumerable<Vehicle> GetAllVehicleIEnumerable()
        {
            IEnumerable<Vehicle> vehicles = Seed().Where(p => p.Id > 50);
            return vehicles;
        }
    }
}
