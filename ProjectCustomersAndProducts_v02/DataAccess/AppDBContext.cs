namespace ProjectCustomersAndProducts_v02.DataAccess
{
	using Microsoft.EntityFrameworkCore;
	using ProjectCustomersAndProducts_v02.Models;

	public class AppDBContext : DbContext

	{
		public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<CustomerProducts> CustomerProducts { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)

		{
			modelBuilder.Entity<CustomerProducts>().HasKey(pk => new { pk.ProductId, pk.CustomerId });

			modelBuilder.Entity<CustomerProducts>().
				HasOne(x => x.Product).
				WithMany(x => x.CustomerProducts).
				HasForeignKey(x => x.ProductId);

			modelBuilder.Entity<CustomerProducts>().
				HasOne(x => x.Customer).
				WithMany(x => x.CustomerProducts).
				HasForeignKey(x => x.CustomerId);
		}

	}
}
