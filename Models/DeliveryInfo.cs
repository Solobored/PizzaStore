namespace PizzaStore.Models;

public class DeliveryInfo
{
  public int Id { get; set; }
  public string? CustomerName { get; set; }
  public string? PhoneNumber { get; set; }
  public string? Email { get; set; }
  public string? StreetAddress { get; set; }
  public string? City { get; set; }
  public string? PostalCode { get; set; }
  public string? SpecialInstructions { get; set; }

  // Navigation property
  public int OrderId { get; set; }
  public Order? Order { get; set; }
}
