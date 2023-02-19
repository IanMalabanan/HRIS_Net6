using HRIS.Application.Common.Mappings;
using HRIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Application.Employees.Dtos
{
    public class GetEmployeesDto : IMapFrom<Employee>
    {
        public string EmpID { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public GetEmployeeDepartmentDto Department { get; set; }

        public GetEmployeeDepartmentSectionDto DepartmentSection { get; set; }
    }
}
