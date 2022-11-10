using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using VottingAPI.Data;
using VottingAPI.Data.ViewModel.RequestModel;
using VottingAPI.Implementation.Repository;
using VottingAPI.Implementation.Services;
using VottingAPI.Interface.Repository;
using VottingAPI.Interface.Services;

namespace VottingAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
           _studentService = studentService;
        }

        [HttpPost("StudentSignUp")]
        public async Task<IActionResult> StudentSignUp(CreateStudentRequestModel model)
        {
            
            var student = await _studentService.CreateStudentAsync(model);
            if (student.Success == false)
            {
                return BadRequest(student);
            }
            return Ok(student);
        }

        [HttpPut("StudentUpdate")]
        public async Task<IActionResult> StudentUpdate(UpdateStudentRequestModel model)
        {
            var context = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var student = await _studentService.UpdateStudentAsync(model, Convert.ToInt32(context));
            if (student.Success == false)
            {
                return BadRequest(student);
            }
            return Ok(student);
        }

        [HttpGet("ApproveStudent")]
        public async Task<IActionResult> ApproveStudent(int id)
        {
            var student = await _studentService.ApproveStudentAsync(id);
            if (student.Success == false)
            {
                return BadRequest(student);
            }
            return Ok(student);
        }

       [HttpGet("DeleteStudent")]
        public async Task<IActionResult> DeleteStudent()
        {
            var context = int.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
            var student = await _studentService.DeleteStudnetAsync(context);
            if (student.Success == false)
            {
                return BadRequest(student);
            }
            return Ok(student);
        }

        [HttpGet("GetAllStudent")]
        public async Task<IActionResult> GetAllStudent()
        {
            var electoral = await _studentService.GetAllStudentAsync();
            if (electoral.Success == false)
            {
                return BadRequest(electoral);
            }
            return Ok(electoral);
        }
    }
}