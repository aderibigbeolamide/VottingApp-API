using VottingAPI.Data.ViewModel.RequestModel;
using VottingAPI.Data.ViewModel.ResponseModel;

namespace VottingAPI.Interface.Services
{
    public interface IStudentService
    {
         Task<BaseResponse> CreateStudentAsync(CreateStudentRequestModel model);
         Task<BaseResponse> UpdateStudentAsync(UpdateStudentRequestModel model, int id);
         Task<BaseResponse> DeleteStudnetAsync(int id);
         Task<StudentResponseModel> ApproveStudentAsync(int id);
         Task<StudentResponseModel> LoginByMatricNoAndPasswordAsync(string MatricNo, string password);
         Task<StudentsResponseModel> GetAllStudentAsync();
    }
}