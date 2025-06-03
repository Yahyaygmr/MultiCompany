using Microsoft.AspNetCore.Mvc;
using MultiCompany.Filters;

namespace MultiCompany.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CompanyAuthorizeAttribute : TypeFilterAttribute
    {
        public CompanyAuthorizeAttribute() : base(typeof(CompanyAuthorizationFilter)) { }
    }

}
