using VottingAPI.Data.Base;
using VottingAPI.Model;

namespace VottingAPI.Interface.Repository
{
    public interface IPositionRepository : IEntityBaseRepository<Position>
    {
         Task<List<Position>> GetAllPositionAsync();
    }
}