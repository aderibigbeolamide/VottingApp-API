using VottingAPI.Data.Base;
using VottingAPI.Model;

namespace VottingAPI.Interface.Repository
{
    public interface IElectionRepository : IEntityBaseRepository<Election>
    {
        Task<List<Election>> GetAllElectionAsync();
        Task<Election> GetElectionByIdAsync(int id);
    }
}