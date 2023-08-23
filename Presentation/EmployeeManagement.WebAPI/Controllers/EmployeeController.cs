using EmployeeManagement.Domain.Common.Dtos.Response;
using EmployeeManagement.Repository.Contracts;
using EmployeeManagement.Repository.Contracts.Dtos.Employee.Request;
using EmployeeManagement.Service.Contracts.Dtos.Employee.Request;
using EmployeeManagement.Service.Contracts.Dtos.Employee.Response;
using EmployeeManagement.Service.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this._employeeService = employeeService;
        }

        [HttpPost]
        public async Task Create([FromBody] EmployeeCreateRequest request)
        {
            await _employeeService.CreateAsync(request);
        }

        [HttpPut]
        public async Task Edit([FromBody] EmployeeEditRequest request)
        {
            await _employeeService.EditAsync(request);
        }

        [HttpGet]
        public async Task<List<EmployeeResponse>> GetAll()
        {
            var result = await _employeeService.GetAllAsync();

            return result;
        }

        [HttpGet]
        public async Task<PageListResponse<EmployeeResponse>> GetAllByPage([FromQuery] AllEmployeePageRequest request)
        {
            var result = await _employeeService.GetAllAsync(request);

            return result;
        }

        [HttpGet]
        public async Task<EmployeeResponse> GetById([FromQuery] int id)
        {
            var result = await _employeeService.GetByIdAsync(id);

            return result;
        }

        [HttpDelete]
        public async Task DeleteById(int id)
        {
            await _employeeService.DeleteByIdAsync(id);
        }
    }
}