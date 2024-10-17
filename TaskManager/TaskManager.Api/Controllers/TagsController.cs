using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.Business.Interfaces;
using TaskManager.Data.DataContext;
using TaskManager.Domain.DTOs;
using TaskManager.Domain.Entities;

namespace TaskManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly IGenericService<Tag, TagDto> _genericService;

        public TagsController(IGenericService<Tag, TagDto> genericService)
        {
            _genericService = genericService;
        }

        [HttpGet("GetAllTag")]
        public async Task<IActionResult> GettagsAsync()
        {
           var result = await _genericService.GetAllAsync();
            if (result == null)
            {
                return NoContent();
            }
           return Ok(result);
        }

        [HttpGet("GetTagById/{id}")]
        public async Task<ActionResult<TagDto>> GetTagAsync(int id)
        {
            var result = await _genericService.GetByIdAsync(id);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPut("UpdateTag/{id}")]
        public async Task<IActionResult> PutTagAsync(Tag tag)
        {
            var result = await _genericService.UpdateAsync(tag);
            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpPost("CreateTag")]
        public async Task<ActionResult<Tag>> PostTagAsync(TagDto model)
        {
            var result = await _genericService.CreateAsync(model);
            if (result == null)
            {
                return BadRequest(model);
            }

            return Ok(result);
        }

        [HttpDelete("DeleteTag/{id}")]
        public async Task<IActionResult> DeleteTagAsync(int id)
        {
            await _genericService.DeleteAsync(id);
            return Ok();

        }

        //private bool TagExists(int id)
        //{
        //    return _context.tags.Any(e => e.Id == id);
        //}
    }
}
