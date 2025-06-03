namespace MultiCompany.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime CreatedAt { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
