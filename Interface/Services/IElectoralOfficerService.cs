using VottingAPI.Data.ViewModel.RequestModel;
using VottingAPI.Data.ViewModel.ResponseModel;

namespace VottingAPI.Interface.Services
{
    public interface IElectoralOfficerService
    {
        Task<BaseResponse> CreateElectoralOfficerAsync(CreateElectoralOfficerRequestModel model);
        Task<BaseResponse> UpdateElectoralOfficerAsync(UpdateElectoralOfficerRequestModel model, int id);
        Task<BaseResponse> DeleteElectoralOfficerAsync(int id);
        Task<BaseResponse> GetElectoralOfficerByRole(int id, Role role);
        Task<ElectoralOfficerResponseModel> LoginByEmailAndPasswordAsync(string email, string password);
        Task<ElectoralOfficersResponseModel> GetAllElectoralOfficersAsync();
    }
}