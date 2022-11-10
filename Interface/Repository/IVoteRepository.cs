using VottingAPI.Data.Base;
using VottingAPI.Model;

namespace VottingAPI.Interface.Repository
{
    public interface IVoteRepository : IEntityBaseRepository<Vote>
    {
         Task<List<Vote>> GetAllVoteAsync();
    }
}