﻿using HRIS.Application.Common.Mappings;
using HRIS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Application.Employees.Commands
{
    public class UpdateEmployeeCommand : IRequest<Department>, IMapTo<Department>
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
