using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.Models.Entites
{
    public class PorductEntity
    {
        public PorductEntity()
        {
            this.Carts = new HashSet<CartEntity>();
            this.orderTables = new HashSet<orderTableEntity>();
        }

        public int ProductId { get; set; }
        public string productName { get; set; }
        public Nullable<int> SubCategoryId { get; set; }
        public int ProductPrice { get; set; }
        public Nullable<int> Discount { get; set; }
        public string ProductImage { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreatedDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CartEntity> Carts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<orderTableEntity> orderTables { get; set; }
        public virtual subCategoryEntity subCategory { get; set; }
    }
}