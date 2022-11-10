using VottingAPI.Data.Base;
using VottingAPI.Data.ViewModel.RequestModel;
using VottingAPI.Data.ViewModel.ResponseModel;
using VottingAPI.Model;

namespace VottingAPI.Interface.Services
{
    public interface IPositionService 
    {
         Task<BaseResponse> CreatePositionAsync(CreatePositionRequestModel model);
    }
}