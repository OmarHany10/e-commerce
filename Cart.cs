namespace e_commerce
{
    public class Cart
    {
        public List<Item> Items { get; private set; } = new List<Item>();

        public void add(Product product, int quantity)
        {
            SubtotalPrice += (product.Price * quantity);
            product.Quantity -= quantity;
            Item item = new Item(product, quantity);
            Items.Add(item);
        }

        public bool IsEmpty => (Items.Count == 0);
        public decimal SubtotalPrice { get; private set; }
    }
}
