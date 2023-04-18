namespace ProjectCustomersAndProducts_v02.Services
{
	using System.Collections.Generic;
	using ProjectCustomersAndProducts_v02.Models;
	public interface IProductService
	{

		void Add(Product product);


		List<Product> GetAll(int productId);

	}
}
