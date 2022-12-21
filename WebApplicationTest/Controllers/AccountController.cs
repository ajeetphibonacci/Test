using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
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
            _signManager = signManager;
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel register)
        {
            var userExits = await _userManager.FindByEmailAsync(register.UserName);
            if (userExits == null) 
            {
                return NotFound();  
            }
            ApplicationUser user = new ApplicationUser()
            {
                UserName = register.UserName,
                SecurityStamp = Guid.NewGuid().ToString(),
                Email = register.Email,
            };
            var reult = await _userManager.CreateAsync(user, register.Password);
            return Ok(reult);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginModel register)
        {
            var userExits = await _userManager.FindByEmailAsync(register.UserName);
            if (userExits == null)
            {
                return NotFound();
            }
            var response = await _signManager.CheckPasswordSignInAsync(userExits, register.Password,false);
            return Ok(response); 


              
        }

    }
}
