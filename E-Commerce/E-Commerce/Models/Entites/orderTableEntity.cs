using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.Models.Entites
{
    public class orderTableEntity
    {
        public int OrderId { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> ShippingId { get; set; }
        public Nullable<int> ProductId { get; set; }
        public int TotalAmount { get; set; }
        public int DiscountAmount { get; set; }
        public int PayableAmount { get; set; }
        public bool IsCompleted { get; set; }
        public int Quantity { get; set; }
        public System.DateTime orderDate { get; set; }
        public string PaymentType { get; set; }

        public virtual UserTableEntity UserTable { get; set; }
        public virtual ShippingEntity Shipping { get; set; }
        public virtual PorductEntity Porduct { get; set; }
    }
}