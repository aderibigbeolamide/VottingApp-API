using VottingAPI.Data.ViewModel.ResponseModel;

namespace VottingAPI.Interface.Services
{
    public interface IVoteService
    {
         Task<BaseResponse> CastVoteAsync(int VoterId);
         Task<VoteResponseModel> GetHighestVoteByContestantIdAsync();
         Task<VotesResponseModel> GetAllVotesAsync();
    }
}