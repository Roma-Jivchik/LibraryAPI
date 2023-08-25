using Microsoft.AspNetCore.Mvc;
using WebLibrary.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using WebLibrary.BLL.Services.UserServices;
using WebLibrary.Domain.Requests.UserRequests;

namespace WebLibrary.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsersAsync()
        {
            var users = await _userService.GetAllAsync();

            return Ok(users);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserByIdAsync([FromRoute] Guid id)
        {
            var user = await _userService.GetAsync(id);

            if (user is null)
            {
                return NoContent();
            }

            return Ok(user);
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult> UpdateUserAsync([FromBody] UpdateUserRequest request)
        {
            var isUpdate = await _userService.UpdateAsync(request);

            if (isUpdate is false)
            {
                return BadRequest();
            }

            return Ok(isUpdate);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUserAsync([FromRoute] Guid id)
        {
            var isDelete = await _userService.DeleteAsync(id);

            if (isDelete is false)
            {
                return BadRequest();
            }

            return Ok(isDelete);
        }
    }
}
