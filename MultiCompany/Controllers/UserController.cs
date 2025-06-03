using Microsoft.AspNetCore.Mvc;
using MultiCompany.DataAccess;
using MultiCompany.Entities;
using MultiCompany.Models.UserViewModels;

namespace MultiCompany.Controllers
{
    public class UserController(AppDbContext context) : Controller
    {
        [HttpGet]
        [Route("{controller=Home}/{action=Index}/{companyId?}")]
        public IActionResult Create(int companyId)
        {
            ViewBag.companyId = companyId;
            return View();
        }

        [HttpPost]
        [Route("{controller=Home}/{action=Index}/{companyId?}")]
        public IActionResult Create(CreateUserViewModel userVM)
        {
            User user = new User
            {
                FullName = userVM.FullName,
                Email = userVM.Email,
                Password = userVM.Password,
                CompanyId = userVM.CompanyId
            };
            context.Users.Add(user);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }

}
