using System;

class Program
{
    static void Main()
    {
        // Order 1 - USA customer
        Address address1 = new Address("123 Main St", "Provo", "UT", "USA");
        Customer customer1 = new Customer("Alice Johnson", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("USB Cable", "P001", 5.99, 3));
        order1.AddProduct(new Product("Keyboard", "P002", 29.99, 1));

        DisplayOrder(order1);

        // Order 2 - International customer
        Address address2 = new Address("456 High St", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Bob Smith", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Laptop", "P003", 999.99, 1));
        order2.AddProduct(new Product("Mouse", "P004", 15.50, 2));
        order2.AddProduct(new Product("Webcam", "P005", 50.00, 1));

        DisplayOrder(order2);
    }

    static void DisplayOrder(Order order)
    {
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order.GetTotalCost():0.00}");
        Console.WriteLine(new string('-', 40));
    }
}
