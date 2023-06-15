using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FinalProject.Models;

namespace FinalProject.Pages.CRUDBookDetail
{
    public class IndexModel : PageModel
    {
        private readonly FinalProject.Models.BookAppContext _context;

        public IndexModel(FinalProject.Models.BookAppContext context)
        {
            _context = context;
        }

        public IList<BookDetail> BookDetail { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.BookDetails != null)
            {
                BookDetail = await _context.BookDetails.ToListAsync();
            }
        }
    }
}
