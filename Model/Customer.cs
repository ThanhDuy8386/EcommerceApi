namespace WebApplication2.Model
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProductInCart> Cart { get; set; }
        public List<OldOrder> OldCart { get; set; } 
        public Customer(int id, string name, List<ProductInCart> cart, List<OldOrder> oldCart)
        {
            this.Id = id;
            this.Name = name;
            this.Cart = cart;
            OldCart = oldCart;
        }

    }
}
