namespace BootstrapTagHelpers {
    using Microsoft.AspNet.Razor.TagHelpers;

    [HtmlTargetElement("a", ParentTag = "dropdown")]
    public class DropDownLinkTagHelper : BootstrapTagHelper {
        [HtmlAttributeMinimizable]
        [HtmlAttributeNotBound]
        public bool Disabled { get; set; }


        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            if (Disabled) {
                output.PreElement.SetHtmlContent("<li class=\"disabled\">");
                if (context.AllAttributes.ContainsName("href")) {
                    output.Attributes.Add("data-href", context.AllAttributes["href"].Value);
                    output.Attributes.RemoveAll("href");
                }
            }
            else
                output.PreElement.SetHtmlContent("<li>");
            output.PostElement.SetHtmlContent("</li>");
        }
    }
}