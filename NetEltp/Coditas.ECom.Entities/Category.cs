using System.ComponentModel.DataAnnotations;

public partial class Category
{
    public Category()
    {
        Products = new HashSet<Product>();
    }
    [Required(ErrorMessage = "Category Id is required")]
    public int CategoryId { get; set; }
    [Required(ErrorMessage = "Categoy Name is required")]
    public string CategoryName { get; set; } = null!;
    [Required(ErrorMessage = "Categoy BASE price is required")]
    public decimal BasePrice { get; set; }
    public virtual ICollection<Product> Products { get; set; }
}

