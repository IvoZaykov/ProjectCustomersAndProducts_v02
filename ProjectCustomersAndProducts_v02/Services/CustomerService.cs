namespace ProjectCustomersAndProducts_v02.Services
{
	using System.Linq;

	using System.Collections.Generic;
	using ProjectCustomersAndProducts_v02.DataAccess;
	using ProjectCustomersAndProducts_v02.Models;

	public class CustomerService : ICustomerService
	{
		private readonly AppDBContext db;

		public CustomerService(AppDBContext db)
		{
			this.db = db;
		}
		public void Add(Customer customer)
		{
			this.db.Customers.Add(customer);
			this.db.SaveChanges();
		}


		public void Delete(int customerId)
		{
			var customertoDelete = this.db.Customers.FirstOrDefault(x => x.CustomerId == customerId);
			if (customertoDelete == null) { return; }

			customertoDelete.IsDeleted = true;
			this.db.SaveChanges();

		}
		public List<Customer> GetAll(int skip, int take)
		{
			return this.db.Customers
			.Where(x => x.IsDeleted == false)
			.OrderByDescending(x => x.CustomerId)
			.Skip(skip)
			.Take(take)
			.ToList();

		}
		public Customer GetById(int costomerId)
		{
			return this.db.Customers.FirstOrDefault(x => x.CustomerId == costomerId);
		}

		public int GetCount() => this.db.Customers.Where(x => x.IsDeleted == false).Count();

		public void Update(Customer customer)
		{
			var customertoUpdate = this.db.Customers.FirstOrDefault(x => x.CustomerId == customer.CustomerId);
			if (customertoUpdate == null) { return; }

			customertoUpdate.CustomerId = customer.CustomerId;
			customertoUpdate.CustomerName = customer.CustomerName;
			customertoUpdate.NationalID = customer.NationalID;
			customertoUpdate.DateofBirth = customer.DateofBirth;
			customertoUpdate.Address = customer.Address;
			customertoUpdate.City = customer.City;
			customertoUpdate.Region = customer.Region;
			customertoUpdate.PostalCode = customer.PostalCode;
			customertoUpdate.Country = customer.Country;
			customertoUpdate.PhoneNumber = customer.PhoneNumber;
			customertoUpdate.PictureIDCard = customer.PictureIDCard;

			this.db.SaveChanges();
		}
	}
}
