using System.Threading.Tasks;

using BootstrapTagHelpers.Attributes;

using Microsoft.AspNet.Razor.TagHelpers;

namespace BootstrapTagHelpers.Tabs {

    [HtmlTargetElement("header", ParentTag = "pane")]
    [HtmlTargetElement("header", ParentTag = "pane-group")]
    public class TabsPaneHeaderTagHelper : BootstrapTagHelper {

        [HtmlAttributeNotBound]
        [Context]
        public TabsPaneTagHelper PanelContext { get; set; }

        protected override async Task BootstrapProcessAsync(TagHelperContext context, TagHelperOutput output) {
            this.PanelContext.HeaderHtml = (await output.GetChildContentAsync()).GetContent();
            output.SuppressOutput();
        }
    }
}