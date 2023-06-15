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

namespace FinalProject.Pages.CRUDBookDetail
{
    public class CreateModel : PageModel
    {
        private readonly FinalProject.Models.BookAppContext _context;
        private readonly HttpClient client = null;
        private string BookDetailApiUrl = "";

        public CreateModel(FinalProject.Models.BookAppContext context)
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            BookDetailApiUrl = "https://localhost:7118/api/BookDetail";
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public BookDetail BookDetail { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.BookDetails == null || BookDetail == null)
            {
                return Page();
            }

            string data = JsonSerializer.Serialize(BookDetail);
            var response = await client.PostAsync(BookDetailApiUrl, new StringContent(data));
            _context.BookDetails.Add(BookDetail);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
