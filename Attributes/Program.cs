[Serializable]
public class Person
{
    public string? Name { get; set; }

    public int Age { get; set; }
}




//ASP.NET Core MVC Example

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
}


[HttpGet]
public IActionResult Get()
{
}



//Entity Framework Core Example
public class Product
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [MaxLength(100)]
    public string Description { get; set; }
}


//Unit Testing Example
[Fact]
public void Add_ShouldReturnCorrectSum()
{
}


//Custom Attribute Example
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class PermissionRequiredAttribute : Attribute
{
    public string Permission { get; }

    public PermissionRequiredAttribute(string permission)
    {
        Permission = permission;
    }
}

[PermissionRequired("Administrator")]
[PermissionRequired("Manager")]
public class Credentials
{

}

[Authorize]
[Log]
[Validate]
public void TransferMoney()
{
}


Type type = typeof(Credentials);

var permissions =
type.GetCustomAttributes(
typeof(PermissionRequiredAttribute), true);