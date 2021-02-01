using System;
using System.Collections.Generic;

public class Movie{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public string Genre { get; set; }
    public string ActorName { get; set; }
    public string Year { get; set; }
    public string ImageUrl { get; set; }
    //public ICollection<OrderDetail> OrderDetails { get; set; }
}