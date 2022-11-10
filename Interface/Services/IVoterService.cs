using VottingAPI.Data.ViewModel.RequestModel;
using VottingAPI.Data.ViewModel.ResponseModel;

namespace VottingAPI.Interface.Services
{
    public interface IVoterService
    {
        Task<BaseResponse> CreateVoterAsync(CreateVoterRequestModel model);
        Task<VotersResponseModel> GetAllVotersAsync();
        Task<VoterResponseModel> GetVoterByMatricNumberForElectionAsync(string matricNumber, int electionId);
    }
}