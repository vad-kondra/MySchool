using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Teachers.Services;

namespace Teachers.Controllers
{
    [Route("api/v1/[controller]")]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeachersController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Teacher>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            var items = await _teacherService.GetAllAsync();

            return Ok(items);
        }
        
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Teacher), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAsync([FromRoute]int id)
        {
            try
            {
                var item = await _teacherService.GetByIdAsync(id);
            
                if (item == null)
                {
                    return NotFound();
                }

                return Ok(item);
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e);
            }
        }
        

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddOneAsync([FromBody]Teacher item)
        {
            try
            {
                await _teacherService.AddOneAsync(item);

                return Ok(item.Id);
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e);
            }
        }
        
        /*[HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddListAsync([FromBody]List<TeacherItem> items)
        {
            try
            {
                await _teacherService.AddRangeAsync(items);

                return Ok();
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e);
            }
        }*/
        
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateOneAsync([FromBody]Teacher item)
        {
            try
            {
                /*var foundItem = await _teacherService.GetByIdAsync(item.Id);
            
                if (foundItem == null)
                {
                    return NotFound();
                }*/
                
                await _teacherService.UpdateOneAsync(item);

                return Ok();
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e);
            }
        }
        
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Teacher), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteOneAsync([FromRoute]int id)
        {
            try
            {
                var item = await _teacherService.GetByIdAsync(id);
            
                if (item == null)
                {
                    return NotFound();
                }

                await _teacherService.DeleteOneAsync(item);

                return Ok();
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e);
            }
        }
    }
}