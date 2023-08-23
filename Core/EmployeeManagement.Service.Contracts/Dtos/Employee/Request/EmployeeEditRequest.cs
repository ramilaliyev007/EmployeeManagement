
using EmployeeManagement.Domain.Common.Dtos;

namespace EmployeeManagement.Service.Contracts.Dtos.Employee.Request
{
    public record EmployeeEditRequest : EntityDto
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public int DepartmentId { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
