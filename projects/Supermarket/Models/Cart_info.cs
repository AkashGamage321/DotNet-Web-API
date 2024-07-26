namespace Supermarket.Models;

public class Cart_info : Items
{
    public int ItemId { get; set; }
    public string? Address { get; set; }
    public string? Phone { get; set; }
    public int Stakes { get; set; }
     
}