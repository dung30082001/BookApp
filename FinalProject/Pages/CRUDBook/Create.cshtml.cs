using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FinalProject.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace FinalProject.Pages.CRUDBook
{
    public class CreateModel : PageModel
    {
        private readonly FinalProject.Models.BookAppContext _context;
        private readonly HttpClient client = null;
        private string BookApiUrl = "";
        public CreateModel(FinalProject.Models.BookAppContext context)
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            BookApiUrl = "https://localhost:7118/api/Book";
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Books == null || Book == null)
            {
                return Page();
            }

            string data = JsonSerializer.Serialize(Book);
            var response = await client.PostAsync(BookApiUrl, new StringContent(data));
            _context.Books.Add(Book);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
