
using EmployeeManagement.Domain.Common.Dtos.Requests;

namespace EmployeeManagement.Repository.Contracts.Dtos.Department.Request
{
    public record AllDepartmentPageRequest : PageRequest
    {
        public string? Name { get; set; }

        public DateTime? CreatedDateStart { get; set; }

        public DateTime? CreatedDateEnd { get; set; }
    }
}
