using WebApplication2.Model;

namespace WebApplication2.Storage
{
    public class Database
    {
        public static List<Customer> Customers = new List<Customer>()
        {
            new Customer(1, "duy", new List<ProductInCart>(), new List<OldOrder>()),
            new Customer(2, "toan", new List<ProductInCart>(), new List<OldOrder>()),
            new Customer(3, "diep", new List<ProductInCart>(), new List<OldOrder>()),
            new Customer(4, "lin", new List<ProductInCart>(), new List<OldOrder>()),
        };

        public static List<Product> Products = new List<Product>() {
            new Product() {
                Id = 1,
                Name = "red hat",
                Price = 100,
                Category = "clothing",
                Rating = "25",
                Description = "top recommended item fashion clothing"
            },
            new Product() {
                Id = 2,
                Name = "banana",
                Price = 10,
                Category = "fruit",
                Rating = "30",
                Description = "fresh"
            },
            new Product() {
                Id = 3,
                Name = "pants",
                Price = 150,
                Category = "clothing",
                Rating = "50",
                Description = "fashion",
            },
            new Product() {
                Id = 4,
                Name = "orange",
                Price = 250,
                Category = "fruit",
                Rating = "80",
                Description = "fresh",
            }
        };
    }
}
