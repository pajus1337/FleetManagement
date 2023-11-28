﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagement.Domain.Common
{
    public class BaseEntity : AuditableModel
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
    }
}
