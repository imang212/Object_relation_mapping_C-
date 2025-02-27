using Microsoft.EntityFrameworkCore;

public class DataAccess: DbContext
{
	public DataAccess(DbContextOptions<DataAccess> options)
	: base(options)
	{

	}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
		modelBuilder.Entity<Product>().Has
    }
    public DbSet<Product> Products { get; set; }
}

public class Product
{
	public int Id { get; set; }
	public string ProductName { get; set; }
}