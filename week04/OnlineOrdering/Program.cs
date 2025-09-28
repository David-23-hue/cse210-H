// Program.cs
using System;

class Program
{
    static void Main(string[] args)
    {
        // ===== Order 1: USA Customer =====
        Address address1 = new Address("123 Main St", "Provo", "UT", "USA");
        Customer customer1 = new Customer("John Smith", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Wireless Mouse", "M100", 25.99, 2));
        order1.AddProduct(new Product("USB-C Cable", "C200", 12.50, 3));

        // Display Order 1
        Console.WriteLine("=== ORDER 1 ===");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine($"Total Price: ${order1.CalculateTotal():F2}");
        Console.WriteLine();

        // ===== Order 2: International Customer =====
        Address address2 = new Address("10 Oxford Street", "London", "Greater London", "United Kingdom");
        Customer customer2 = new Customer("Emma Watson", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Mechanical Keyboard", "K300", 89.99, 1));
        order2.AddProduct(new Product("Monitor Stand", "S400", 34.75, 2));
        order2.AddProduct(new Product("Webcam", "W500", 59.99, 1));

        // Display Order 2
        Console.WriteLine("=== ORDER 2 ===");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine($"Total Price: ${order2.CalculateTotal():F2}");
    }
}