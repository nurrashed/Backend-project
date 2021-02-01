public class OrderDetail{
    public int OrderItemQuantity { get; set; }
    public int OrderItemPrice { get; set; }
    public int MovieId { get; set; }
    public Movie Movie { get; set; }
    public int OrderId { get; set; }
    public Order Order { get; set; }
}