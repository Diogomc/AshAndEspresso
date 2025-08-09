namespace AshAndEspresso.Models;

public class Order
{
    public int OrderId { get; set; }
    public int ClientId { get; set; }
    public ClientPerson ClientPerson { get; set; }
    public Product Product { get; set; }
}
