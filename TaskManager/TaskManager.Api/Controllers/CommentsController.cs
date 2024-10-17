using Microsoft.AspNetCore.Mvc;
using TaskManager.Business.Interfaces;
using TaskManager.Domain.DTOs;
using TaskManager.Domain.Entities;

namespace TaskManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IGenericService<Comment, CommentDto> _genericService;

        public CommentsController(IGenericService<Comment, CommentDto> genericService)
        {
            _genericService = genericService;
        }


        //[HttpGet("GetAllComment")]
        //public async Task<ActionResult> Getcomments()
        //{
        //    var reult = await _genericService.GetAllAsync();
        //    if (reult == null)
        //    {
        //        return NoContent();
        //    }
        //    return Ok(reult);
        //}

        [HttpGet("GetCommentById/{id}")]
        public async Task<ActionResult<Comment>> GetCommentAsync(int id)
        {
            var result = await _genericService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        [HttpPut("UpdateComment/{id}")]
        public async Task<IActionResult> PutCommentAsync(Comment comment)
        {
            var result = await _genericService.UpdateAsync(comment);
            if (result == null)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        [HttpPost("CreateComment")]
        public async Task<ActionResult<Comment>> PostCommentAsync(CommentDto  model)
        {
            var result = await _genericService.CreateAsync(model);
            if (result == null)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpDelete("DeleteComment/{id}")]
        public async Task<IActionResult> DeleteCommentAsync(int id)
        {
            await _genericService.DeleteAsync(id);
            return Ok();
        }


    }
}
