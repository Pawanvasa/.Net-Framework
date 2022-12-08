using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_Commerce.Models.Entites
{
    public class UserEntity
    {
        [Required(ErrorMessage ="User Name Can not be Blank")]
        [StringLength(30,MinimumLength =3)]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password Can not be Blank")]
        public string Password { get; set; }
    }
}