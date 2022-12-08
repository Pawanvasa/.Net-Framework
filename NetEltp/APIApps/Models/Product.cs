using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using APIApps.CustomOperations.CustomeValidators;
namespace APIApps.Models
{
    public partial class Product
    {
        public Product()
        {
            Category = new HashSet<Category>();
        }
        public int ProductUniqueId { get; set; }
        public string ProductId { get; set; } = null!;
        //[SpecialCharValidation(ErrorMessage = "Invalid Product Name")]
        public string ProductName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public string Manufacturer { get; set; } = null!;

        public virtual ICollection<Category> Category { get; set; }
    }
}
