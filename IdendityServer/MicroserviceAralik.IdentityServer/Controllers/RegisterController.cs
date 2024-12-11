using System.Linq;
using System.Threading.Tasks;
using MicroserviceAralik.IdentityServer.Dtos;
using MicroserviceAralık.IdentityServer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceAralik.IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RegisterController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(UserRegistrationDtoo model)
        {

            var result = await _userManager.CreateAsync(new ApplicationUser
            {
                UserName = model.Username,
                Email = model.Email,
                Name = model.Name,
                Surname = model.Surname,
            }, model.Password);


            if(!result.Succeeded) 
                return BadRequest(result.Errors.Select(m=>m.Description));

            return Ok(result.Succeeded);
        }
    }
}
