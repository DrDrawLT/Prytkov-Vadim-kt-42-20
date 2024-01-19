using Prytkov_Vadim_kt_42_20_Lab_3.DB;
using Prytkov_Vadim_kt_42_20_Lab_3.Filters.LoadFilters;
using Prytkov_Vadim_kt_42_20_Lab_3.Models;
using Microsoft.EntityFrameworkCore;

namespace Prytkov_Vadim_kt_42_20_Lab_3.Interfaces.LoadsInterfaces
{
    public interface ILoadService
    {
        public Task<LoadPerHour[]> GetLoadByDepartAsync(LoadDepartFilter filter, CancellationToken cancellationToken);
        public Task<LoadPerHour[]> GetLoadByDisciplineAsync(LoadDisciplineFilter filter, CancellationToken cancellationToken);
        public Task<LoadPerHour[]> GetLoadByTeacherAsync(LoadTeachersFilter filter, CancellationToken cancellationToken);
    }

    public class LoadService:ILoadService
    {
        private readonly PrepodDBContext _dbContext;
        public LoadService(PrepodDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public Task<LoadPerHour[]> GetLoadByDepartAsync(LoadDepartFilter filter, CancellationToken cancellationToken = default)
        {
            var loads = _dbContext.Set<LoadPerHour>().Where(w => w.Department.Name == filter.DepartName).ToArrayAsync(cancellationToken);
            return loads;
        }
        public Task<LoadPerHour[]> GetLoadByDisciplineAsync(LoadDisciplineFilter filter, CancellationToken cancellationToken = default)
        {
            var loads = _dbContext.Set<LoadPerHour>().Where(w => w.Discipline.Name == filter.DiscipName).ToArrayAsync(cancellationToken);
            return loads;
        }
        public Task<LoadPerHour[]> GetLoadByTeacherAsync(LoadTeachersFilter filter, CancellationToken cancellationToken = default)
        {
            var loads = _dbContext.Set<LoadPerHour>().Where(w => w.Teacher.SecName == filter.SecName).ToArrayAsync(cancellationToken);
            return loads;
        }
    }
}
