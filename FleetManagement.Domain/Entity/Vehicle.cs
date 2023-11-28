using FleetManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagement.Domain.Entity
{
    public class Vehicle : BaseEntity
    {
        public string VehicleLicensePlate { get; set; }

        public Vehicle()
        {
            VehicleLicensePlate = string.Empty;
        }

        public Vehicle(int id ,string vehicleLicensePlate, int typeId)
        {
            CreatedDataTime = DateTime.Now;
            VehicleLicensePlate = vehicleLicensePlate;
            TypeId = typeId;
            Id = id;
        }
    }
}

