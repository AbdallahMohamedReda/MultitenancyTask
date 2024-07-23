using Microsoft.AspNetCore.Mvc;
using MultiTenancyTask.Application.CQRS;
using MultiTenancyTask.Domain.DTO;

namespace MultiTenancyTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentServiceCQRS departmentServiceCQRS;

        public DepartmentController(IDepartmentServiceCQRS _departmentServiceCQRS)
        {
            departmentServiceCQRS = _departmentServiceCQRS;
        }
        [HttpGet]
        public  async Task<IActionResult> GetDepartment()
        {
            var Dept = await departmentServiceCQRS.GetAll();
            return Ok(Dept);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetDepartment(int id)
        {
           var Dept = await departmentServiceCQRS.GetById(id);
            return Ok(Dept);
        }
        [HttpPost]
        public async Task<IActionResult> PostDepartment(DepartmentDTO departmentDTO)
        {
            if (ModelState.IsValid)
            {
                await departmentServiceCQRS.Insert(departmentDTO);
                return StatusCode(StatusCodes.Status201Created);
            }
            return BadRequest(ModelState);
        }
    }
}
