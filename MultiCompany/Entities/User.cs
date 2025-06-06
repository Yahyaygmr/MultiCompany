﻿namespace MultiCompany.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        // Foreign Key
        public int CompanyId { get; set; }

        // Navigation Property
        public Company Company { get; set; }
    }
}
