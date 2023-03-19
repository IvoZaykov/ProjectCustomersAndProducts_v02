using System;


namespace ProjectCustomersAndProducts_v02.Models
{
    public class CustomerViewModel
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string NationalID { get; set; }
        public DateTime DateofBirth { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string PictureIDCard { get; set; }
        public bool IsDeleted { get; set; }
    }
}
