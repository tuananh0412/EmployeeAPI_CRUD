using EmployeeAPI_CRUD.Models;
using EmployeeAPI_CRUD.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeApiContext _context;

        public EmployeesController(EmployeeApiContext context)
        {
            _context = context;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            return Ok(await _context.Employees.ToListAsync());
        }

        // GET: api/Employees/5
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetEmployee([FromRoute] Guid id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // POST: api/Employees
        [HttpPost]
        public async Task<IActionResult> PostEmployee(EmployeeDTO employeeDTO)
        {
            var employee = new Employee
            {
                Id = Guid.NewGuid(),
                FullName = employeeDTO.FullName,
                DateOfBirth = employeeDTO.DateOfBirth,
                Gender = employeeDTO.Gender,
                Age = DateTime.Now.Year - employeeDTO.DateOfBirth.Year
            };

            if (_context.Employees.Any(e => e.FullName == employeeDTO.FullName) &&
                _context.Employees.Any(e => e.DateOfBirth == employeeDTO.DateOfBirth))
            {
                return BadRequest("Thêm mới nhân viên không được trùng tên và ngày sinh!");
            }

            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return Ok(employee);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> PutEmployee([FromRoute] Guid id, EmployeeDTO employeeDTO)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            employee.FullName = employeeDTO.FullName;
            employee.DateOfBirth = employeeDTO.DateOfBirth;
            employee.Gender = employeeDTO.Gender;
            employee.Age = DateTime.Now.Year - employeeDTO.DateOfBirth.Year;

            await _context.SaveChangesAsync();

            return Ok(employee);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return Ok(employee);
        }
    }
}
