﻿using HRIS.Application.Common.Mappings;
using HRIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Application.Employees.Dtos.Commands
{
    public class CreateEmployeeDto : IMapFrom<Employee>
    {
        public string EmpID { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string DepartmentCode { get; set; }

        public string DepartmentSectionCode { get; set; }

        public string CivilStatusCode { get; set; }


        public CreateCustomEmployeeDto CreateCustomEmployeeDto { get; set; }
    }

    public class CreateCustomEmployeeDto : IMapTo<CustomEmployee>
    {
        public int SerialID { get; set; }

        public string DefinedEmpID { get; set; }

    }

}
