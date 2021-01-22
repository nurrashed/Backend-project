using System.Collections.Generic;

public class OrderDTO{
    public int Id { get; set; }
    public string Date { get; set; }
    public string PaymentType { get; set; }
    public int TotalPrice { get; set; }
    public List<OrderDetailDTO> OrderDetails { get; set; }
    
    
}