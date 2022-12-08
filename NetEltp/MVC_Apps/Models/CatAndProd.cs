namespace MVC_Apps.Models
{
    public class CatAndProd
    {
        public IEnumerable<Category>? Category { get; set; }
        public IEnumerable<Product>? Product { get; set; }
    }
}
