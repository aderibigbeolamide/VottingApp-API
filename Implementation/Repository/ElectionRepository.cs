using Microsoft.EntityFrameworkCore;
using VottingAPI.Data;
using VottingAPI.Data.Base;
using VottingAPI.Interface.Repository;
using VottingAPI.Model;

namespace VottingAPI.Implementation.Repository
{
    public class ElectionRepository : EntityBaseRepository<Election>, IElectionRepository
    {
        public ElectionRepository(VottingAppApiContext context) : base(context)
        {
        }

        public async Task<List<Election>> GetAllElectionAsync()
        {
            return await _context.Elections.ToListAsync();
        }

        public async Task<Election> GetElectionByIdAsync(int id)
        {
            return await _context.Elections.FirstOrDefaultAsync(x => x.id == id);
        }
    }
}