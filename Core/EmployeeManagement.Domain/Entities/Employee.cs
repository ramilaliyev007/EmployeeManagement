
using EmployeeManagement.Domain.Common.QueryFilters;

namespace EmployeeManagement.Domain.Entities
{
    public class Employee : Entity, IHasSoftDelete, IHasCreatedDate, IHasDeletedDate, IHasLastModifiedDate
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? DeletedDate { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        public bool IsDeleted { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }
    }
}