
using EmployeeManagement.Domain.Common.QueryFilters;

namespace EmployeeManagement.Domain.Entities
{
    public class Employee : Entity, ISoftDelete
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool IsDeleted { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }
    }
}