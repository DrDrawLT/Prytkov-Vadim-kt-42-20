using Prytkov_Vadim_kt_42_20_Lab_3.DB;
using Prytkov_Vadim_kt_42_20_Lab_3.Filters.TeacherFilters;
using Prytkov_Vadim_kt_42_20_Lab_3.Models;
using Microsoft.EntityFrameworkCore;

namespace Prytkov_Vadim_kt_42_20_Lab_3.Interfaces.TeachersInterfaces
{
    public interface ITeacherService
    {
        public Task<Teachers[]> GetTeacherByDepartAsync(TeacherDepartFilter filter, CancellationToken cancellationToken);
        public Task<Teachers[]> GetTeacherByADAsync(TeacherADFilter filter,CancellationToken cancellationToken);
        public Task<Teachers[]> GetTeacherByPositionAsync(TeacherPositionFilter filter, CancellationToken cancellationToken);
    }
    public class TeacherService : ITeacherService
    {
        private readonly PrepodDBContext _dbContext;
        public TeacherService(PrepodDBContext dBContext)
        { 
            _dbContext = dBContext;
        }
        public Task<Teachers[]> GetTeacherByDepartAsync (TeacherDepartFilter filter, CancellationToken cancellationToken = default)
        {
            var teachers = _dbContext.Set<Teachers>().Where(w => w.Depart.Name == filter.DepartName).ToArrayAsync(cancellationToken);
            return teachers;
        }
        public Task<Teachers[]> GetTeacherByADAsync(TeacherADFilter filter, CancellationToken cancellationToken = default)
        {
            var teachers = _dbContext.Set<Teachers>().Where(w => w.AcademicDegree.Name == filter.ADName).ToArrayAsync(cancellationToken);
            return teachers;
        }
        public Task<Teachers[]> GetTeacherByPositionAsync(TeacherPositionFilter filter, CancellationToken cancellationToken = default)
        {
            var teachers = _dbContext.Set<Teachers>().Where(w => w.Position.Name == filter.PositionName).ToArrayAsync(cancellationToken);
            return teachers;
        }
    }
}
