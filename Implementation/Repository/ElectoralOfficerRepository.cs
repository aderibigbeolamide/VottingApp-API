using Microsoft.EntityFrameworkCore;
using VottingAPI.Data;
using VottingAPI.Data.Base;
using VottingAPI.Interface.Repository;
using VottingAPI.Model;

namespace VottingAPI.Implementation.Repository
{
    public class ElectoralOfficerRepository : EntityBaseRepository<ElectoralOfficer>, IElectoralOfficerRepository
    {
        public ElectoralOfficerRepository(VottingAppApiContext context) : base(context)
        {
        }
    }
}