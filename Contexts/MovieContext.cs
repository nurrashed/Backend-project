using Microsoft.EntityFrameworkCore;

public class MovieContext : DbContext{
    public MovieContext(DbContextOptions<MovieContext> options) 
        : base(options){}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=DB/Movies.db");
    }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<OrderDetail>().HasKey(od => new { od.MovieId, od.OrderId });
    }





}