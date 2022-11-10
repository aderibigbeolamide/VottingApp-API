using Microsoft.EntityFrameworkCore;
using VottingAPI.Data;
using VottingAPI.Data.Base;
using VottingAPI.Interface.Repository;
using VottingAPI.Model;

namespace VottingAPI.Implementation.Repository
{
    public class VoteRepository : EntityBaseRepository<Vote>, IVoteRepository
    {
        public VoteRepository(VottingAppApiContext context) : base(context)
        {
        }

        public async Task<List<Vote>> GetAllVoteAsync()
        {
            return await _context.Votes.ToListAsync();
        }

        public async Task<Vote> GetVoteByIdAsync(int id)
        {
            return await _context.Votes.FirstOrDefaultAsync(x => x.id == id);
        }
    }
}