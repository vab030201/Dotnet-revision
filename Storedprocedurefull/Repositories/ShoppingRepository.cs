
using System.Data;
using Dapper;
using ShoppingCartDapper.Data;
using ShoppingCartDapper.Models;

namespace ShoppingCartDapper.Repositories;

public class ShoppingRepository
{
    private readonly DbConnectionFactory _connectionFactory;

    public ShoppingRepository(DbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    // -----------------------------------------
    // 1. ADD TO CART
    // -----------------------------------------
    public async Task AddToCartAsync(AddToCartRequest request)
    {
        using var connection = _connectionFactory.CreateConnection();

        await connection.OpenAsync();

        var parameters = new DynamicParameters();

        parameters.Add("uid", request.UserId);
        parameters.Add("pid", request.ProductId);
        parameters.Add("stock", request.Quantity);
        parameters.Add("img", request.Image);

        await connection.ExecuteAsync(
            "AddToCart",
            parameters,
            commandType: CommandType.StoredProcedure
        );
    }


    // -----------------------------------------
    // 2. REMOVE FROM CART
    // -----------------------------------------
    public async Task RemoveFromCartAsync(RemoveFromCartRequest request)
    {
        using var connection = _connectionFactory.CreateConnection();

        await connection.OpenAsync();

        var parameters = new DynamicParameters();

        parameters.Add("pid", request.ProductId);
        parameters.Add("uid", request.UserId);

        await connection.ExecuteAsync(
            "RemoveFromCart",
            parameters,
            commandType: CommandType.StoredProcedure
        );
    }


    // -----------------------------------------
    // 3. PLACE ORDER
    // -----------------------------------------
    public async Task PlaceOrderAsync(PlaceOrderRequest request)
    {
        using var connection = _connectionFactory.CreateConnection();

        await connection.OpenAsync();

        var parameters = new DynamicParameters();

        parameters.Add("userid", request.UserId);
        parameters.Add("odate", request.OrderDate.Date);
        parameters.Add("shipdate", request.ShippingDate.Date);
        parameters.Add("shipId", request.ShippingAddressId);

        await connection.ExecuteAsync(
            "Place_Order",
            parameters,
            commandType: CommandType.StoredProcedure
        );
    }


    // -----------------------------------------
    // 4. CANCEL ORDER
    // -----------------------------------------
    public async Task CancelOrderAsync(CancelOrderRequest request)
    {
        using var connection = _connectionFactory.CreateConnection();

        await connection.OpenAsync();

        var parameters = new DynamicParameters();

        parameters.Add("orderid", request.OrderId);

        await connection.ExecuteAsync(
            "cancel_order",
            parameters,
            commandType: CommandType.StoredProcedure
        );
    }
}



