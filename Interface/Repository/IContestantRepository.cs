using VottingAPI.Data.Base;
using VottingAPI.Model;

namespace VottingAPI.Interface.Repository
{
    public interface IContestantRepository: IEntityBaseRepository<Contestant>
    {
        Task<List<Contestant>> GetAllContestantAsync();
        Task<Contestant> GetContestantByIdAsync(int id);
        Task<Contestant> GetContestantByGradeAsync(decimal grade);
    }
}