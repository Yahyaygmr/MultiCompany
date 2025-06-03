using MultiCompany.Entities;

namespace MultiCompany.Models.UserViewModels
{
    public class CreateUserViewModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public int CompanyId { get; set; }
    }
}
