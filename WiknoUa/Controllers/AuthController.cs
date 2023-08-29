using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WiknoUa.Models.Auth;
using WiknoUa.Models.Identity;
using WiknoUa.Data.Repository.IRepository;
using WiknoUa.Models.Dtos;
using WiknoUa.Data.Common.Exceptions;
using WiknoUa.Data.Repository;

namespace WiknoUa.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenRepository _tokenRepository;
        public AuthController(UserManager<ApplicationUser> userManager,
                              ITokenRepository tokenRepository)
        {
            _userManager = userManager;
            _tokenRepository = tokenRepository;
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(Register register)
        {
            var userEmailExist = await _userManager.FindByEmailAsync(register.Email);
            if (userEmailExist != null)
                return BadRequest("Email is taken");

            ApplicationUser user = new ApplicationUser()
            {
                FirstName = register.FirstName,
                LastName = register.LastName,
                UserName = register.Email,
                Email = register.Email,
                StreetAddress = register.StreetAddress,
                City = register.City,
            };

            var result = await _userManager.CreateAsync(user, register.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return BadRequest(ModelState);
            }
            return RedirectToAction("Login");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult<AuthUserDto>> Login(Login loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
            {
                return BadRequest(new ErrorResponse { Error = "Invalid email" });
            }

            if (!await _userManager.CheckPasswordAsync(user, loginDto.Password))
            {
                return BadRequest(new ErrorResponse { Error = "Invalid password" });
            }

            return RedirectToAction("Index", "Calculator");
        }
    }
}
