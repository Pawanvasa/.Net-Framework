using System;
using System.Collections.Generic;

namespace SearchApp.Models
{
    public partial class Manufacturer
    {
        public string? ManufacturerId { get; set; }
        public string? ManufacturerName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
    }
}
