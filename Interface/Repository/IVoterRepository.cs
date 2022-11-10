using VottingAPI.Data.Base;
using VottingAPI.Model;

namespace VottingAPI.Interface.Repository
{
    public interface IVoterRepository : IEntityBaseRepository<Voter>
    {
         Task<List<Voter>> GetAllVoterAsync();
    }
}