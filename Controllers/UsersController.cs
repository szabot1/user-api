using Microsoft.AspNetCore.Mvc;
using Users.Data;
using Users.Models;

namespace Users.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UsersController : ControllerBase
    {

        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> GetAll(UsersContext ctx)
        {
            return Ok(ctx.Users!.Select(user => new UserDto(
                user.Id,
                user.Name,
                user.Email,
                user.Age,
                user.RegistrationTime
            )));
        }

        [HttpGet("{id}")]
        public ActionResult<UserDto> GetById(UsersContext ctx, Guid id)
        {
            var user = ctx.Users!.FirstOrDefault(p => p.Id == id);

            if (user is null) return NotFound();

            return Ok(new UserDto(
                user.Id,
                user.Name,
                user.Email,
                user.Age,
                user.RegistrationTime
            ));
        }

        [HttpPost]
        public ActionResult<User> Create(UsersContext ctx, CreateUserDto userDto)
        {
            User user = new()
            {
                Name = userDto.Name,
                Email = userDto.Email,
                Age = userDto.Age,
            };

            ctx.Users!.Add(user);
            ctx.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public ActionResult Update(UsersContext ctx, Guid id, UpdateUserDto userDto)
        {
            var user = ctx.Users!.FirstOrDefault(p => p.Id == id);

            if (user is null) return NotFound();

            ctx.Entry(user).CurrentValues.SetValues(userDto);
            ctx.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(UsersContext ctx, Guid id)
        {
            var user = ctx.Users!.FirstOrDefault(p => p.Id == id);

            if (user is null) return NotFound();

            ctx.Users!.Remove(user);
            ctx.SaveChanges();

            return NoContent();
        }
    }
}