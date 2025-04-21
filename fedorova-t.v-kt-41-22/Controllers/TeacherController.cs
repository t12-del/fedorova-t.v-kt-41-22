using fedorova_t.v_kt_41_22.Filters.TeacherFilters;
using fedorova_t.v_kt_41_22.Interfaces;
using fedorova_t.v_kt_41_22.Interfaces.TeacherInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace fedorova_t.v_kt_41_22.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeacherController : ControllerBase
    {
        private readonly ILogger<TeacherController> _logger;
        private readonly ITeacherService _teacherService;

        public TeacherController(ILogger<TeacherController> logger, ITeacherService teacherService)
        {
            _logger = logger;
            _teacherService = teacherService;
        }

        [HttpPost(Name = "GetTeacherByDepartment")]
        public async Task<IActionResult> GetTeacherByDepartmentAsync(TeacherDepartmentFilter filter, CancellationToken cancellationToken = default) { 
       
            var teachers = await _teacherService.GetTeacherByDepartmentAsync(filter, cancellationToken);

            return Ok(teachers);
            }
    }
}
