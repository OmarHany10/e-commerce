namespace e_commerce
{
    public class ShippableProduct : Product, IShippable
    {
        public ShippableProduct(string name, decimal price, int quantity, double weight) : base(name, price, quantity)
        {
            Weight = weight;
        }

        public double Weight { get; set; }

        public string GetName()
        {
            return Name;
        }

        public double GetWeight()
        {
            return Weight;
        }
    }
}
