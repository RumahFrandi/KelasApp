﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Kelas.App.Core.ClassRoom;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Kelas.App.API.Controllers
{
    [Route("api/[controller]")]
    public class ClassRoomController : Controller
    {
        private IClassRoomService _classRoomSvc;
        
        public ClassRoomController(IClassRoomService classRoomSvc)
        {
            _classRoomSvc = classRoomSvc;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _classRoomSvc.GetClassRoom(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] NewClassRoom item)
        {
            if (string.IsNullOrEmpty(item.Name))
                return BadRequest("Name is required");

            return Created("", await _classRoomSvc.CreateClassRoom(item));
        }
    }
}
