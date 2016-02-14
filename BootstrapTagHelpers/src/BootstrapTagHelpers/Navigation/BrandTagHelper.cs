namespace BootstrapTagHelpers.Navigation {
    using System.Threading.Tasks;

    using BootstrapTagHelpers.Extensions;

    using Microsoft.AspNet.Html.Abstractions;
    using Microsoft.AspNet.Mvc.Infrastructure;
    using Microsoft.AspNet.Razor.TagHelpers;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    [OutputElementHint("a")]
    [HtmlTargetElement("brand", ParentTag = "navbar")]
    public class BrandTagHelper : BootstrapTagHelper {

        public BrandTagHelper(IActionContextAccessor actionContextAccessor) {
            ActionContextAccessor = actionContextAccessor;
        }

        [CopyToOutput]
        [ConvertVirtualUrl]
        public string Href { get; set; }

        [HtmlAttributeNotBound]
        public NavbarTagHelper NavbarContext { get; set; }

        public override void Init(TagHelperContext context) {
            base.Init(context);
            this.NavbarContext = context.GetNavbarContext();
        }

        protected override async Task BootstrapProcessAsync(TagHelperContext context, TagHelperOutput output) {
            output.TagName = "a";
            output.AddCssClass("navbar-brand");
            IHtmlContent tagHelperContent = await output.GetChildContentAsync();
            output.Content.SetContent(tagHelperContent);
            this.NavbarContext.BrandContent = output.ToTagHelperContent().GetContent();
            output.SuppressOutput();
        }
    }
}