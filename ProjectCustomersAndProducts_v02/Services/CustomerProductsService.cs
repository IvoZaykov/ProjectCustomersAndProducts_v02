namespace ProjectCustomersAndProducts_v02.Services
{
	using System.Collections.Generic;
	using System.Linq;
	using ProjectCustomersAndProducts_v02.DataAccess;
	using ProjectCustomersAndProducts_v02.Models;
	public class CustomerProductsService : ICustomerProductsService
	{
		private readonly AppDBContext db;

		public CustomerProductsService(AppDBContext db)
		{
			this.db = db;
		}
		List<CustomerProducts> ICustomerProductsService.GetCustomerProducts(int customerId)
		{
			return this.db.CustomerProducts
				.Where(x => x.CustomerId == customerId)
				.ToList();
		}

	
	}
}
