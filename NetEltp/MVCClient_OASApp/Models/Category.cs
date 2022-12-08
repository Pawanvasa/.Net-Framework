namespace MVCClient_OASApp.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public decimal BasePrice { get; set; }
    }
}
