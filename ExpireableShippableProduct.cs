namespace e_commerce
{
    public class ExpireableShippableProduct : Product, IShippable
    {
        public ExpireableShippableProduct(string name, decimal price, int quantity, DateTime expireDate, double weight) : base(name, price, quantity)
        {
            ExpireDate = expireDate;
            Weight = weight;
        }

        public DateTime ExpireDate { get; set; }
        public double Weight { get; set; }

        public bool IsExpired => (DateTime.Now >= ExpireDate);

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
