using FinalProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIBookController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        BookAppContext context;
        public UserController(BookAppContext _context)
        {
            context = _context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUser() => context.Users.ToList();
        [HttpPost]
        public IActionResult AddUser(User U)
        {
            context.Users.Add(U);
            context.SaveChanges();
            return NoContent();
        }
        [HttpDelete("id")]
        public IActionResult DeleteCategories(int id)
        {
            var p = context.Categories.First(x => x.Id == id);
            context.Categories.Remove(p);
            context.SaveChanges();
            return NoContent();
        }
        [HttpPut("id")]
        public IActionResult UpdateCategories(int id, Category C)
        {
            var p = context.Categories.First(x => x.Id == id);
            if (C == null)
                return NotFound();
            p.Name = C.Name;
            context.Categories.Update(p);
            context.SaveChanges();
            return NoContent();
        }
    }
}
