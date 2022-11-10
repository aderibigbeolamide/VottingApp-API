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
    public class ContestantController : Controller
    {
        private readonly IContestantService _contestantService;

        public ContestantController(IContestantService contestantService)
        {
            _contestantService = contestantService;
        }
        
        [HttpPost("AddContestant")]
        public async Task<IActionResult> CreateContestant(CreateContestRequestModel model)
        {
            var contestant = await _contestantService.CreateContestantAsync(model);
            if (contestant.Success == false)
            {
                return BadRequest(contestant);
            }
            return Ok(contestant);
        }
        
        [HttpGet("GetAllContestants")]
        public async Task<IActionResult> GetAllContestants(int id)
        {
            var contestant = await _contestantService.GetAllContestantAsync();
            if (contestant.Success == false)
            {
                return BadRequest(contestant);
            }
            return Ok(contestant);
        }

        [HttpGet("CheckContestantVote")]
        public async Task<IActionResult> CheckContestantVote(int id)
        {
            var contestant = await _contestantService.CheckContestantVoteAsync(id);
            if (contestant.Success == false)
            {
                return BadRequest(contestant);
            }
            return Ok(contestant);
        }

        [HttpGet("Contest")]
        public async Task<IActionResult> Contest(int id, decimal grade)
        {
            var contestant = await _contestantService.ContestAsyc(id, grade);
            if (contestant.Success == false)
            {
                return BadRequest(contestant);
            }
            return Ok(contestant);
        }
        
    }
}