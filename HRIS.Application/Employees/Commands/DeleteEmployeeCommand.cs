﻿using HRIS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Application.Employees.Commands
{
    public class DeleteEmployeeCommand : IRequest<Employee>
    {
        public string EmpID { get; set; }
    }
}
