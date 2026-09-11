
using Microsoft.Extensions.Configuration;
using ShoppingCartDapper.Data;
using ShoppingCartDapper.Models;
using ShoppingCartDapper.Repositories;
using ShoppingCartDapper.Services;

// ==========================================
// CONFIGURATION
// ==========================================

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false)
    .Build();

var connectionString =
    configuration.GetConnectionString("DefaultConnection");

if (string.IsNullOrWhiteSpace(connectionString))
{
    Console.WriteLine("Database connection string not found.");
    return;
}


// ==========================================
// DEPENDENCY CREATION
// ==========================================

var connectionFactory =
    new DbConnectionFactory(connectionString);

var repository =
    new ShoppingRepository(connectionFactory);

var service =
    new ShoppingService(repository);


// ==========================================
// APPLICATION
// ==========================================

while (true)
{
    Console.Clear();

    Console.WriteLine("========================================");
    Console.WriteLine("       TFL SHOPPING APPLICATION");
    Console.WriteLine("========================================");

    Console.WriteLine("1. Add Product to Cart");
    Console.WriteLine("2. Remove Product from Cart");
    Console.WriteLine("3. Place Order");
    Console.WriteLine("4. Cancel Order");
    Console.WriteLine("5. Exit");

    Console.WriteLine("========================================");

    Console.Write("Enter your choice: ");

    string? choice = Console.ReadLine();

    try
    {
        switch (choice)
        {
            case "1":
                await AddToCart(service);
                break;

            case "2":
                await RemoveFromCart(service);
                break;

            case "3":
                await PlaceOrder(service);
                break;

            case "4":
                await CancelOrder(service);
                break;

            case "5":
                Console.WriteLine("Application closed.");
                return;

            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine();
        Console.WriteLine("Operation failed.");
        Console.WriteLine($"Error: {ex.Message}");
    }

    Console.WriteLine();
    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
}


// ==========================================
// ADD TO CART
// ==========================================

static async Task AddToCart(ShoppingService service)
{
    Console.WriteLine();
    Console.WriteLine("---------- ADD TO CART ----------");

    Console.Write("Enter User ID: ");
    int userId = int.Parse(Console.ReadLine()!);

    Console.Write("Enter Product ID: ");
    int productId = int.Parse(Console.ReadLine()!);

    Console.Write("Enter Quantity: ");
    int quantity = int.Parse(Console.ReadLine()!);

    Console.Write("Enter Image Path: ");
    string image = Console.ReadLine() ?? string.Empty;


    var request = new AddToCartRequest
    {
        UserId = userId,
        ProductId = productId,
        Quantity = quantity,
        Image = image
    };


    await service.AddToCartAsync(request);

    Console.WriteLine();
    Console.WriteLine("Product added to cart successfully.");
}


// ==========================================
// REMOVE FROM CART
// ==========================================

static async Task RemoveFromCart(ShoppingService service)
{
    Console.WriteLine();
    Console.WriteLine("---------- REMOVE FROM CART ----------");

    Console.Write("Enter User ID: ");
    int userId = int.Parse(Console.ReadLine()!);

    Console.Write("Enter Product ID: ");
    int productId = int.Parse(Console.ReadLine()!);


    var request = new RemoveFromCartRequest
    {
        UserId = userId,
        ProductId = productId
    };


    await service.RemoveFromCartAsync(request);

    Console.WriteLine();
    Console.WriteLine("Product removed from cart successfully.");
}


// ==========================================
// PLACE ORDER
// ==========================================

static async Task PlaceOrder(ShoppingService service)
{
    Console.WriteLine();
    Console.WriteLine("---------- PLACE ORDER ----------");

    Console.Write("Enter User ID: ");
    int userId = int.Parse(Console.ReadLine()!);

    Console.Write("Enter Order Date (yyyy-MM-dd): ");
    DateTime orderDate =
        DateTime.Parse(Console.ReadLine()!);

    Console.Write("Enter Shipping Date (yyyy-MM-dd): ");
    DateTime shippingDate =
        DateTime.Parse(Console.ReadLine()!);

    Console.Write("Enter Shipping Address ID: ");
    int shippingAddressId =
        int.Parse(Console.ReadLine()!);


    var request = new PlaceOrderRequest
    {
        UserId = userId,
        OrderDate = orderDate,
        ShippingDate = shippingDate,
        ShippingAddressId = shippingAddressId
    };


    await service.PlaceOrderAsync(request);

    Console.WriteLine();
    Console.WriteLine("Order placed successfully.");
}


// ==========================================
// CANCEL ORDER
// ==========================================

static async Task CancelOrder(ShoppingService service)
{
    Console.WriteLine();
    Console.WriteLine("---------- CANCEL ORDER ----------");

    Console.Write("Enter Order ID: ");
    int orderId = int.Parse(Console.ReadLine()!);


    var request = new CancelOrderRequest
    {
        OrderId = orderId
    };


    await service.CancelOrderAsync(request);

    Console.WriteLine();
    Console.WriteLine("Order cancelled successfully.");
}
