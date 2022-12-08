using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_Second.Models
{
        public class Person
        {
            /// <summary>
            /// The Unique Primary Key
            /// </summary>
            [Key]
            public int PersonUniqueId { get; set; }
            [Required]
            [StringLength(100)]
            public string PersonId { get; set; }
            [Required]
            [StringLength(400)]
            public string PersonName { get; set; }
            [Required]
            [StringLength(700)]
            public string Address { get; set; }
            [Required]
            public int Age { get; set; }
            [Required]
            [StringLength(50)]
            public string Email { get; set; }
        }
}
