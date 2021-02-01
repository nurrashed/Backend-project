using System.Collections.Generic;

public class Order{
    public int Id { get; set; }
    public string Date { get; set; }
    public string PaymentType { get; set; }
    public string Email { get; set; }      
    public int TotalPrice { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public ICollection<OrderDetail> OrderDetails { get; set; }
}