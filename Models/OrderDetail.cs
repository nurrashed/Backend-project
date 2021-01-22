public class OrderDetail{
    public int Id { get; set; }
    public int OrderItemQuantity { get; set; }
    public int OrderItemPrice { get; set; }
    public int FilmId { get; set; }
    public Film Film { get; set; }
    public int OrderId { get; set; }
    public Order Order { get; set; }
}