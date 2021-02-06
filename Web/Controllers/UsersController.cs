using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Data;
using Domain.Business;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Cors;

namespace Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUserService _userService;

        public UsersController(IUserService userService, ILogger<UsersController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult GetUsers()
        {
            _logger.LogInformation("GetUsers is called");
            return Ok(_userService.getAll().ToList());
        }

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult GetUserById(int id)
        {
            var user = _userService.get(id);

            if (user == null)
            {
                _logger.LogError("GetUserById: No User By ID: " + id);
                return NotFound();
            }
            _logger.LogInformation("GetUserById is called: " + id);
            return Ok(user);
        }

        [HttpPost("create")]
        public ActionResult<User> CreateUser([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                User usr = _userService.add(user);
                return CreatedAtAction(nameof(GetUserById), new { id = usr.Id }, usr);
            }
            return BadRequest();
        }

        [HttpPut("update/{id:int}")]
        public ActionResult Update(int id, [FromBody] User user)
        {
            if (user == null || id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _userService.update(user);
                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete("delete/{id:int}")]
        public ActionResult Delete(int id)
        {
            var user = _userService.get(id);

            if (user == null)
            {
                return NotFound();
            }

            _userService.delete(id);
            return Ok();
        }

    }
}
