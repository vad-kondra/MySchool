using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using SchoolClasses.Services;

namespace SchoolClasses.Controllers
{
    [Route("api/v1/[controller]")]
    public class ClassesController : ControllerBase
    {
        private readonly ISchoolClassService _schoolClassService;

        public ClassesController(ISchoolClassService schoolClassService)
        {
            _schoolClassService = schoolClassService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Clazz>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            var items = await _schoolClassService.GetAllAsync();

            return Ok(items);
        }
        
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Clazz), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAsync([FromRoute]int id)
        {
            try
            {
                var item = await _schoolClassService.GetByIdAsync(id);
            
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
        public async Task<IActionResult> AddOneAsync([FromBody]Clazz item)
        {
            try
            {
                await _schoolClassService.AddOneAsync(item);

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
        public async Task<IActionResult> AddListAsync([FromBody]List<SchoolClass> items)
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
        public async Task<IActionResult> UpdateOneAsync([FromBody]Clazz item)
        {
            try
            {
                await _schoolClassService.UpdateOneAsync(item);

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
        [ProducesResponseType(typeof(Clazz), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteOneAsync([FromRoute]int id)
        {
            try
            {
                var item = await _schoolClassService.GetByIdAsync(id);
            
                if (item == null)
                {
                    return NotFound();
                }

                await _schoolClassService.DeleteOneAsync(item);

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