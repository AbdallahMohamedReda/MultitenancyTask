using Microsoft.AspNetCore.Mvc;
using MultiTenancyTask.Application.CQRS;
using MultiTenancyTask.Domain.DTO;

namespace Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeServiceCQRS employeeServiceCQRS;
        public EmployeeController(IEmployeeServiceCQRS _employeeServiceCQRS)
        {
            employeeServiceCQRS = _employeeServiceCQRS;
        }
        [HttpGet]
        [Route("{Id}")]
        public  async Task<IActionResult> GetEmployeeByAge(int Id)
        {
            var emps = await employeeServiceCQRS.GetById(Id);
            return Ok(emps);

        }
        [HttpGet]
        public async Task<IActionResult> GetEmployee()
        {
            //var emps = await employeeService.GetAll();
            var emps=await employeeServiceCQRS.GetAll();
            return Ok(emps);
        }
        [HttpPost]
        public async Task<IActionResult> PostEmployee(EmployeeDTO employeeDTO)
        {
            if (ModelState.IsValid)
            {
                await employeeServiceCQRS.Insert(employeeDTO);
                return StatusCode(StatusCodes.Status201Created);
            }
            return BadRequest(ModelState);
        }
    }
}
