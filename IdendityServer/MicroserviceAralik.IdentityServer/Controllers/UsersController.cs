using System.Linq;
using System.Threading.Tasks;
using MicroserviceAralık.IdentityServer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceAralik.IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var data = await _userManager.Users.Select(m => new
            {
                m.Id,
                m.UserName,
                m.Email
            }).ToListAsync();

            return Ok(data);
        }
    }
}
