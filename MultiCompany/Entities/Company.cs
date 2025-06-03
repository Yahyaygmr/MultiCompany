namespace MultiCompany.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation Properties
        public ICollection<User> Users { get; set; }
        public ICollection<Customer> Customers { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
