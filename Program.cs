namespace e_commerce
{

    public class Program
    {
        public static void checkout(Customer customer, Cart cart)
        {
            if (cart.IsEmpty)
            {
                Console.WriteLine("Card Is Empty");
                return;
            }

            foreach (var item in cart.Items)
            {
                if (item.Quantity > item.Product.Quantity)
                {
                    Console.WriteLine($"There is only {item.Product.Quantity} {item.Product.Name} in stock");
                    return;
                }
            }


            decimal shippingFies = 0;

            foreach (var item in cart.Items)
            {
                if (item.Product is IShippable)
                    shippingFies += 10;
            }

            decimal totalPrice = cart.SubtotalPrice + shippingFies;

            if (customer.Balance < totalPrice)
            {
                Console.WriteLine("Customer balance are not enough");
                return;
            }

            double totalWeight = 0;
            Console.WriteLine("** Shipment notice **");
            foreach (var item in cart.Items)
            {
                if (item.Product is IShippable shippable)
                {
                    Console.WriteLine($"{item.Quantity}x  {item.Product.Name}  {shippable.GetWeight() * item.Quantity}g");
                    totalWeight += shippable.GetWeight();
                }
            }
            if (totalWeight > 1000)
            {
                totalWeight /= 1000;
                Console.WriteLine($"Total Package Weight {totalWeight}kg");
            }
            else
                Console.WriteLine($"Total Package Weight {totalWeight}g");

            Console.WriteLine();
            Console.WriteLine("** Checkout receipt **");
            foreach (var item in cart.Items)
            {
                Console.WriteLine($"{item.Quantity}x  {item.Product.Name}  {item.Product.Price * item.Quantity}");
                item.Product.Quantity -= item.Quantity;
            }

            Console.WriteLine("----------------------------");
            Console.WriteLine($"Subtotal   {cart.SubtotalPrice}");
            Console.WriteLine($"Shipping   {shippingFies}");
            Console.WriteLine($"Amount     {totalPrice}");
            Console.WriteLine();

            List<IShippable> shippables = new List<IShippable>();

            foreach (var item in cart.Items)
            {
                if (item.Product is IShippable shippable)
                {
                    shippables.Add(shippable);
                }
            }
            ShippingService(shippables);
        }

        public static void ShippingService(IList<IShippable> shippables)
        {

            Console.WriteLine("** Shippable Items **");
            foreach (var shippable in shippables)
            {
                Console.WriteLine($"{shippable.GetName()}  {shippable.GetWeight()}");
            }

        }
        static void Main(string[] args)
        {
            Product cheese = new ExpireableShippableProduct(name: "Cheese", price: 50, quantity: 5, weight: 200, expireDate: DateTime.Now.AddMonths(6));
            Product tv = new ShippableProduct(name: "Tv", price: 500, quantity: 8, weight: 7500);
            Product scratchCard = new OrdinaryProduct(name: "scratchCard", price: 30, quantity: 10);

            // Ex1: Default Case
            Customer customer1 = new Customer(name: "Omar", balance: 5000, address: "Benha");
            Cart cart = new Cart();
            cart.add(cheese, 2);
            cart.add(tv, 3);
            cart.add(scratchCard, 1);
            checkout(customer1, cart);
            Console.WriteLine();
            Console.WriteLine("*******************************************************************");

            // Ex2: Customer balance are not enough
            Customer customer2 = new Customer(name: "Omar2", balance: 1000, address: "Benha");
            Cart cart2 = new Cart();
            cart2.add(cheese, 2);
            cart2.add(tv, 3);
            cart2.add(scratchCard, 1);
            checkout(customer2, cart2);
            Console.WriteLine();
            Console.WriteLine("*******************************************************************");


            // Ex3: Cart arre empty
            Cart cart3 = new Cart();
            checkout(customer1, cart3);
            Console.WriteLine();
            Console.WriteLine("*******************************************************************");


            // Ex4: Out of stock
            Cart cart4 = new Cart();
            cart4.add(cheese, 10);
            checkout(customer1, cart4);



        }
    }
}
