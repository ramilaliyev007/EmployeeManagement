using EmployeeManagement.Domain.Common.QueryFilters;

namespace EmployeeManagement.Domain.Entities
{
    public class Department : Entity, IHasSoftDelete
    {
        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool IsDeleted { get; set; }

        public List<Employee> Employees { get; set; }
    }
}