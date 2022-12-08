using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.Models.EntityClasses
{
    public class PaymentDetails
    {
        public int Price { get; set; }
        public int Discount { get; set; }
        public int DeliveryCharges { get; set; }
        public int SecurePackagingFee { get; set; }
        public int TotalAmount { get; set; }
    }
}