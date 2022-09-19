using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestEntityFrameworkMVCProj.Models;

namespace TestEntityFrameworkMVCProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoftLockController : ControllerBase
    {
        private AzureStorageEmulatorDb510Context _context;

        public SoftLockController(AzureStorageEmulatorDb510Context context)
        {
            _context = context;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Softlock>>> Get()
        {

            return await _context.Softlocks.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Softlock>>> Post(Softlock Softlock)
        {
            try
            {
                await _context.Softlocks.AddAsync(Softlock);
                await _context.SaveChangesAsync();
                return StatusCode(StatusCodes.Status201Created, Softlock);
            }

            catch (DbUpdateException)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = "Server Error"
                });
            }
        }
        [HttpPatch]
        public async Task<ActionResult<string>> Patch(int employeeId, Softlock employee)
        {

            var emp = _context.Softlocks.FirstOrDefault(x => x.EmployeeId == employeeId);
            try
            {
                if (emp == null)
                    return StatusCode(StatusCodes.Status204NoContent);
                if (emp.RequestMsg != null)
                    emp.RequestMsg = employee.RequestMsg;
                if (emp.ReqDate != null)
                    emp.ReqDate = employee.ReqDate;
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

            var emp = _context.Softlocks.FirstOrDefault(x => x.EmployeeId == employeeId);
            if (emp != null)
            {
                _context.Softlocks.Remove(emp);
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
