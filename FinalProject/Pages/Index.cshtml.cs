using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace FinalProject.Pages
{
    public class IndexModel : PageModel
    {
        private readonly BookAppContext _context;

        public IndexModel(BookAppContext context)
        {
            _context = context;
        }

        [BindProperty]

        public int Role { get; set; }
        [BindProperty]
        public Models.User User { get; set; }

        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                Encryption en = new Encryption();
                //string newP = en.Encrypt(User.Password);
                var acc = await _context.Users.SingleOrDefaultAsync(a => a.UserName.Equals(User.UserName) && a.Password.Equals(User.Password));
                if (acc != null)
                {                   
                    Role = (int)acc.Role;
                    HttpContext.Session.SetInt32("cuID", acc.Id);
                    HttpContext.Session.SetString("CustSession", JsonSerializer.Serialize(acc));
                    HttpContext.Session.SetInt32("Role", Role);
                    if (Role == 1)
                    {
                        return RedirectToPage("/Admin");
                    }
                    return RedirectToPage("/Shop");
                }
                else
                {
                    ViewData["msg"] = "Bạn đã nhập sai tài khoản hoặc mật khẩu vui lòng kiểm tra lại";
                    return Page();
                }
            }
            else
            {
                return Page();
            }
        }
    }
}