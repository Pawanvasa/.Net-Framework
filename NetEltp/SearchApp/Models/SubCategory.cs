using System;
using System.Collections.Generic;

namespace SearchApp.Models
{
    public partial class SubCategory
    {
        public string? SubCategoryId { get; set; }
        public string? SubCategoryName { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; } = null!;
    }
}
