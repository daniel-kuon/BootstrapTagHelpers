namespace BootstrapTagHelpers.Tabs {
    using System.Threading.Tasks;

    using BootstrapTagHelpers.Extensions;

    using Microsoft.AspNet.Razor.TagHelpers;

    [HtmlTargetElement("header", ParentTag = "pane")]
    [HtmlTargetElement("header", ParentTag = "pane-group")]
    public class TabsPaneHeaderTagHelper : BootstrapTagHelper {

        [HtmlAttributeNotBound]
        public TabsPaneTagHelper PanelContext { get; set; }

        public override void Init(TagHelperContext context) {
            base.Init(context);
            this.PanelContext = context.GetTabsPaneContext();
        }

        protected override async Task BootstrapProcessAsync(TagHelperContext context, TagHelperOutput output) {
            this.PanelContext.HeaderHtml = (await output.GetChildContentAsync()).GetContent();
            output.SuppressOutput();
        }
    }
}