using System.Collections.Generic;

public class OrderDTO{
    public int Id { get; set; }
    public string Date { get; set; }
    public string PaymentType { get; set; }
    public int TotalPrice { get; set; }

    public int CustomerId {get;set;} 
    public ICollection<OrderDetailDTO> OrderDetails { get; set; }
}