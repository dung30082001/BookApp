using FinalProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIBookController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        BookAppContext context;

        public BookController(BookAppContext _context)
        {
            context = _context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBook() => context.Books.ToList();
        [HttpPost]
        public IActionResult AddBook(Book B)
        {
            context.Books.Add(B);
            context.SaveChanges();
            return NoContent();
        }
        [HttpDelete("id")]
        public IActionResult DeleteBook(int id)
        {
            var p = context.Books.First(x => x.Id == id);
            context.Books.Remove(p);
            context.SaveChanges();
            return NoContent();
        }
        [HttpPut("id")]
        public IActionResult UpdateBook(int id, Book B)
        {
            var p = context.Books.First(x => x.Id == id);
            if (B == null)
                return NotFound();
            p.Title = B.Title;
            p.Image = B.Image;
            p.Status = B.Status;
            p.Link = B.Link;
            context.Books.Update(p);
            context.SaveChanges();
            return NoContent();
        }
    }
}

