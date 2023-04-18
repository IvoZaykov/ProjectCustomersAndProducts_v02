namespace ProjectCustomersAndProducts_v02.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using ProjectCustomersAndProducts_v02.DataAccess;
    using ProjectCustomersAndProducts_v02.Models;
    public class ProductService : IProductService
	{
        private readonly AppDBContext db;

            public ProductService(AppDBContext db)
        {
            this.db = db; 
        }

		public void Add(Product product)
		{
			this.db.Products.Add(product);
			this.db.SaveChanges();
		}
		public List<Product> GetAll(int productID)
        {
            return this.db.Products.ToList();
        }
    }
}
