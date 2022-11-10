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
    public class VoterController : Controller
    {
        private readonly IVoterService _voterService;

        public VoterController(IVoterService voterService)
        {
            _voterService = voterService;
        }

        [HttpPost("CreateVoter")]
        public async Task<IActionResult> CreateVoter(CreateVoterRequestModel model)
        {
            var voter = await _voterService.CreateVoterAsync(model);
            if (voter.Success == false)
            {
                return BadRequest(voter);
            }
            return Ok(voter);
        }

        [HttpGet("GetAllVoters")]
        public async Task<IActionResult> GetAllVoters(int id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var voter = await _voterService.GetAllVotersAsync();
            if (voter.Success == false)
            {
                ViewBag.Message = voter.Message;
                return View();
            }
            ViewBag.Message = voter.Message;
            return RedirectToAction("Index", "Voter");
        }

        [HttpGet("GetByMatricNumberForElection")]
        public async Task<IActionResult> GetVoterByMatricNumberForElection(string matricNumber, int electionId)
        {
            var voter = await _voterService.GetVoterByMatricNumberForElectionAsync(matricNumber, electionId);
            if (voter.Success == false)
            {
                return BadRequest(voter);
            }
            return Ok(voter);
        }
        
    }
}