using WebApplication2.Model;

namespace WebApplication2.Services
{
    public class ProductService
    {
        public static List<Product> SearchProduct(string search) {
            var products = Storage.Database.Products;
            var check = products
                .Where(x => x.Category.Contains(search) || x.Rating.Contains(search) || x.Description.Contains(search))
                .Select(x => x)
                .ToList();
            return check;
        }
    }
}
