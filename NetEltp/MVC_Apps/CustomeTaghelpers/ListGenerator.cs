using Microsoft.AspNetCore.Razor.TagHelpers;
using NuGet.Protocol;

namespace MVC_Apps.CustomeTaghelpers
{
    public class ListGenerator : TagHelper
    {
        /*public IEnumerable<Category>? Categories { get; set; }
        public IEnumerable<Product>? products { get; set; }*/
        public IEnumerable<Object>? objects { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // Custom Tag NAme
            output.TagName = "List";
            // Start and End Tag
            // <list-generator></list-generator>
            output.TagMode = TagMode.StartTagAndEndTag;
            // Define an HTML that will be generated
            var table = "<table class='table table-bordered table-striped table-dark'>";
            /*Categories = (IEnumerable<Category>)objects;
             foreach (var item in Categories!)
             {
                 table += $"<tr><td>{item.CategoryId}</td><td>{item.CategoryName}</td><td>{item.BasePrice}</td></tr>";
             }*/

            var type = objects!.First().GetType();
            var properties = type.GetProperties();
            foreach (var item in objects!)
            {
                table += $"<tr>";
                foreach (var prop in properties)
                {
                    var model=prop.GetValue(item);
                    if(prop.GetType() != typeof(ICollection<>))
                    {
                        table += $"<td>{prop.GetValue(item)}<td>";
                    }
                }
                table += "</tr>";
            }

            // Add the Generated HTML in the HTML Output Stream
            // so that i will be shown in Browser when the View is loaded
            output.PreContent.SetHtmlContent(table);
        }
    }
}
