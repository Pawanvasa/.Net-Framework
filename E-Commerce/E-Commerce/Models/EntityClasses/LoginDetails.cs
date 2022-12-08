using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_Commerce.Models
{
    public class LoginDetails
    {
        [Required(ErrorMessage ="User Name Cannot be Blank")]
        public string UserName { set; get; }
        [Required(ErrorMessage = "Password Cannot be Blank")]
        public string Password { get; set; }
    }
}