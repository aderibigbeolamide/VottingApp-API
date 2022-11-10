using VottingAPI.ViewModel;

namespace VottingAPI.Data.ViewModel.ResponseModel
{
    public class ContestantsResponseModel : BaseResponse
    {
        public List<ContestantVM> Data { get; set; } = new List<ContestantVM>();
    }
}