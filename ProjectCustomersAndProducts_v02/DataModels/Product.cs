namespace ProjectCustomersAndProducts.DataModels
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductCategoryName { get; set;}
        public string ProductCategoryDescription { get; set;}
        public int ProductCategoryId { get; set;}
        public int Balance { get; set; }



    }
}
