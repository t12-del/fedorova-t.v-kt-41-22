﻿using Microsoft.AspNetCore.Mvc;
using fedorova_t.v_kt_41_22.Filters.LoadFilters;
using fedorova_t.v_kt_41_22.Interfaces.LoadInterfaces;
using fedorova_t.v_kt_41_22.Models.DTO;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using fedorova_t.v_kt_41_22.Database;

namespace fedorova_t.v_kt_41_22.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoadsController : ControllerBase
    {
        private readonly ILogger<LoadsController> _logger;
        private readonly ILoadService _loadService;
        private readonly TeacherDbContext _dbContext;

        public LoadsController(
            ILogger<LoadsController> logger,
            ILoadService loadService,
            TeacherDbContext dbContext)
        {
            _logger = logger;
            _loadService = loadService;
            _dbContext = dbContext;
        }

        [HttpPost("filter")]
        public async Task<IActionResult> GetFilteredLoads(
            [FromBody] LoadFilter filter,
            CancellationToken cancellationToken)
        {
            var loads = await _loadService.GetLoadsAsync(filter, cancellationToken);
            return Ok(loads);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLoadById(int id, CancellationToken cancellationToken)
        {
            var load = await _loadService.GetLoadByIdAsync(id, cancellationToken);
            if (load == null) return NotFound();
            return Ok(load);
        }

        [HttpPost("{create}")]
        public async Task<IActionResult> CreateLoad(
            [FromBody] AddLoadDto loadDto,
            CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Проверка существования преподавателя и дисциплины
            var teacherExists = await _dbContext.Teachers.AnyAsync(t => t.Id == loadDto.TeacherId, cancellationToken);
            var disciplineExists = await _dbContext.Disciplines.AnyAsync(d => d.Id == loadDto.DisciplineId, cancellationToken);

            if (!teacherExists || !disciplineExists)
                return BadRequest("Преподаватель или дисциплина не найдены");

            var createdLoad = await _loadService.AddLoadAsync(loadDto, cancellationToken);
            return CreatedAtAction(nameof(GetLoadById), new { id = createdLoad.Id }, createdLoad);
        }

        [HttpPut("{id-refresh}")]
        public async Task<IActionResult> UpdateLoad(
            int id,
            [FromBody] UpdateLoadDto loadDto,
            CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != loadDto.Id)
                return BadRequest("ID в пути и в теле запроса не совпадают");

            // Проверка существования преподавателя и дисциплины
            var teacherExists = await _dbContext.Teachers.AnyAsync(t => t.Id == loadDto.TeacherId, cancellationToken);
            var disciplineExists = await _dbContext.Disciplines.AnyAsync(d => d.Id == loadDto.DisciplineId, cancellationToken);

            if (!teacherExists || !disciplineExists)
                return BadRequest("Преподаватель или дисциплина не найдены");

            try
            {
                var updatedLoad = await _loadService.UpdateLoadAsync(loadDto, cancellationToken);
                return Ok(updatedLoad);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}