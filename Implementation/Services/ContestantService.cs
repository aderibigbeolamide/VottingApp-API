using VottingAPI.Data.ViewModel.RequestModel;
using VottingAPI.Data.ViewModel.ResponseModel;
using VottingAPI.Interface.Repository;
using VottingAPI.Interface.Services;
using VottingAPI.Model;
using VottingAPI.ViewModel;

namespace VottingAPI.Implementation.Services
{
    public class ContestantService : IContestantService
    {

        private readonly IContestantRepository _contestantRepository;

        public ContestantService(IContestantRepository contestantRepository)
        {
            _contestantRepository = contestantRepository;
        }
        public async Task<BaseResponse> CheckContestantVoteAsync(int id)
        {
            var contestant = await _contestantRepository.GetByIdAsync(id);
            if (contestant == null)
            {
                return new BaseResponse
                {
                    Message = "Contestant not found",
                    Success = false
                };
            }
            return new BaseResponse
            {
                Message = $"Contestant vote is {contestant.VoteCount}",
                Success = true
            };
        }

        public async Task<BaseResponse> ContestAsyc(int id, decimal grade)
        {
            var contest = await _contestantRepository.GetByIdAsync(id);
            if (contest == null)
            {
                return new BaseResponse
                {
                    Message = "Contestant not found",
                    Success = false
                };
            }
            var contestant = await _contestantRepository.GetContestantByGradeAsync(grade);
            if(contestant.Student.Grade > 4.5m)
            {
                return new BaseResponse
                {
                    Message = "You are not eligible to contest",
                    Success = false
                };
            }
            return new BaseResponse
            {
                Message = "Contestant successfully",
                Success = true
            };
        }

        public async Task<BaseResponse> CreateContestantAsync(CreateContestRequestModel model)
        {
            var contestant = new Contestant
            {
                Description = model.Description,
                StudentId = model.StudentId,
                ElectionId = model.ElectionId,
                PositionId = model.PositionId,
                VoteCount = model.VoteCount
            };
            await _contestantRepository.AddAsync(contestant);
            return new BaseResponse
            {
                Message = "Contestant successfully created",
                Success = true
            };
        }

        public async Task<ContestantsResponseModel> GetAllContestantAsync()
        {
            var contestant = await _contestantRepository.GetAllAsync();
            if (contestant == null)
            {
                return new ContestantsResponseModel
                {
                    Message = "Contestant not found",
                    Success = false
                };
            }
            return new ContestantsResponseModel
            {
                Data = contestant.Select(x => new ContestantVM
                {
                    Description = x.Description,
                    StudentId = x.StudentId,
                    ElectionId = x.ElectionId,
                    PositionId = x.PositionId,
                    VoteCount = x.VoteCount
                }).ToList(),
                Message = "Contestant successfully retrieved",
                Success = true
            };
        }
    }
}