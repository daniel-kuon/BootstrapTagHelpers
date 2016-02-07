namespace BootstrapTagHelpers {
    using System.Threading.Tasks;

    using BootstrapTagHelpers.Extensions;

    using Microsoft.AspNet.Mvc.Infrastructure;
    using Microsoft.AspNet.Razor.TagHelpers;

    [HtmlTargetElement("carousel-item",ParentTag = "carousel")]
    [OutputElementHint("div")]
    public class CarouselItemTagHelper : BootstrapTagHelper {
        [ConvertVirtualUrl]
        public string Src { get; set; }

        public string Alt { get; set; }

        [HtmlAttributeNotBound]
        [HtmlAttributeMinimizable]
        [HtmlAttributeName("active")]
        public bool IsActive { get; set; }

        [HtmlAttributeNotBound]
        public CarouselTagHelper CarouselContext { get; set; }

        public CarouselItemTagHelper(IActionContextAccessor actionContextAccessor) {
            ActionContextAccessor = actionContextAccessor;
        }

        protected override async Task BootstrapProcessAsync(TagHelperContext context, TagHelperOutput output) {
            output.TagName = "div";
            output.AddCssClass("item");
            if (IsActive)
                output.AddCssClass("active");
            output.PreContent.PrependHtml($"<img src=\"{Src}\" alt=\"{Alt}\" />");
            output.Content.SetContent(await output.GetChildContentAsync());
            if (!output.Content.IsEmpty) {
                output.PreContent.AppendHtml("<div class=\"carousel-caption\">");
                output.PostContent.PrependHtml("</div>");
            }
        }

        public override void Init(TagHelperContext context) {
            base.Init(context);
            CarouselContext = context.GetCarouselContext();
            CarouselContext.AddItem(this);
        }
    }
}