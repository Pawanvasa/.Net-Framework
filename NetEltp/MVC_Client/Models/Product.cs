using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace MVC_Client.Models
{
    public partial class Product
    {

        [Newtonsoft.Json.JsonProperty("ProductUniqueId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int ProductUniqueId { get; set; }

        [Newtonsoft.Json.JsonProperty("ProductId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ProductId { get; set; }

        [Newtonsoft.Json.JsonProperty("ProductName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ProductName { get; set; }

        [Newtonsoft.Json.JsonProperty("Description", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Description { get; set; }

        [Newtonsoft.Json.JsonProperty("Price", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double Price { get; set; }

        [Newtonsoft.Json.JsonProperty("CategoryId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int CategoryId { get; set; }

        [Newtonsoft.Json.JsonProperty("Manufacturer", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Manufacturer { get; set; }

        [Newtonsoft.Json.JsonProperty("Category", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Category> Category { get; set; }


    }
}
