﻿using Microsoft.AspNetCore.Http;
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


        [HttpGet("get")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _teacherManager.GetAll());
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetId([FromRoute] int id)
        {
            return Ok(await _teacherManager.GetById(id));
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] TeacherModels teacherModel)
        {
            await _teacherManager.Create(teacherModel);
            return NoContent();
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromQuery] int id, [FromBody] TeacherModels teacherModel)
        {
            await _teacherManager.Update(id, teacherModel);
            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _teacherManager.Delete(id);
            return NoContent();
        }

    }
}
