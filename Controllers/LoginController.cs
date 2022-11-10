using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using VottingAPI.Data;
using VottingAPI.Data.ViewModel.RequestModel;
using VottingAPI.Data.ViewModel.ResponseModel;
using VottingAPI.Implementation.Repository;
using VottingAPI.Implementation.Services;
using VottingAPI.Interface.Repository;
using VottingAPI.Interface.Services;

namespace VottingAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : Controller
    {
        private readonly IStudentService _studentService;

        private readonly IElectoralOfficerService _electoralOfficerService;
        
        
        public LoginController(IStudentService studentService, IElectoralOfficerService electoralOfficerService)
        {
            _studentService = studentService;
            _electoralOfficerService = electoralOfficerService;
        }

        

        [HttpGet("StudentLogin")]
        public async Task<IActionResult> StudentLogin(string MatricNo, string Password)
        {
            if (ModelState.IsValid)
            {
                var login = await _studentService.LoginByMatricNoAndPasswordAsync(MatricNo, Password);
                if (login.Success == false)
                {
                    return Content("Invalid MatricNo or Password");
                }
                else if (login.Success == true)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, (login.Data.Id).ToString()),
                        new Claim(ClaimTypes.NameIdentifier, login.Data.MatricNo),
                        new Claim(ClaimTypes.NameIdentifier, "Student")
                    };
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties
                    {
                        AllowRefresh = true,
                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                        IsPersistent = true,
                    };
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
                    return Ok(login);
                }
            }
            return View();
        }


        [HttpGet("AdminLogin")]
        public async Task<IActionResult> AdminLogin(string email, string password)
        {
            if (ModelState.IsValid)
            {
                var login = await _electoralOfficerService.LoginByEmailAndPasswordAsync(email, password);
                if (login.Success == false)
                {
                    return Content("Invalid Email or Password");
                }
                else if (login.Success == true)
                {
                    var claims = new List<Claim>
                    {
                        new Claim (ClaimTypes.NameIdentifier, (login.Data.Id).ToString()),
                        new Claim (ClaimTypes.NameIdentifier, (login.Data.FullName)),
                        new Claim(ClaimTypes.Email, login.Data.Email),
                    };
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties
                    {
                        AllowRefresh = true,
                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                        IsPersistent = true,
                    };
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
                    return Ok(login);
                }
            }
            return View();
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok();
        }
    }
}