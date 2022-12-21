using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplicationTest.Models;

namespace WebApplicationTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signManager;   
        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signManager)
        {
            _userManager = userManager;
            _signManager= signManager;  
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel register)
        {
            var userExits = await _userManager.FindByEmailAsync(register.UserName);
            ApplicationUser user = new ApplicationUser()
            {
                UserName = register.UserName,
                SecurityStamp = Guid.NewGuid().ToString(),
                Email = register.Email,
            };
            var reult = await _userManager.CreateAsync(user, register.Password);
            return Ok(reult);
          }
    }
}
