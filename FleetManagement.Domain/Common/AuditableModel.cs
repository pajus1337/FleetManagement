using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagement.Domain.Common
{
    public class AuditableModel
    {
        public int CreatedById { get; set; }
        public DateTime CreatedDataTime { get; init; }
        public int? ModifiedById { get; set; }
        public DateTime? ModifiedDataTime { get; set; }
    }
}
