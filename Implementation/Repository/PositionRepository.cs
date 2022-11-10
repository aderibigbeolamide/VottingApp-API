using Microsoft.EntityFrameworkCore;
using VottingAPI.Data;
using VottingAPI.Data.Base;
using VottingAPI.Interface.Repository;
using VottingAPI.Model;

namespace VottingAPI.Implementation.Repository
{
    public class PositionRepository : EntityBaseRepository<Position>, IPositionRepository
    {
        public PositionRepository(VottingAppApiContext context) : base(context)
        {
        }

        public async Task<List<Position>> GetAllPositionAsync()
        {
            return await _context.Positions.ToListAsync();
        }

        public async Task<Position> GetPositionByIdAsync(int id)
        {
            return await _context.Positions.FirstOrDefaultAsync(x => x.id == id);
        }
    }
}