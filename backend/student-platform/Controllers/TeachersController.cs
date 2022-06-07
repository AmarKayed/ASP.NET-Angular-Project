using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using student_platform.BLL.Interfaces;
using student_platform.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherManager _teacherManager;
        public TeachersController(ITeacherManager teacherManager)
        {
            _teacherManager = teacherManager;
        }

        [Authorize("Admin")]
        [HttpGet("get")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _teacherManager.GetAll());
        }

        [Authorize("Student")]
        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetId([FromRoute] int id)
        {
            return Ok(await _teacherManager.GetById(id));
        }

        [HttpPost("create/{studentId}")]
        public async Task<IActionResult> Create([FromRoute] int studentId, [FromBody] TeacherModels teacherModel)
        {
            await _teacherManager.Create(studentId, teacherModel);
            return NoContent();
        }

        [Authorize("Student")]
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromQuery] int id, [FromBody] TeacherModels teacherModel)
        {
            await _teacherManager.Update(id, teacherModel);
            return NoContent();
        }

        [Authorize("Admin")]
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _teacherManager.Delete(id);
            return NoContent();
        }

    }
}
