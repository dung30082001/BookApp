using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalProject.Models;

namespace FinalProject.Pages.CRUDBookDetail
{
    public class EditModel : PageModel
    {
        private readonly FinalProject.Models.BookAppContext _context;

        public EditModel(FinalProject.Models.BookAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BookDetail BookDetail { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.BookDetails == null)
            {
                return NotFound();
            }

            var bookdetail =  await _context.BookDetails.FirstOrDefaultAsync(m => m.Id == id);
            if (bookdetail == null)
            {
                return NotFound();
            }
            BookDetail = bookdetail;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(BookDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookDetailExists(BookDetail.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BookDetailExists(int id)
        {
          return (_context.BookDetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
