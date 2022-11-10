using VottingAPI.Data.ViewModel.RequestModel;
using VottingAPI.Data.ViewModel.ResponseModel;
using VottingAPI.Interface.Repository;
using VottingAPI.Interface.Services;
using VottingAPI.Model;
using VottingAPI.ViewModel;

namespace VottingAPI.Implementation.Services
{
    public class VoterService : IVoterService
    {
        private readonly IVoterRepository _voterRepository;
        public VoterService(IVoterRepository voterRepository)
        {
            _voterRepository = voterRepository;
        }

        public async Task<BaseResponse> CreateVoterAsync(CreateVoterRequestModel model)
        {
            var voter = await _voterRepository.GetAsync(x => x.id == model.StudentId);
            if (voter != null)
            {
                return new BaseResponse
                {
                    Message = "Voter already exist",
                    Success = false
                };
            }
            var newVoter = new Voter
            {
                id = model.StudentId,
                CastVote = model.CastVote
            };
            return new BaseResponse
            {
                Message = "Voter created successfully",
                Success = true
            };
        }

        public async Task<VotersResponseModel> GetAllVotersAsync()
        {
            var voter = await _voterRepository.GetAllAsync();
            if (voter == null)
            {
                return new VotersResponseModel
                {
                    Message = "Voter not found",
                    Success = false
                };
            }
            return new VotersResponseModel
            {
                Data = voter.Select(x => new VoterVM
                {
                    StudentId = x.id,
                    CastVote = x.CastVote
                }).ToList(),
                Message = "Voter found",
                Success = true
            };
        }


        public async Task<VoterResponseModel> GetVoterByMatricNumberForElectionAsync(string matricNumber, int electionId)
        {
            var voter = await _voterRepository.GetAsync(x => x.Student.MatricNo == matricNumber);
            if (voter == null)
            {
                return new VoterResponseModel
                {
                    Message = "Voter not found",
                    Success = false
                };
            }
            if (voter.ElectionId == electionId)
            {
                return new VoterResponseModel
                {
                    Message = "Voter has voted",
                    Success = false
                };
            }
           return new VoterResponseModel
            {
                Data = new VoterVM
                {
                    ElectionId = voter.ElectionId,
                    StudentId = voter.id,
                    CastVote = voter.CastVote
                },
                Message = "Voter found",
                Success = true
            };
        }
    }
}