using VottingAPI.ViewModel;

namespace VottingAPI.Data.ViewModel.ResponseModel
{
    public class VoterResponseModel : BaseResponse
    {
        public VoterVM Data { get; set; }
    }
}