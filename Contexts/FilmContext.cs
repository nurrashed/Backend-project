using Microsoft.EntityFrameworkCore;

public class FilmContext : DbContext{
    public FilmContext(DbContextOptions<FilmContext> options) 
        : base(options){}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=DB/films.db");
    }

    public DbSet<Film> Films { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
}