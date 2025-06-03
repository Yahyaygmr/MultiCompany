namespace MultiCompany.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string ContactEmail { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
