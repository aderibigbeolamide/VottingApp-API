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
    public class ElectionCotroller : Controller
    {
        private readonly IElectionService _electionService;
       

        public ElectionCotroller(IElectionService electionService)
        {
            _electionService = electionService;
        }
        

        [HttpPost("CreateElection")]
        public async Task<IActionResult> CreateElection(CreateElectionRequestModel model)
        {
            var election = await _electionService.CreateElectionAsync(model);
            if (election.Success == false)
            {
                return BadRequest(election);
            }
            return Ok(election);
        }

        [HttpGet("GetElectionByEndDate")]
        public async Task<IActionResult> GetElectionByEndDate(int id, DateTime EndDate)
        {
            var election = await _electionService.GetElectionByEndDateAsync(id,EndDate);
            if (election.Success == false)
            {
                return BadRequest(election);
            }
            return Ok(election);
        }

        [HttpGet("GetElectionByStartDate")]
        public async Task<IActionResult> GetElectionByStartDate([FromRoute]int id, DateTime StartDate)
        {
            var election = await _electionService.GetElectionByStartDateAsync(id, StartDate);
            if (election.Success == false)
            {
                return BadRequest(election);
            }
            return Ok(election);
        }
    }
}