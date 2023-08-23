using EmployeeManagement.Domain.Common.Dtos;

namespace EmployeeManagement.Service.Contracts.Dtos.Department.Response
{
    public record DepartmentResponse:EntityDto
    {
        public string Name { get; set; }

        public DateTime CreatedDate{ get; set; }
    }
}
