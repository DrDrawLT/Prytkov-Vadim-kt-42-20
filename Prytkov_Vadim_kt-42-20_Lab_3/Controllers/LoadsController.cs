using Microsoft.AspNetCore.Mvc;
using Prytkov_Vadim_kt_42_20_Lab_3.Interfaces.LoadsInterfaces;
using Prytkov_Vadim_kt_42_20_Lab_3.Filters.LoadFilters;
using Prytkov_Vadim_kt_42_20_Lab_3.Interfaces.TeachersInterfaces;
using Prytkov_Vadim_kt_42_20_Lab_3.Filters.TeacherFilters;

namespace Prytkov_Vadim_kt_42_20_Lab_3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoadsController : ControllerBase
    {
        private readonly ILogger<LoadsController> _logger;
        private readonly ILoadService _loadService;
        public LoadsController(ILogger<LoadsController> logger, ILoadService loadService)
        {
            _logger = logger;
            _loadService = loadService;
        }

        [HttpPost]
        [Route("GetLoadByDepart")]
        public async Task<IActionResult> GetLoadByDepartAsync(LoadDepartFilter filter, CancellationToken cancellationToken = default)
        {
            var loads = await _loadService.GetLoadByDepartAsync(filter, cancellationToken);

            return Ok(loads);
        }

        [HttpPost]
        [Route("GetLoadByDiscipline")]
        public async Task<IActionResult> GetLoadByDisciplineAsync(LoadDisciplineFilter filter, CancellationToken cancellationToken = default)
        {
            var loads = await _loadService.GetLoadByDisciplineAsync(filter, cancellationToken);

            return Ok(loads);
        }

        [HttpPost]
        [Route("GetLoadByTeacher")]
        public async Task<IActionResult> GetLoadByTeacherAsync(LoadTeachersFilter filter, CancellationToken cancellationToken = default)
        {
            var loads = await _loadService.GetLoadByTeacherAsync(filter, cancellationToken);

            return Ok(loads);
        }
    }
}
