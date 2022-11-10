using VottingAPI.Data.ViewModel.RequestModel;
using VottingAPI.Data.ViewModel.ResponseModel;
using VottingAPI.Interface.Repository;
using VottingAPI.Interface.Services;
using VottingAPI.Model;

namespace VottingAPI.Implementation.Services
{
    public class ElectionService : IElectionService
    {
        private readonly IElectionRepository _electionRepository;

        public ElectionService(IElectionRepository electionRepository)
        {
            _electionRepository = electionRepository;
        }

        public async Task<BaseResponse> CreateElectionAsync(CreateElectionRequestModel model)
        {
            var election = await _electionRepository.GetAsync(x => x.ElectionName == model.ElectionName);
            if(election != null)
            {
                return new BaseResponse
                {
                    Message = "Election already exist",
                    Success = false
                };
            }
            var newElection = new Election
            {
                ElectionName = model.ElectionName,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                IsDisplay = model.IsDisplay
            };
            await _electionRepository.AddAsync(newElection);
            return new BaseResponse
            {
                Message = "Election created successfully",
                Success = true
            };
        }

        public async Task<ElectionResponseModel> GetElectionByEndDateAsync(int id, DateTime EndDate)
        {
            var election = await _electionRepository.GetByIdAsync(id);
            if(election == null)
            {
                return new ElectionResponseModel
                {
                    Message = "Election not found",
                    Success = false
                };
            }
            if (election.EndDate < EndDate)
            {
                return new ElectionResponseModel
                {
                    Message = "Election has ended",
                    Success = false
                };
            }
            return new ElectionResponseModel
            {
                Message = "Election found",
                Success = true
            };
        }

        public async Task<ElectionResponseModel> GetElectionByStartDateAsync(int id, DateTime StartDate)
        {
            var election = await _electionRepository.GetByIdAsync(id);
            if (election == null)
            {
                return new ElectionResponseModel
                {
                    Message = "Election not found",
                    Success = false
                };
            }
            if(election.StartDate < StartDate)
            {
                return new ElectionResponseModel
                {
                    Message = "Election has started",
                    Success = false
                };
            }
            return new ElectionResponseModel
            {
                Message = "Election found",
                Success = true
            };
        }

        public async Task<List<ElectionResponseModel>> GetElectionToDisplayAsync()
        {
            var election = await _electionRepository.GetAsync(x => x.IsDisplay == true);
            if(election == null)
            {
                return new List<ElectionResponseModel>
                {
                    new ElectionResponseModel
                    {
                        Message = "No election to display",
                        Success = false
                    }
                };
            }
            return new List<ElectionResponseModel>
            {
                new ElectionResponseModel
                {
                    Message = "Election found",
                    Success = true
                }
            };
        }
    }
}