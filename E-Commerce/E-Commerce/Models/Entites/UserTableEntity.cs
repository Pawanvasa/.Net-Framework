using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models.Entites
{
    public class UserTableEntity
    {
        public UserTableEntity()
        {
            this.Carts = new HashSet<CartEntity>();
            this.orderTables = new HashSet<orderTableEntity>();
            this.Shippings = new HashSet<ShippingEntity>();
        }

        public int UserId { get; set; }
        [Required(ErrorMessage = "FirstName Can not be Blank")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName Can not be Blank")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "UserName Can not be Blank")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password Can not be Blank")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Email Can not be Blank")]
        public string Email { get; set; }
        public Nullable<System.DateTime> AccountCreated { get; set; }
        public Nullable<int> RoleId { get; set; }

        public virtual ICollection<CartEntity> Carts { get; set; }
        public virtual ICollection<orderTableEntity> orderTables { get; set; }
        public virtual RoleTableEntity RoleTable { get; set; }
        public virtual ICollection<ShippingEntity> Shippings { get; set; }
    }
}