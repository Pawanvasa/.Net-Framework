using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EF_Code_First.Models
{
    public class Person
    {
        /// <summary>
        /// This key is uniqe Primary Kay
        /// </summary>
        [Key]
        public int PersonUniqueId { get; set; }
        [Required]
        [StringLength(100)]
        public string PersonId { get; set; }=string.Empty;
        [Required]
        [StringLength(400)]
        public string PersonName { get; set; } = string.Empty;
        [Required]
        [StringLength(500)]
        public string Address { get; set; } = string.Empty;
        [Required]
        public int Age { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }=string.Empty;

    }
    public class Department
    {
        public int DeptNo { get; set; }
        public string DeptName { get; set; }=string.Empty;
        public string Location { get; set; } = string.Empty;
        public int Capacity { get; set; }
    }
}
