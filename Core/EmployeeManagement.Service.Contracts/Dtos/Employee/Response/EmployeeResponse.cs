using EmployeeManagement.Domain.Common.Dtos;
using EmployeeManagement.Service.Contracts.Dtos.Department.Response;

namespace EmployeeManagement.Service.Contracts.Dtos.Employee.Response
{
    public record EmployeeResponse : EntityDto
    {
        public string Name { get; init; }

        public string Surname { get; init; }

        public DepartmentOfEmployeeDto? Department { get; init; }

        public DateTime BirthDate { get; init; }

        public DateTime CreatedDate { get; init; }

        public record DepartmentOfEmployeeDto(int Id, string Name);
    }
}
