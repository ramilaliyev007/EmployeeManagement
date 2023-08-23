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
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this._employeeService = employeeService;
        }

        [HttpPost("Create")]
        public async Task CreateAsync(EmployeeCreateRequest request)
        {
            await _employeeService.CreateAsync(request);
        }

        [HttpGet("GetAll")]
        public async Task<PageListResponse<EmployeeResponse>> GetAllAsync([FromQuery] AllEmployeePageRequest request)
        {
            var result = await _employeeService.GetAllAsync(request);

            return result;
        }
    }
}