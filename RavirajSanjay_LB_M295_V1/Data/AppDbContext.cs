using Microsoft.EntityFrameworkCore;
using RavirajSanjay_LB_M295_V1.Model;

namespace RavirajSanjay_LB_M295_V1.Data
{
public class AppDbContext : DbContext
{
	public DbSet<ToDo> ToDos { get; set; }
	public DbSet<Kategorie> Kategorien { get; set; }
	public DbSet<Auflösungstabelle> Auflösungstabellen { get; set; }

	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
	{
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		// Configure entity relationships (if any)
		// modelBuilder.Entity<MyEntity>().HasOne(...);
		// modelBuilder.Entity<MyEntity>().HasMany(...);

		base.OnModelCreating(modelBuilder);
	}
}
}