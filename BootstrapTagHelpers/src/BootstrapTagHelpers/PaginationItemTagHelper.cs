using System.Threading.Tasks;
using BootstrapTagHelpers.Extensions;
using Microsoft.AspNet.Razor.TagHelpers;

namespace BootstrapTagHelpers {
    [HtmlTargetElement("item", ParentTag = "pagination")]
    [OutputElementHint("li")]
    public class PaginationItemTagHelper : BootstrapTagHelper {
        public string Href { get; set; }

        [HtmlAttributeMinimizable]
        [HtmlAttributeNotBound]
        public bool Active { get; set; }

        [HtmlAttributeMinimizable]
        [HtmlAttributeNotBound]
        public bool Disabled { get; set; }

        [HtmlAttributeNotBound]
        public bool RenderOutput { get; set; } = true;

        [HtmlAttributeNotBound]
        public string Content { get; set; }

        protected PaginationTagHelper PaginationContext { get; set; }

        public override void Init(TagHelperContext context) {
            base.Init(context);
            PaginationContext = context.GetPaginationContext();
        }

        protected override async Task BootstrapProcessAsync(TagHelperContext context, TagHelperOutput output) {
            output.SuppressOutput();
            Content = (await output.GetChildContentAsync()).GetContent();
            PaginationContext.Items.Add(this);
        }

        public static string RenderItemTag(string htmlContent, string href, bool disabled, bool active) {
            return RenderItemTag(htmlContent, href, disabled, active, null);
        }

        public static string RenderItemTag(string htmlContent, string href, bool disabled, bool active, string ariaLabel) {
            var cssClass = "";
            if (disabled)
                cssClass += "disabled";
            if (active)
                cssClass += " active";
            string ret = cssClass == "" ? "<li>" : $"<li class=\"{cssClass.Trim()}\">";
            ret += "<a ";
            if (disabled)
                ret += "data-";
            ret += $"href=\"{href}\"";
            if (!string.IsNullOrEmpty(ariaLabel))
                ret += $" aria-label=\"{ariaLabel}\"";
            ret += ">";
            ret += string.IsNullOrEmpty(ariaLabel)
                       ? htmlContent
                       : "<span aria-hidden=\"true\">" + htmlContent + "</span>";
            if (active)
                ret += "<span class=\"sr-only\"> (" + Ressources.CurrentPaginationItem + ")</span>";
            ret += "</a></li>";
            return ret;
        }

        public static string RenderItemTag(PaginationItemTagHelper item) {
            return RenderItemTag(item.Content, item.Href, item.Disabled, item.Active);
        }
    }
}