using Microsoft.Extensions.Primitives;
using WebApplication2.Model;
using IronXL;
using System.IO;
using System.Text;
namespace WebApplication2.Services
{
    public class CartService
    {
        public static bool AddToCart(int idCustomer, int idProduct) {
            var customers = Storage.Database.Customers;
            var currentCustomer = customers
                .FirstOrDefault(x => x.Id == idCustomer);
            if (currentCustomer == null) {
                return false;
            }
            var products = Storage.Database.Products;
            var currentProduct = products
                .FirstOrDefault(x => x.Id == idProduct);
            var currentCart = currentCustomer.Cart;
            var product = currentCart.FirstOrDefault(i => i.Id == idProduct);
            if (product == null)
            {
                var newProduct = new ProductInCart()
                {
                    Id = idProduct,
                    Quantity = 1,
                    Price = currentProduct.Price,
                };
                currentCart.Add(newProduct);
            }
            else {
                product.Quantity++;
                product.Price = currentProduct.Price * product.Quantity;
            }
            return true;
        }

        public static Report Payment(int customerId) {
            var customers = Storage.Database.Customers;
            var currentCustomer = customers.FirstOrDefault(x => x.Id == customerId);
            if (currentCustomer == null) {
                return null;
            }
            var total = currentCustomer.Cart.Sum(x => x.Price * x.Quantity);
            var productInCartResponse = currentCustomer.Cart
                .Select(x => new ProductInCartResponse()
                {
                    Id = x.Id,
                    Quantity = x.Quantity,
                    Price = x.Price,
                    Total = x.Quantity * x.Price,
                })
                .ToList();
            var final = new Report()
            {
                CustomerId = customerId,
                Payment = total,
                InCart = productInCartResponse,
            };
            return final;
        }

        public static List<OldOrder> FinalOrder(int customerId) {
            var customers = Storage.Database.Customers;
            var currentCustomer = customers.FirstOrDefault(x => x.Id == customerId);
            if (currentCustomer == null)
            {
                return null;  
            }
            var oldOrder = currentCustomer.Cart
                .Select(x => new ProductInCart() { 
                    Id = x.Id,
                    Quantity = x.Quantity,
                    Price = x.Price,
                })
                .ToList();
            var orderId = Guid.NewGuid().ToString();
            var finalOrder = currentCustomer.Cart
                .Select (x => new OldOrder() {
                    OrderId = orderId,
                    CustomerId = customerId,
                    TotalPayment = currentCustomer.Cart.Sum(x => x.Price),
                    OldCart = oldOrder
                })
                .ToList();
            var newOldOrder = new OldOrder()
            {
                OrderId = orderId,
                CustomerId = customerId,
                TotalPayment = currentCustomer.Cart.Sum(x => x.Price),
                OldCart = oldOrder
            };
            currentCustomer.OldCart.Add(newOldOrder);
            currentCustomer.Cart.Clear();
            return finalOrder;
        }

        public static List<OldOrder> InformationOfOldOrder(string orderId) {
            var customers = Storage.Database.Customers;
            var currentOldCart = customers.FirstOrDefault(x => x.OldCart != null);
            if (currentOldCart == null) {
                return null;
            }

            var currentOldOrder = currentOldCart.OldCart
                .Where(x => x.OrderId == orderId)
                .ToList();
            return currentOldOrder;
        }

        //public static void CsvOldOrder(int customerId) {
        //    var customers = Storage.Database.Customers;
        //    var currentCustomer = customers.FirstOrDefault(x => x.Id == customerId);
        //    if (currentCustomer == null) {
        //        Console.WriteLine("Wrong input");
        //    }
        //    String file = @"C:\User\CSV";
        //    String separator = ",";
        //    StringBuilder output = new StringBuilder();
        //    String[] headings = { "OrderId", "TotalPayment"};
        //    output.AppendLine(string.Join(separator, headings));
        //    foreach (OldOrder oldOrder in currentCustomer.OldCart)
        //    {
        //        String[] newLine = { oldOrder.OrderId.ToString(), oldOrder.TotalPayment.ToString()};
        //        output.Append(string.Join(separator, newLine));
        //    }
        //    try
        //    {
        //        File.AppendAllText(file, output.ToString());
        //    }
        //    catch(Exception ex) {
        //        Console.WriteLine("Data could not be written to the CSV file.");
        //        return;
        //    }
        //    Console.WriteLine("The data has been successfully saved to the CSV file");
        //}
    }
}
