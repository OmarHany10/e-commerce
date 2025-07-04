namespace e_commerce
{
    public class Customer
    {
        public Customer(string name, decimal balance, string address)
        {
            Name = name;
            Balance = balance;
            Address = address;
        }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public string Address { get; set; }
    }
}
