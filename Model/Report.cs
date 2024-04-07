namespace WebApplication2.Model
{
    public class Report
    {
        public int CustomerId { get; set; }
        public List<ProductInCartResponse> InCart { get; set; }
        public int Payment { get; set; }
    }
}
