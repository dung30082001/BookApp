using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Principal;

namespace FinalProject.Pages
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public User User { get; set; }

        [BindProperty]

        public string confirmP { get; set; }

        public List<User> listU { get; set; }

        public BookAppContext _context;

        public RegisterModel(BookAppContext context)
        {
            _context = context;
        }
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPost()
        {
            listU = _context.Users.ToList();
            foreach (var item in listU)
            {
                if (item.UserName.Equals(User.UserName))
                {
                    ViewData["alert"] = "Tài khoản bạn vừa nhập đã tồn tại vui lòng đăng nhập lại";
                    return Page();
                }
            }
            if (!confirmP.Equals(User.Password))
            {
                ViewData["alert"] = "Xác nhận mật khẩu không chính xác vui lòng kiểm tra lại";
                return Page();
            }
            else
            {
                User.Role = 2;
                _context.Users.Add(User);
                _context.SaveChanges();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
