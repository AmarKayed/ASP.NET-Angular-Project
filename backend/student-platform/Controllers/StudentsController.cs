﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using student_platform.BLL.Interfaces;
using student_platform.DAL.Entities;
using student_platform.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentManager _studentManager;
        public StudentsController(IStudentManager studentManager)
        {
            _studentManager = studentManager;
        }


        [HttpGet("get-modify")]
        public async Task<IActionResult> GetModify()
        {
            var list = await _studentManager.ModifyStudent();
            return Ok(list);
        }




        [HttpGet("get")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _studentManager.GetAll());
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetId([FromRoute] int id)
        {
            return Ok(await _studentManager.GetById(id));
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] StudentModels studentModel)
        {
            await _studentManager.Create(studentModel);
            return NoContent();
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromQuery] int id, [FromBody] StudentModels studentModel)
        {
            await _studentManager.Update(id, studentModel);
            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _studentManager.Delete(id);
            return NoContent();
        }
        
    }
}
