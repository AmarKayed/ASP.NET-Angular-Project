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
    public class DeadlinesController : ControllerBase
    {
        private readonly IDeadlineManager _deadlineManager;
        public DeadlinesController(IDeadlineManager deadlineManager)
        {
            _deadlineManager = deadlineManager;
        }

        [HttpGet("get-by-student-id")]
        public async Task<IActionResult> GetByStudentId([FromQuery] int studentId)
        {
            return Ok(await _deadlineManager.GetByStudentId(studentId));
        }


        [HttpGet("get")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _deadlineManager.GetAll());
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetId([FromRoute] int id)
        {
            return Ok(await _deadlineManager.GetById(id));
        }

        [HttpPost("create/{studentId}")]
        public async Task<IActionResult> Create([FromRoute] int studentId, [FromBody] DeadlineModels deadlineModel)
        {
            await _deadlineManager.Create(studentId, deadlineModel);
            return NoContent();
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromQuery] int id, [FromBody] DeadlineModels deadlineModel)
        {
            await _deadlineManager.Update(id, deadlineModel);
            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _deadlineManager.Delete(id);
            return NoContent();
        }

    }
}
