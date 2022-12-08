using System;
using System.Collections.Generic;

namespace SearchApplication.Models
{
    public partial class Product
    {
        public int Productid { get; set; }
        public string ProductName { get; set; } = null!;
        public string Manufature { get; set; } = null!;
        public int Price { get; set; }
        public string Seller { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
