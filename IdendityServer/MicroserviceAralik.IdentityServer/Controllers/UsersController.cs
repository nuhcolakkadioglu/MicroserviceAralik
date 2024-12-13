using System.Linq;
using System.Threading.Tasks;
using MicroserviceAralık.IdentityServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static IdentityServer4.IdentityServerConstants;

namespace MicroserviceAralik.IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [Authorize(LocalApi.ScopeName)]
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
