namespace e_commerce
{
    public class ExpireableProduct : Product
    {
        public ExpireableProduct(string name, decimal price, int quantity, DateTime expireDate) : base(name, price, quantity)
        {
            ExpireDate = expireDate;
        }

        public DateTime ExpireDate { get; set; }

        public bool IsExpired => (DateTime.Now >= ExpireDate);
    }
}
