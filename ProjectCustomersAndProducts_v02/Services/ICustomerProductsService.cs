
namespace ProjectCustomersAndProducts_v02.Services
{
	using System.Collections.Generic;
    using ProjectCustomersAndProducts_v02.Models;

    public interface ICustomerProductsService
    {
       List<CustomerProducts> GetCustomerProducts (int customerId) ;
    }
}
