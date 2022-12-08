using System;
using System.Collections.Generic;

namespace SpotAss19_10_2022_DBFirstApproch.Models
{
    public partial class SummaryOfSalesByQuarter
    {
        public DateTime? ShippedDate { get; set; }
        public int OrderId { get; set; }
        public decimal? Subtotal { get; set; }
    }
}
