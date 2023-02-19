using HRIS.Domain.Common;

namespace HRIS.Domain.Entities
{
    public class Employee : SoftDeletableEntity
    {
        public int EmpID { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string DepartmentCode { get; set; }

        public string DepartmentSectionCode { get; set; }

        public virtual Department Department { get; set; }

        public virtual DepartmentSection DepartmentSection { get; set; }

 


    }
}
