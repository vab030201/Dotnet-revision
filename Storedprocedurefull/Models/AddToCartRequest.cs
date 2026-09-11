
namespace ShoppingCartDapper.Models;

public class AddToCartRequest
{
    public int UserId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public string Image { get; set; } = string.Empty;
}