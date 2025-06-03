using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MultiCompany.DataAccess;

namespace MultiCompany.Filters
{
    public class CompanyAuthorizationFilter(AppDbContext context) : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var httpContext = context.HttpContext;

            if (!httpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new RedirectToActionResult("Login", "Account", null);
            }

            var companyIdClaim= httpContext.User.FindFirst("CompanyId")?.Value;

            if(!int.TryParse(companyIdClaim, out int companyId))
            {
                context.Result = new ForbidResult(); // CompanyId yoksa erişimi engelle
                return;
            }
            // Controller ya da action parametrelerinde id var mı kontrol et
            if (context.ActionArguments.TryGetValue("id", out var routeCompanyIdObj) && routeCompanyIdObj is int routeCompanyId)
            {
                if (routeCompanyId != companyId)
                {
                    context.Result = new ForbidResult();
                    return;
                }
            }

            await next();
        }
    }
}
