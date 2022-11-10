using Microsoft.EntityFrameworkCore;
using VottingAPI.Data;
using VottingAPI.Data.Base;
using VottingAPI.Interface.Repository;
using VottingAPI.Model;

namespace VottingAPI.Implementation.Repository
{
    public class VoterRepository : EntityBaseRepository<Voter>, IVoterRepository
    {
        public VoterRepository(VottingAppApiContext context) : base(context)
        {
        }

        public async Task<List<Voter>> GetAllVoterAsync()
        {
            return await _context.Voters.ToListAsync();
        }

        public async Task<Voter> GetVoterByIdAsync(int id)
        {
            return await _context.Voters.FirstOrDefaultAsync(x => x.id == id);
        }
    }
}