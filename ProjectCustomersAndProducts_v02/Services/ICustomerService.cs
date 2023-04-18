namespace ProjectCustomersAndProducts_v02.Services
{
	using System.Collections.Generic;
	using ProjectCustomersAndProducts_v02.Models;
	public interface ICustomerService
	{
		List<Customer> GetAll(int skip, int take);

		int GetCount();

		void Add(Customer customer);

		Customer GetById(int customerId);

		void Update(Customer customer);

		void Delete(int customerId);
	
	}
}
