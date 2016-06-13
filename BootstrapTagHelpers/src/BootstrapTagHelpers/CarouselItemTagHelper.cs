using System.Threading.Tasks;

using BootstrapTagHelpers.Attributes;
using BootstrapTagHelpers.Extensions;

using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace BootstrapTagHelpers {

    [HtmlTargetElement("carousel-item", ParentTag = "carousel")]
    [OutputElementHint("div")]
    public class CarouselItemTagHelper : BootstrapTagHelper {

        public CarouselItemTagHelper(IActionContextAccessor actionContextAccessor) {
            ActionContextAccessor = actionContextAccessor;
        }

        [ConvertVirtualUrl]
        public string Src { get; set; }

        public string Alt { get; set; }

        [HtmlAttributeNotBound]
        [HtmlAttributeMinimizable]
        [HtmlAttributeName("active")]
        public bool IsActive { get; set; }

        [HtmlAttributeNotBound]
        [Context]
        public CarouselTagHelper CarouselContext { get; set; }

        protected override async Task BootstrapProcessAsync(TagHelperContext context, TagHelperOutput output) {
            output.TagName = "div";
            output.AddCssClass("item");
            if (IsActive)
                output.AddCssClass("active");
            output.PreContent.PrependHtml($"<img src=\"{Src}\" alt=\"{Alt}\" />");
            output.Content.SetHtmlContent(await output.GetChildContentAsync());
            if (!output.Content.IsEmptyOrWhiteSpace) {
                output.PreContent.AppendHtml("<div class=\"carousel-caption\">");
                output.PostContent.PrependHtml("</div>");
            }
        }

        public override void Init(TagHelperContext context) {
            base.Init(context);
            CarouselContext.AddItem(this);
        }
    }
}