using System.Security.Cryptography.X509Certificates;

namespace WebApplication2.Model
{
    public class ProductInCart
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }

    public class ProductInCartResponse
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int Total { get; set; }
    }

    public class OldOrder { 
        public string OrderId { get; set; }
        public int CustomerId { get; set; }
        public int TotalPayment { get; set; }
        public List<ProductInCart> OldCart { get; set; }
    }
    //3, 3, 100
}
