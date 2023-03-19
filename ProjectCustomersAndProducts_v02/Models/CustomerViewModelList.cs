using System.Collections.Generic;

namespace ProjectCustomersAndProducts_v02.Models
{
    public class CustomerViewModelList
    {
        public List<CustomerViewModel> List { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }
    }
}
