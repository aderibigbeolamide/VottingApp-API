using VottingAPI.ViewModel;

namespace VottingAPI.Data.ViewModel.ResponseModel
{
    public class ElectoralOfficersResponseModel : BaseResponse
    {
        public List<ElectoralOfficerVM> Data { get; set; } = new List<ElectoralOfficerVM>();
    }
}