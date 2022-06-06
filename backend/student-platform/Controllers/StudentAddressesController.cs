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
    public class StudentAddressesController : ControllerBase
    {
        private readonly IStudentAddressManager _studentAddressManager;
        public StudentAddressesController(IStudentAddressManager studentAddressManager)
        {
            _studentAddressManager = studentAddressManager;
        }

        [HttpGet("get-by-student-id")]
        public async Task<IActionResult> GetByStudentId([FromQuery] int studentId)
        {
            return Ok(await _studentAddressManager.GetByStudentId(studentId));
        }

        [HttpPut("update-by-student-id/{studentId}")]
        public async Task<IActionResult> UpdateByStudentId([FromRoute] int studentId, [FromBody] StudentAddressModels studentAddressModel)
        {
            await _studentAddressManager.UpdateByStudentId(studentId, studentAddressModel);
            return NoContent();
        }


        [HttpGet("get")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _studentAddressManager.GetAll());
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetId([FromRoute] int id)
        {
            return Ok(await _studentAddressManager.GetById(id));
        }

        [HttpPost("create/{studentId}")]
        public async Task<IActionResult> Create([FromRoute] int studentId, [FromBody] StudentAddressModels studentAddressModel)
        {
            await _studentAddressManager.Create(studentId, studentAddressModel);
            return NoContent();
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] StudentAddressModels studentAddressModel)
        {
            await _studentAddressManager.Update(id, studentAddressModel);
            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _studentAddressManager.Delete(id);
            return NoContent();
        }
    }
}
