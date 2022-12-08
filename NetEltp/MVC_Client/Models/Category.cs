using System;
using System.Collections.Generic;

namespace MVC_Client.Models
{
    public partial class Category
    {

        [Newtonsoft.Json.JsonProperty("CategoryId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int CategoryId { get; set; }

        [Newtonsoft.Json.JsonProperty("CategoryName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string CategoryName { get; set; }

        [Newtonsoft.Json.JsonProperty("BasePrice", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double BasePrice { get; set; }

        [Newtonsoft.Json.JsonProperty("Products", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Product> Products { get; set; }
    }
}
