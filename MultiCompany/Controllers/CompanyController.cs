using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiCompany.Attributes;
using MultiCompany.DataAccess;
using MultiCompany.Entities;

namespace MultiCompany.Controllers
{
    [Authorize]
    [CompanyAuthorize]
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
        public async Task<IActionResult> Dashboard(int id)
        {
            var userCompanyId = int.Parse(User.FindFirst("CompanyId")?.Value ?? "0");

            if (id != userCompanyId)
                return Forbid(); // Başkasının şirketine erişmeye çalışıyorsa engelle

            var company = await context.Companies.FindAsync(id);
            if (company == null) return NotFound();

            return View(company);
        }
    }

}
