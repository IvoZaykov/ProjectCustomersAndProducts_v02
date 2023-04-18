namespace ProjectCustomersAndProducts_v02.Services
{
    using System.Collections.Generic;
    using ProjectCustomersAndProducts_v02.DataAccess;
    using ProjectCustomersAndProducts_v02.Models;

    public class Products
    {
		private readonly AppDBContext db;

        public Products(AppDBContext db)
		{
			this.db = db;
		}

		public List<Product> GetAll(int productID)
        {
            throw new System.NotImplementedException();
        }


        public void Add(Product product) 
        
        {
            this.db.Products.Add(product);
            this.db.SaveChanges();

        }

    }
}