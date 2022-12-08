using System;
using System.Collections.Generic;

namespace CRUD_Operations.Models
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int? Price { get; set; }
        public string? ProductDescription { get; set; }
    }
}
