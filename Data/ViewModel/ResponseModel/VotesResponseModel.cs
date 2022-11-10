using VottingAPI.ViewModel;

namespace VottingAPI.Data.ViewModel.ResponseModel
{
    public class VotesResponseModel : BaseResponse
    {
        public List<VoteVM> Data { get; set; } = new List<VoteVM>();
    }
}