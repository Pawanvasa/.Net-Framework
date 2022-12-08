using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace EF_Code_First_Copy.Models
{
    public class Person
    {
        [Key]
        public int PersonUniqueId { get; set; }
        [Required]
        [StringLength(100)]
        public string PersonId { get; set; } = string.Empty;
        [Required]
        [StringLength(300)]
        public string PersonName { get; set; } = string.Empty;
        [Required]
        [StringLength(500)]
        public string Address { get; set; } = string.Empty;
        [Required]
        public int Age { get; set; } 
    }
}
