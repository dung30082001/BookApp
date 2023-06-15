using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinalProject.Pages
{
    public class ShopModel : PageModel
    {
        [BindProperty]
        public int cateId { get; set; }
        [BindProperty]
        public string Search { get; set; }
        private readonly BookAppContext _context;
        public ShopModel(BookAppContext context)
        {
            _context = context;
        }
        public List<Book> BookList;

        public List<Category> CategoryList;
        public void OnGet()
        {
            BookList = _context.Books.OrderByDescending(x=>x.Title).ToList();
            CategoryList = _context.Categories.ToList();
        }
        public void OnPost()
        {
            BookList = _context.Books.Where(m => m.CateId == cateId).OrderByDescending(x => x.Title).ToList();
            CategoryList = _context.Categories.ToList();
        }
        public void OnPostSearch()
        {
            BookList = _context.Books.Where(x => x.Title.Contains(Search)).OrderByDescending(x => x.Title).ToList();
            CategoryList = _context.Categories.ToList();
        }
    }
}
