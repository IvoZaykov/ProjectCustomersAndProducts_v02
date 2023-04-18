namespace ProjectCustomersAndProducts_v02.Models
{
	using System;
	using System.Collections.Generic;
	public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductCategoryId { get; set; }
        public string ProductDescription { get; set; }
        public int Balance { get; set; }
        public int CustomerId { get; set; }
        public bool IsDeleted { get; set; }
		public ICollection<CustomerProducts> CustomerProducts { get; set; }
	}
}
