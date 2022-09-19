using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestEntityFrameworkMVCProj.Models;

namespace TestEntityFrameworkMVCProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private AzureStorageEmulatorDb510Context _context;

        public EmployeeController(AzureStorageEmulatorDb510Context context)
        {
            _context = context;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> Get()
        {

            return await _context.Employees.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Employee>>> Post(Employee person)
        {
            try
            {
                await _context.Employees.AddAsync(person);
                await _context.SaveChangesAsync();
                return StatusCode(StatusCodes.Status201Created, person);
            }

            catch (DbUpdateException)
            {
                if (PersonExists(person.EmployeeId))
                    return Conflict();
                else
                    return StatusCode(StatusCodes.Status500InternalServerError, new
                    {
                        message = "Server Error"
                    });
            }
        }

        private bool PersonExists(int id)
        {
            return _context.Employees.Any(e => e.EmployeeId == id);
        }
        [HttpPatch]
        public async Task<ActionResult<string>> Patch(int employeeId, Employee employee)
        {

            var emp = _context.Employees.FirstOrDefault(x => x.EmployeeId == employeeId);
            try
            {
                if (emp == null)
                    return StatusCode(StatusCodes.Status204NoContent);
                if (emp.Name != null)
                    emp.Name = employee.Name;
                if (emp.Email != null)
                    emp.Email = employee.Email;
                _context.SaveChanges();
                string result = "Values Updated";
                return result;
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Server error" });
            }
        }
        [HttpDelete]
        public async Task<ActionResult<string>> Delete(int employeeId)
        {

            var emp = _context.Employees.FirstOrDefault(x => x.EmployeeId == employeeId);
            if (emp != null)
            {
                _context.Employees.Remove(emp);
                await _context.SaveChangesAsync();
                string result = "Values Got Deleted";
                return result;
            }
            else
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }

        }
    }
}
