using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_Operations_Without_Core.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int StudentAge { get; set; }
        public DateTime StudentBirthDate { get; set; }
    }
}