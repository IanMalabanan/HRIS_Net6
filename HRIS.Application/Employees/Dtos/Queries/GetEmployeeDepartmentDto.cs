﻿using HRIS.Application.Common.Mappings;
using HRIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Application.Employees.Dtos.Queries
{
    public class GetEmployeeDepartmentDto : IMapFrom<Department>
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
