﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectCustomersAndProducts_v02.Migrations;
using ProjectCustomersAndProducts_v02.Models;
using ProjectCustomersAndProducts_v02.Services;

namespace ProjectCustomersAndProducts_v02.Controllers
{
	public class HomeController : Controller
	{
		private readonly ICustomerService customerService;


		public HomeController(ICustomerService customerService)
		{
			this.customerService = customerService;
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

		private Migrations.CustomerProducts GetCustomerProductsDataModel(CustomerProductsViewModel customerProduct)
		{
			return new CustomerProducts
			{
				ProductId = customerProduct.ProductId,
				Product = customerProduct.Product,
				ProductName = customerProduct.ProductName,
				ProductDescription = customerProduct.ProductDescription,
				ProductCategoryId = customerProduct.ProductCategoryId,
				Balance = customerProduct.Balance,
				CustomerId = customerProduct.CustomerId,
			};
		}

		//private CustomerProductsViewModel GetCustomerProductsDataModel(CustomerProducts d)
		//{
		//	return new CustomerProductsViewModel
		//	{
		//		ProductId = d.ProductId,
		//		Product = d.Product,
		//		ProductName = d.ProductName,
		//		ProductDescription = d.ProductDescription,
		//		ProductCategoryId = d.ProductCategoryId,
		//		Balance = d.Balance,
		//		CustomerId = d.CustomerId,
		//	};
		//}


			private List<CustomerViewModel> GetCustomerViewModel(List<Customer> source)
		{
			var customers = new List<CustomerViewModel>();

			foreach (var c in source)
			{
				customers.Add(GetCustomerViewModel(c));
			}
			return customers;
		}
	}
}
