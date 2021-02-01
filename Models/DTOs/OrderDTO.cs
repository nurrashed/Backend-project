using System.Collections.Generic;

public class OrderDTO{
    public int Id { get; set; }
    public string Date { get; set; }
    public string PaymentType { get; set; }
    public string Email { get; set; }
    public int TotalPrice { get; set; }
    public int CustomerId {get;set;} 
    public CustomerDTO Customer { get; set; }   
    public ICollection<OrderDetailDTO> OrderDetails { get; set; }
}