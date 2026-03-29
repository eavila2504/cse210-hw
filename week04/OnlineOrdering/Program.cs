using System;

class Program
{
    static void Main(string[] args)
    {
        Address usaAddress = new Address("123  Main Street", "New York", "NY", "USA");
        Address internationalAddress = new Address("45 Oxford Street", "London", "Greater London", "UK");

        Customer johnSmith = new Customer("John Smith", usaAddress);
        Customer emmaWatson = new Customer("Emma Watson", internationalAddress);

        Product laptop = new Product("Laptop Computer", "P1001", 999.99, 1);
        Product mouse = new Product("Wireless Mouse" , "P1002", 29.99, 2);
        Product keyboard = new Product("Mechanical Keyboard", "P1003", 89.99, 1);
        Product monitor = new Product("27-inch Monitor", "P1004", 299.99, 1);
        Product headphones = new Product("Noise Cancelling Headphones", "P1005", 159.99, 1);
        Product usbCable = new Product("USB-C Cable", "P1006", 12.99, 3);

        Order order1 = new Order(johnSmith);
        order1.AddProduct(laptop);
        order1.AddProduct(mouse);
        order1.AddProduct(keyboard);

        Order order2 = new Order(emmaWatson);
        order2.AddProduct(monitor);
        order2.AddProduct(headphones);
        order2.AddProduct(usbCable);

        double order1Subtotal = laptop.GetProductTotal() + mouse.GetProductTotal() + keyboard.GetProductTotal();
        double order2Subtotal = monitor.GetProductTotal() + headphones.GetProductTotal() + usbCable.GetProductTotal();

        Console.WriteLine("=".PadRight(60, '='));
        Console.WriteLine($"ORDER 1 - Customer: {order1.GetCustomerObject()}");
        Console.WriteLine("=".PadRight(60, '='));
        Console.WriteLine();
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine($"Subtotal: ${order1Subtotal:F2}");
        Console.WriteLine($"Shipping: ${order1.GetTotalCost() - order1Subtotal:F2}");
        Console.WriteLine($"TOTAL ORDER COST: ${order1.GetTotalCost():F2}");
        Console.WriteLine();

        Console.WriteLine("=".PadRight(60, '='));
        Console.WriteLine($"ORDER 2 - Customer: {order2.GetCustomerObject()}");
        Console.WriteLine("=".PadRight(60, '='));
        Console.WriteLine();
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine($"Subtotal: ${order2Subtotal:F2}");
        Console.WriteLine($"Shipping: ${order2.GetTotalCost() - order2Subtotal:F2}");
        Console.WriteLine($"TOTAL ORDER COST: ${order2.GetTotalCost():F2}");
        Console.WriteLine();
    }
}