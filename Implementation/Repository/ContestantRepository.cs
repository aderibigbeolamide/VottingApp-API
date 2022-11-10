using Microsoft.EntityFrameworkCore;
using VottingAPI.Data;
using VottingAPI.Data.Base;
using VottingAPI.Interface.Repository;
using VottingAPI.Model;

namespace VottingAPI.Implementation.Repository
{
    public class ContestantRepository : EntityBaseRepository<Contestant>, IContestantRepository
    {
        public ContestantRepository(VottingAppApiContext context) : base(context)
        {
        }

        public async Task<List<Contestant>> GetAllContestantAsync()
        {
            return await _context.Contestants.ToListAsync(); 
        }

        public async Task<Contestant> GetContestantByGradeAsync(decimal grade)
        {
            return await _context.Contestants.FirstOrDefaultAsync(x => x.Student.Grade == grade);
        }

        public async Task<Contestant> GetContestantByIdAsync(int id)
        {
            return await _context.Contestants.FirstOrDefaultAsync(c => c.id == id);
        }
    }
}