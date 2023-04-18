

namespace ProjectCustomersAndProducts_v02.Models
{
	using System.ComponentModel.DataAnnotations;
	public class CustomerProducts
	{

		public int ProductId { get; set; }
		public Product Product { get; set; }
		public string ProductName { get; set; }
		public int ProductCategoryId { get; set; }
		public string ProductDescription { get; set; }
		public int Balance { get; set; }
		public int CustomerId { get; set; }
		public Customer Customer { get; set; }

	}
}
