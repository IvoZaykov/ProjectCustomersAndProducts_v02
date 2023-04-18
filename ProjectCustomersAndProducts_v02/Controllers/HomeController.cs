using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectCustomersAndProducts_v02.Models;
using ProjectCustomersAndProducts_v02.Services;

namespace ProjectCustomersAndProducts_v02.Controllers
{
	public class HomeController : Controller
	{
		private readonly ICustomerService customerService;
		private readonly IProductService productService;


		public HomeController(ICustomerService customerService, IProductService productService)
		{
			this.customerService = customerService;
			this.productService = productService;

		}




		public IActionResult Index(int currentPage = 1)
		{
			var skip = (currentPage - 1) * 3;
			var take = 3;

			var customers = this.customerService.GetAll(skip, take);
			var totalCustomersCount = this.customerService.GetCount();

			var totalPages = totalCustomersCount / 3;
			if (totalCustomersCount % 3 > 0)
			{
				totalPages++;
			}

			var model = new CustomerViewModelList
			{
				List = GetCustomerViewModel(customers),
				CurrentPage = currentPage,
				TotalPages = totalPages,
			};

			return View(model);
		}

		public IActionResult Delete(int customerId)
		{
			this.customerService.Delete(customerId);
			return Ok();
		}

		public IActionResult EditCustomer(CustomerViewModel customer)
		{
			this.customerService.Update(GetCustomerDataModel(customer));
			return RedirectToAction("Index");
		}


		public IActionResult CustomerProducts(int CustomerId)
		{
			var customerDataModel = this.customerService.GetById(CustomerId);

			return View(GetCustomerViewModel(customerDataModel));
		}

		public IActionResult CustomerDetails(int CustomerId)
		{
			var customerDataModel = this.customerService.GetById(CustomerId);

			return View(GetCustomerViewModel(customerDataModel));
		}

		[HttpGet]
		public IActionResult AddCustomer()
		{
			return View();
		}

		[HttpPost]
		public IActionResult AddCustomer(CustomerViewModel customer)
		{
			this.customerService.Add(GetCustomerDataModel(customer));
			return RedirectToAction("Index");
		}
		[HttpGet]
		public IActionResult AddProduct()
		{
			return View();
		}

		[HttpPost]
		public IActionResult AddProduct(ProductViewModel product)
		{
			this.productService.Add(GetProductDataModel(product));
			return RedirectToAction("Index");
		}

		//public IActionResult Data()
		//{
		//	var name = names[rnd.Next(names.Length)];

		//	return Ok(new
		//	{
		//		name,
		//		age = rnd.Next(10, 50)
		//	});
		//}
		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		private Customer GetCustomerDataModel(CustomerViewModel customer)
		{
			return new Customer
			{
				CustomerId = customer.CustomerId,
				CustomerName = customer.CustomerName,
				NationalID = customer.NationalID,
				DateofBirth = customer.DateofBirth,
				Address = customer.Address,
				City = customer.City,
				Region = customer.Region,
				PostalCode = customer.PostalCode,
				Country = customer.Country,
				PhoneNumber = customer.PhoneNumber,
				PictureIDCard = customer.PictureIDCard,
				IsDeleted = customer.IsDeleted
			};
		}

		private CustomerViewModel GetCustomerViewModel(Customer c)
		{
			return new CustomerViewModel
			{
				CustomerId = c.CustomerId,
				CustomerName = c.CustomerName,
				NationalID = c.NationalID,
				DateofBirth = c.DateofBirth,
				Address = c.Address,
				City = c.City,
				Region = c.Region,
				PostalCode = c.PostalCode,
				Country = c.Country,
				PhoneNumber = c.PhoneNumber,
				PictureIDCard = c.PictureIDCard,
				IsDeleted = c.IsDeleted
			};
		}
		private List<CustomerViewModel> GetCustomerViewModel(List<Customer> source)
		{
			var customers = new List<CustomerViewModel>();

			foreach (var c in source)
			{
				customers.Add(GetCustomerViewModel(c));
			}
			return customers;
		}

		private Product GetProductDataModel(ProductViewModel product)
		{
			return new Product
			{
				ProductId = product.ProductId,
				ProductName = product.ProductName,
				ProductDescription = product.ProductDescription,
				ProductCategoryId = product.ProductCategoryId,
				Balance = product.Balance,
				CustomerId = product.CustomerId
			};
		}

		private ProductViewModel GetProductViewmodel(Product product)
		{
			return new ProductViewModel
			{
				ProductId = product.ProductId,
				ProductName = product.ProductName,
				ProductDescription = product.ProductDescription,
				ProductCategoryId = product.ProductCategoryId,
				Balance = product.Balance,
				CustomerId = product.CustomerId
			};
		}

		private CustomerProductsViewModel GetCustomerProductsViewModel(CustomerProducts d)
		{
			return new CustomerProductsViewModel
			{
				ProductId = d.ProductId,
				Product = d.Product,
				ProductName = d.ProductName,
				ProductDescription = d.ProductDescription,
				ProductCategoryId = d.ProductCategoryId,
				Balance = d.Balance,
				CustomerId = d.CustomerId,
			};
		}

		//private List<CustomerProductsViewModel> GetCustomerProductsViewModel(List<CustomerProducts> source)
		//{
		//	var customerProduct = new List<CustomerProductsViewModel>();

		//	foreach (var d in source)
		//	{
		//		customerProduct.Add(GetCustomerProductsViewModel(d));
		//	}
		//	return customerProduct;
		//}


	}
}
