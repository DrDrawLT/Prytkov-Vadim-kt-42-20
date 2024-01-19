using Microsoft.AspNetCore.Mvc;
using Prytkov_Vadim_kt_42_20_Lab_3.Interfaces.TeachersInterfaces;
using Prytkov_Vadim_kt_42_20_Lab_3.Filters.TeacherFilters;

namespace Prytkov_Vadim_kt_42_20_Lab_3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeachersController : ControllerBase
    {
        private readonly ILogger<TeachersController> _logger;
        private readonly ITeacherService _teacherService;
        public TeachersController(ILogger<TeachersController> logger, ITeacherService teacherService)
        {
            _logger = logger;
            _teacherService = teacherService;
        }

        [HttpPost]
        [Route("GetTeacherByDepart")]
        public async Task<IActionResult> GetTeacherByDepartAsync(TeacherDepartFilter filter, CancellationToken cancellationToken = default)
        {
            var teachers = await _teacherService.GetTeacherByDepartAsync(filter, cancellationToken);

            return Ok(teachers);
        }

        [HttpPost]
        [Route("GetTeacherByPosition")]
        public async Task<IActionResult> GetTeacherByPositionAsync(TeacherPositionFilter filter, CancellationToken cancellationToken = default)
        {
            var teachers = await _teacherService.GetTeacherByPositionAsync(filter, cancellationToken);

            return Ok(teachers);
        }

        [HttpPost]
        [Route("GetTeacherByAD")]
        public async Task<IActionResult> GetTeacherByADAsync(TeacherADFilter filter, CancellationToken cancellationToken = default)
        {
            var teachers = await _teacherService.GetTeacherByADAsync(filter, cancellationToken);

            return Ok(teachers);
        }
    }
}
