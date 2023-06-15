using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace FinalProject.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly BookAppContext _context;
        [BindProperty]
        public string Search { get; set; }

        [BindProperty]
        public int currentId { get; set; }
        public DetailsModel(BookAppContext context)
        {
            _context = context;
        }
        public List<Review> reviews { get; set; }
        public Book book;
        public BookDetail bookD;
        public void OnGet(int id)
        {
            book = _context.Books.FirstOrDefault(x => x.Id == id);
            reviews =_context.Reviews.Where(b => b.BookId == id).ToList();
            bookD = _context.BookDetails.FirstOrDefault(y => y.BookId == id);
    }
        public async Task OnPostSearch()
        {
            book = _context.Books.FirstOrDefault(x => x.Id == currentId);
            reviews = _context.Reviews.Where(b => b.BookId == currentId).ToList();
            bookD = _context.BookDetails.FirstOrDefault(y => y.BookId == currentId);
            Review review = new Review();
            book = _context.Books.FirstOrDefault(x => x.Id == currentId);
            int userId = (int)HttpContext.Session.GetInt32("cuID");
            int bookId = book.Id;
            review.Information = Search;
            review.UserId = userId;
            review.BookId = bookId;
            _context.Reviews.Add(review);
            _context.SaveChanges();
        }
    }
}
