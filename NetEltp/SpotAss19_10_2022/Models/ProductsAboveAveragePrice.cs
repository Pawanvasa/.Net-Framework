using System;
using System.Collections.Generic;

namespace SpotAss19_10_2022_DBFirstApproch.Models
{
    public partial class ProductsAboveAveragePrice
    {
        public string ProductName { get; set; } = null!;
        public decimal? UnitPrice { get; set; }
    }
}
