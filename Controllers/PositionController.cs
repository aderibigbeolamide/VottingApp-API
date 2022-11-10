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
    public class PositionController : Controller
    {
        private readonly IPositionService _positionService;

        public PositionController(IPositionService positionService)
        {
            _positionService = positionService;
        }

        [HttpPost("CreatePosition")]
        public async Task<IActionResult> CreatePosition(CreatePositionRequestModel model)
        {
            var position = await _positionService.CreatePositionAsync(model);
            if (position.Success == false)
            {
                return BadRequest(position);
            }
            return Ok(position);
        }
    }
}