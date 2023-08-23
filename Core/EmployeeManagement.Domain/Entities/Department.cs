using EmployeeManagement.Domain.Common.QueryFilters;

namespace EmployeeManagement.Domain.Entities
{
    public class Department : Entity, IHasSoftDelete, IHasCreatedDate, IHasDeletedDate, IHasLastModifiedDate
    {
        public Department()
        {
            Employees = new();
        }

        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool IsDeleted { get; set; }

        public List<Employee> Employees { get; set; }

        public DateTime? DeletedDate { get; set; }

        public DateTime? LastModifiedDate { get; set; }
    }
}