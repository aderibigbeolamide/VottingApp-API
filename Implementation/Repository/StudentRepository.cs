using Microsoft.EntityFrameworkCore;
using VottingAPI.Data;
using VottingAPI.Data.Base;
using VottingAPI.Interface.Repository;
using VottingAPI.Model;

namespace VottingAPI.Implementation.Repository
{
    public class StudentRepository : EntityBaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(VottingAppApiContext context) : base(context)
        {
        }
    }
}