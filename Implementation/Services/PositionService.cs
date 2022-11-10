using VottingAPI.Data.ViewModel.RequestModel;
using VottingAPI.Data.ViewModel.ResponseModel;
using VottingAPI.Interface.Repository;
using VottingAPI.Interface.Services;
using VottingAPI.Model;

namespace VottingAPI.Implementation.Services
{
    public class PositionService : IPositionService
    {
        private readonly IPositionRepository _positionRepository;
        public PositionService(IPositionRepository positionRepository)
        {
            _positionRepository = positionRepository;
        }

        public async Task<BaseResponse> CreatePositionAsync(CreatePositionRequestModel model)
        {
            var position = await _positionRepository.GetAsync(x => x.PositionName == model.PositionName);
            if (position != null)
            {
                return new BaseResponse
                {
                    Message = "Position already exist",
                    Success = false
                };
            }
            var newPosition = new Position
            {
                PositionName = model.PositionName
            };
            return new BaseResponse
            {
                Message = "Position created successfully",
                Success = true
            };
        }
    }
}