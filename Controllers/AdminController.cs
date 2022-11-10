using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using VottingAPI.Data;
using VottingAPI.ViewModel;
using VottingAPI.Interface.Services;
using VottingAPI.Interface.Repository;
using VottingAPI.Implementation.Repository;
using VottingAPI.Implementation.Services;
using VottingAPI.Data.ViewModel.RequestModel;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace VottingAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : Controller
    {
        private readonly IElectoralOfficerService _electoralOfficerService;

        public AdminController(IElectoralOfficerService electoralOfficerService)
        {
            _electoralOfficerService = electoralOfficerService;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("AdminSignUp")]
        public async Task<IActionResult> AdminSignUp(CreateElectoralOfficerRequestModel model)
        {
            var electoral = await _electoralOfficerService.CreateElectoralOfficerAsync(model);
            if (electoral.Success == false)
            {
                return  BadRequest(electoral);
            }
            return Ok(electoral);
        }

        [HttpPut("EditProfile")]
        public async Task<IActionResult> EditProfile(UpdateElectoralOfficerRequestModel model)
        {
            var context = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var electoral = await _electoralOfficerService.UpdateElectoralOfficerAsync(model, Convert.ToInt32(context));
            if (electoral.Success == false)
            {
               
                return BadRequest(electoral);
            }
            return Ok(electoral);
        }
        

        [HttpPut("DeleteAdmin")]
        public async Task<IActionResult> DeleteAdmin()
        {
            var context = int.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
            var electoral = await _electoralOfficerService.DeleteElectoralOfficerAsync(context);
            if (electoral.Success == false)
            {
                return BadRequest(electoral);
            }
            return Ok(electoral);
        }

        [HttpGet("GetAllElectoralOfficer")]
        public async Task<IActionResult> GetAllElectoralOfficer()
        {
            var electoral = await _electoralOfficerService.GetAllElectoralOfficersAsync();
            if(electoral.Success == false)
            {
                return BadRequest(electoral);
            }
            return Ok(electoral);
        }
    }
}