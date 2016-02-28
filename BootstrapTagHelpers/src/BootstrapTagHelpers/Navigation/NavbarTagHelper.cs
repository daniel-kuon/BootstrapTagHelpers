using System.Threading.Tasks;
using BootstrapTagHelpers.Extensions;
using Microsoft.AspNet.Mvc.Infrastructure;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.AspNet.Razor.TagHelpers;

namespace BootstrapTagHelpers.Navigation {
    using BootstrapTagHelpers.Attributes;

    [OutputElementHint("nav")]
    [ContextClass]
    public class NavbarTagHelper : BootstrapTagHelper {
        public string BrandText { get; set; }
        public string BrandHref { get; set; }

        [AutoGenerateId]
        public string Id { get; set; }

        [HtmlAttributeMinimizable]
        [HtmlAttributeNotBound]
        public bool Inverted { get; set; }

        [HtmlAttributeMinimizable]
        [HtmlAttributeNotBound]
        public bool Fluid { get; set; }


        public NavbarPosition? Position { get; set; }

        [HtmlAttributeNotBound]
        public string BrandContent { get; set; }

        protected override async Task BootstrapProcessAsync(TagHelperContext context, TagHelperOutput output) {
            BrandContent = $"<a class=\"navbar-brand\" href=\"{BrandHref}\">{BrandText}</a>";
            await output.GetChildContentAsync();
            output.TagName = "nav";
            output.AddCssClass("navbar");
            output.AddCssClass(Inverted
                                   ? "navbar-inverse"
                                   : "navbar-default");
            if (Position != null)
                output.AddCssClass(Position.Value.GetDescription());
            output.WrapContentOutside(new TagBuilder("div") {
                Attributes = {{"class", Fluid ? "container-fluid" : "container"}}
            });
            output.PreContent.AppendHtml("<div class=\"navbar-header\">");
            output.PreContent.AppendHtml(
                                         $"<button type=\"button\" class=\"navbar-toggle collapsed\" data-toggle=\"collapse\" data-target=\"#{Id}\" aria-expanded=\"false\">");
            output.PreContent.AppendHtml($"<span class=\"sr-only\">{Ressources.ToggleNavigation}</span>");
            output.PreContent.AppendHtml("<span class=\"icon-bar\"></span>");
            output.PreContent.AppendHtml("<span class=\"icon-bar\"></span>");
            output.PreContent.AppendHtml("<span class=\"icon-bar\"></span>");
            output.PreContent.AppendHtml("</button>");
            output.PreContent.AppendHtml(BrandContent);
            output.PreContent.AppendHtml("</div>");
            output.WrapContentInside(new TagBuilder("div") {
                Attributes = {{"class", "collapse navbar-collapse"}, {"id", Id}}
            });
        }
    }

}
 