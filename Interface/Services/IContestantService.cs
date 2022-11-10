using VottingAPI.Data.ViewModel.RequestModel;
using VottingAPI.Data.ViewModel.ResponseModel;

namespace VottingAPI.Interface.Services
{
    public interface IContestantService
    {
         Task<BaseResponse> CheckContestantVoteAsync(int id);
         Task<BaseResponse> ContestAsyc(int id, decimal grade);
         Task<BaseResponse> CreateContestantAsync(CreateContestRequestModel model);
         Task<ContestantsResponseModel> GetAllContestantAsync();
    }
}