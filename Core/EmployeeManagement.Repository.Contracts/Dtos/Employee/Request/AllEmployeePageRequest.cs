using EmployeeManagement.Domain.Common.Dtos.Requests;

namespace EmployeeManagement.Repository.Contracts.Dtos.Employee.Request
{
    public record AllEmployeePageRequest : PageRequest
    {
        public string? Name { get; init; }

        public string? Surname { get; init; }

        public int? DepartmentId { get; init; }

        public DateTime? BirthDateStart { get; init; }

        public DateTime? BirthDateEnd { get; init; }

        public DateTime? CreatedDateStart { get; init; }

        public DateTime? CreatedDateEnd { get; init; }
    }
}
