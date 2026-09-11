
namespace ShoppingCartDapper.Models;

public class PlaceOrderRequest
{
    public int UserId { get; set; }

    public DateTime OrderDate { get; set; }

    public DateTime ShippingDate { get; set; }

    public int ShippingAddressId { get; set; }
}