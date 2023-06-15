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
    public class DetailsModel : PageModel
    {
        private readonly FinalProject.Models.BookAppContext _context;

        public DetailsModel(FinalProject.Models.BookAppContext context)
        {
            _context = context;
        }

      public BookDetail BookDetail { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.BookDetails == null)
            {
                return NotFound();
            }

            var bookdetail = await _context.BookDetails.FirstOrDefaultAsync(m => m.Id == id);
            if (bookdetail == null)
            {
                return NotFound();
            }
            else 
            {
                BookDetail = bookdetail;
            }
            return Page();
        }
    }
}
