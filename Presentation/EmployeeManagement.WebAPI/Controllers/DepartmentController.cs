using EmployeeManagement.Domain.Common.Dtos.Response;
using EmployeeManagement.Repository.Contracts.Dtos.Department.Request;
using EmployeeManagement.Repository.Contracts.Dtos.Employee.Request;
using EmployeeManagement.Service.Contracts.Dtos.Department.Request;
using EmployeeManagement.Service.Contracts.Dtos.Department.Response;
using EmployeeManagement.Service.Contracts.Dtos.Employee.Request;
using EmployeeManagement.Service.Contracts.Dtos.Employee.Response;
using EmployeeManagement.Service.Contracts.Services;
using EmployeeManagement.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            this._departmentService = departmentService;
        }

        [HttpPost]
        public async Task Create([FromBody] DepartmentCreateRequest request)
        {
            await _departmentService.CreateAsync(request);
        }

        [HttpPut]
        public async Task Edit([FromBody] DepartmentEditRequest request)
        {
            await _departmentService.EditAsync(request);
        }

        [HttpGet]
        public async Task<DepartmentResponse> GetById([FromQuery] int id)
        {
            var result = await _departmentService.GetByIdAsync(id);

            return result;
        }

        [HttpGet]
        public async Task<List<DepartmentResponse>> GetAll()
        {
            var result = await _departmentService.GetAllAsync();

            return result;
        }

        [HttpGet]
        public async Task<PageListResponse<DepartmentResponse>> GetAllByPage([FromQuery] AllDepartmentPageRequest request)
        {
            var result = await _departmentService.GetAllAsync(request);

            return result;
        }

        [HttpDelete]
        public async Task DeleteById(int id)
        {
            await _departmentService.DeleteByIdAsync(id);
        }
    }
}