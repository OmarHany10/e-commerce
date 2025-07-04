namespace e_commerce
{
    public class Item
    {
        public Item(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
        public Product Product { get; set; }
        public int Quantity { get; set; }

    }
}
