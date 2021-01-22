using System;
using System.Collections.Generic;

public class Film{
    public int Id { get; set; }
    public string FilmName { get; set; }
    public string Description { get; set; }
    public int FilmPrice { get; set; }
    public string Genre { get; set; }
    public string ActorName { get; set; }
    public string ReleaseDate { get; set; }
    public string ImagePath { get; set; }
    public ICollection<OrderDetail> OrderDetails { get; set; }
}