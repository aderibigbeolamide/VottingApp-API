using VottingAPI.Data.ViewModel.RequestModel;
using VottingAPI.Data.ViewModel.ResponseModel;

namespace VottingAPI.Interface.Services
{
    public interface IElectionService
    {
         Task<BaseResponse> CreateElectionAsync(CreateElectionRequestModel model);
         Task<List<ElectionResponseModel>> GetElectionToDisplayAsync();
        Task<ElectionResponseModel> GetElectionByStartDateAsync(int id, DateTime StartDate);
        Task<ElectionResponseModel> GetElectionByEndDateAsync(int id, DateTime EndDate);
    }
}