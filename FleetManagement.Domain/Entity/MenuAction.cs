using FleetManagement.Domain.Common;
using FleetManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagement.Domain.Entity
{
    public class MenuAction: BaseEntity
    {
        public string Name { get; set; }
        public string MenuName { get; set; }
        public VehicleType VehicleType { get; set; }

        public MenuAction(int id, string name, string menuName)
        {
            Id = id;
            Name = name;
            MenuName = menuName;
        }

        /// <summary>
        ///  The type of vehicle is given based on the passed id, and the enum class 
        /// </summary>
        /// 
        /// <param name="id">Vehicle type based on id</param>
        /// <param name="menuName">name for the menu to be created</param>
        public MenuAction(int id, string menuName)
        {
            Id = id;
            VehicleType = (VehicleType)id;
            MenuName = menuName;
        }
    }
}

