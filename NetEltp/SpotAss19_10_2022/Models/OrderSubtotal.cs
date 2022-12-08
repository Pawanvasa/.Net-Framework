using System;
using System.Collections.Generic;

namespace SpotAss19_10_2022_DBFirstApproch.Models
{
    public partial class OrderSubtotal
    {
        public int OrderId { get; set; }
        public decimal? Subtotal { get; set; }
    }
}
