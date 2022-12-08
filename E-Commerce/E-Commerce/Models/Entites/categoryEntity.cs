using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.Models.Entites
{
    public class categoryEntity
    {
        public categoryEntity()
        {
            this.subCategories = new HashSet<subCategoryEntity>();
        }

        public int categoryid { get; set; }
        public string categoryName { get; set; }
        public Nullable<bool> IsActive { get; set; }

        public virtual ICollection<subCategoryEntity> subCategories { get; set; }
    }
}