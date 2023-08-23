
using EmployeeManagement.Domain.Common.Dtos;

namespace EmployeeManagement.Service.Contracts.Dtos.Department.Request
{
    public record DepartmentEditRequest : EntityDto
    {
        public string Name { get; set; }
    }
}
