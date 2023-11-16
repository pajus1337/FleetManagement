using FleetManagement.App.Common;
using FleetManagement.Domain.Entity;
using System.Text;

namespace FleetManagement.App.Concrete
{
    public class VehicleService : BaseService<Vehicle>
    {
        public List<Vehicle> Vehicles { get; set; }

        public VehicleService()
        {
            Vehicles = new List<Vehicle>();
        }
    }
}
