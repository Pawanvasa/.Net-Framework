using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.Models.Entites
{
    public class CartEntity
    {
        public int CartId { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Nullable<int> UserId { get; set; }
        public string CartSatus { get; set; }

        public virtual PorductEntity Porduct { get; set; }
        public virtual UserTableEntity UserTable { get; set; }
    }
}