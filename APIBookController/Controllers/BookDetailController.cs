using FinalProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIBookController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookDetailController : ControllerBase
    {
        BookAppContext context;

        public BookDetailController(BookAppContext _context)
        {
            context = _context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<BookDetail>> GetBookDetails() => context.BookDetails.ToList();
        [HttpPost]
        public IActionResult AddBookDetail(BookDetail BD)
        {
            context.BookDetails.Add(BD);
            context.SaveChanges();
            return NoContent();
        }
        [HttpDelete("id")]
        public IActionResult DeletePBookDetail(int id)
        {
            var p = context.BookDetails.First(x => x.Id == id);
            context.BookDetails.Remove(p);
            context.SaveChanges();
            return NoContent();
        }
        [HttpPut("id")]
        public IActionResult UpdateBookDetail(int id, BookDetail BD)
        {
            var p = context.BookDetails.First(x => x.Id == id);
            if (BD == null)
                return NotFound();
            p.BookId = BD.BookId;
            p.Author = BD.Author;
            p.Detail = BD.Detail;
            context.BookDetails.Update(p);
            context.SaveChanges();
            return NoContent();
        }
    }
}
