using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FinalProject.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace FinalProject.Pages.CRUDBook
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient client = null;
        private string BookApiUrl = "";
        private readonly FinalProject.Models.BookAppContext _context;

        public IndexModel(FinalProject.Models.BookAppContext context)
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            BookApiUrl = "https://localhost:7118/api/Book";
            _context = context;
        }

        public IList<Book> Book { get;set; } = default!;

        public async Task OnGetAsync()
        {
            HttpResponseMessage response = await client.GetAsync(BookApiUrl);
            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            Book = JsonSerializer.Deserialize<List<Book>>(strData, options);
        }
    }
}
