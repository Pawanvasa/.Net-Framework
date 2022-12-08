using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.Models.Entites
{
    public class subCategoryEntity
    {
        public subCategoryEntity()
        {
            this.Porducts = new HashSet<PorductEntity>();
        }

        public int SubCategoryId { get; set; }
        public Nullable<int> categoryId { get; set; }
        public string SubcategoryName { get; set; }
        public string Discription { get; set; }

        public virtual categoryEntity category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PorductEntity> Porducts { get; set; }
    }
}