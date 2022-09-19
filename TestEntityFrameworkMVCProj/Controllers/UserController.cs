using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestEntityFrameworkMVCProj.Models;

namespace TestEntityFrameworkMVCProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private AzureStorageEmulatorDb510Context _context;

        public UserController(AzureStorageEmulatorDb510Context context)
        {
            _context = context;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {

            return await _context.Users.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<User>>> Post(User User)
        {
            try
            {
                await _context.Users.AddAsync(User);
                await _context.SaveChangesAsync();
                return StatusCode(StatusCodes.Status201Created, User);
            }

            catch (DbUpdateException)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = "Server Error"
                });
            }
        }
    }
}
