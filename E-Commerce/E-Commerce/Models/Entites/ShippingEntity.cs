using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.Models.Entites
{
    public class ShippingEntity
    {
        public ShippingEntity()
        {
            this.orderTables = new HashSet<orderTableEntity>();
        }

        public int ShippingId { get; set; }
        public Nullable<int> UserId { get; set; }
        public string Address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public int Pincode { get; set; }

        public virtual ICollection<orderTableEntity> orderTables { get; set; }
        public virtual UserTableEntity UserTable { get; set; }
    }
}