using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using TaskManager.Business.Interfaces;
using TaskManager.Data.DataContext;
using TaskManager.Domain.DTOs;
using TaskManager.Domain.Entities;

namespace TaskManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class TaskedsController : ControllerBase
    {
        private readonly IGenericService<Tasked, TaskedDto> _genericService;

        public TaskedsController(IGenericService<Tasked, TaskedDto> genericService)
        {
            _genericService = genericService;
        }


        [HttpGet("ListTask")]
        public async Task<IActionResult> GettaskedsAsync()
        {
            var result = await _genericService.GetAllAsync();
            if (result == null)
            {
                return NoContent();
            }
            return Ok(result);
        }

        [HttpGet("GetTaskId/{id}")]
        public async Task<ActionResult<Tasked>> GetTaskedAsync(int id)
        {
            var result = await _genericService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        [HttpPut("UpdateTasked/{id}")]
        public async Task<ActionResult> PutTaskedAsync(Tasked tasked)
        {
            var result = await _genericService.UpdateAsync(tasked);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);

            //_taskedService.UpdateTasked(tasked);

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!TaskedExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return NoContent();
        }


        [HttpPost("CreateTasked")]
        public async Task<ActionResult<Tasked>> PostTaskedAsync(TaskedDto model)
        {

            var tasked = await _genericService.CreateAsync(model);
            if (tasked == null)
            {
                return BadRequest(model);
            }

            return Ok(tasked);
            
        }


        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteTaskedAsync(int id)
        {
            await _genericService.DeleteAsync(id);
            return Ok();
            
        }

        //private bool TaskedExists(int id)
        //{
        //    return _context.taskeds.Any(e => e.Id == id);
        //}
    }
}
