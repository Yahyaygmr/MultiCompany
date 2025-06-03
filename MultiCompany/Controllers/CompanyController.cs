using Microsoft.AspNetCore.Mvc;
using MultiCompany.DataAccess;
using MultiCompany.Entities;

namespace MultiCompany.Controllers
{

    public class CompanyController(AppDbContext context) : Controller
    {

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Company company)
        {
            
                context.Companies.Add(company);
                context.SaveChanges();
                return RedirectToAction("Create", "User", new { companyId = company.Id });
        }
    }

}
