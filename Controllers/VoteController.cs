using Microsoft.AspNetCore.Mvc;
using VottingAPI.Data;
using VottingAPI.Implementation.Repository;
using VottingAPI.Implementation.Services;
using VottingAPI.Interface.Repository;
using VottingAPI.Interface.Services;

namespace VottingAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VoteController : Controller
    {
        private readonly IVoteService _voteService;

        public VoteController(IVoteService voteService)
        {
            _voteService = voteService;
        }
        

        [HttpPost("CastVote")]
        public async Task<IActionResult> CastVote(int VoterId)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var vote = await _voteService.CastVoteAsync(VoterId);
            if (vote.Success == false)
            {
                return BadRequest(vote);
            }
            return Ok(vote);
        }

        

        [HttpGet("GetAllVotes")]
        public async Task<IActionResult> GetAllVotes(int id)
        {
           
            var vote = await _voteService.GetAllVotesAsync();
            if (vote.Success == false)
            {
                return BadRequest(vote);
            }
            return Ok(vote);
        }

        // [HttpGet]
        // public IActionResult GetHighestVoteByContestantId() => View();

        // [HttpPost]
        // public async Task<IActionResult> GetHighestVoteByContestantId(int contestantId)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return View();
        //     }
        //     var vote = await _voteService.GetHighestVoteByContestantIdAsync(contestantId);
        //     if (vote.Success == false)
        //     {
        //         ViewBag.Message = vote.Message;
        //         return View();
        //     }
        //     ViewBag.Message = vote.Message;
        //     return RedirectToAction("Index", "Vote");
        // }

    }
}