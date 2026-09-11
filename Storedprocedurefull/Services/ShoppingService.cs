
using ShoppingCartDapper.Models;
using ShoppingCartDapper.Repositories;

namespace ShoppingCartDapper.Services;

public class ShoppingService
{
    private readonly ShoppingRepository _repository;

    public ShoppingService(ShoppingRepository repository)
    {
        _repository = repository;
    }


    // -----------------------------------------
    // ADD TO CART
    // -----------------------------------------
    public async Task AddToCartAsync(AddToCartRequest request)
    {
        if (request.UserId <= 0)
            throw new ArgumentException("Invalid User ID.");

        if (request.ProductId <= 0)
            throw new ArgumentException("Invalid Product ID.");

        if (request.Quantity <= 0)
            throw new ArgumentException("Quantity must be greater than 0.");

        await _repository.AddToCartAsync(request);
    }


    // -----------------------------------------
    // REMOVE FROM CART
    // -----------------------------------------
    public async Task RemoveFromCartAsync(RemoveFromCartRequest request)
    {
        if (request.UserId <= 0)
            throw new ArgumentException("Invalid User ID.");

        if (request.ProductId <= 0)
            throw new ArgumentException("Invalid Product ID.");

        await _repository.RemoveFromCartAsync(request);
    }


    // -----------------------------------------
    // PLACE ORDER
    // -----------------------------------------
    public async Task PlaceOrderAsync(PlaceOrderRequest request)
    {
        if (request.UserId <= 0)
            throw new ArgumentException("Invalid User ID.");

        if (request.ShippingAddressId <= 0)
            throw new ArgumentException("Invalid Shipping Address ID.");

        if (request.ShippingDate.Date < request.OrderDate.Date)
            throw new ArgumentException(
                "Shipping date cannot be before order date."
            );

        await _repository.PlaceOrderAsync(request);
    }


    // -----------------------------------------
    // CANCEL ORDER
    // -----------------------------------------
    public async Task CancelOrderAsync(CancelOrderRequest request)
    {
        if (request.OrderId <= 0)
            throw new ArgumentException("Invalid Order ID.");

        await _repository.CancelOrderAsync(request);
    }
}