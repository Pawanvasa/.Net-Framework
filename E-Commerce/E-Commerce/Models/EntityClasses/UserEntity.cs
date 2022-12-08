using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AutoMapper;

namespace E_Commerce.Models.EntityClasses
{
    public class UserEntity
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "FirstName Cannot be blank")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName Cannot be blank")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "UserName Cannot be blank")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password Cannot be blank")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Email Cannot be blank")]
        public string Email { get; set; }
        public Nullable<System.DateTime> AccountCreated { get; set; }
        public Nullable<int> RoleId { get; set; }

    }
}