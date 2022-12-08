using APIAss04.Models;

namespace APIApps.Models
{
    public class ResponseObject
    {
        public List<CustomersEmployeesShipper>? Categories { get; set; }
        public CustomersEmployeesShipper? Category { get; set; }
        public int? StatusCode { get; set; }
        public string? Message { get; set; }
    }
}
