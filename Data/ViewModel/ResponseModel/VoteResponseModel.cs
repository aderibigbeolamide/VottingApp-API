using VottingAPI.ViewModel;

namespace VottingAPI.Data.ViewModel.ResponseModel
{
    public class VoteResponseModel : BaseResponse
    {
        public VoteVM Data { get; set; }
    }
}