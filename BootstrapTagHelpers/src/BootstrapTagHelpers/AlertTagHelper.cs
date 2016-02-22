using BootstrapTagHelpers.Extensions;

namespace BootstrapTagHelpers {
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    using BootstrapTagHelpers.Attributes;

    using Microsoft.AspNet.Razor.TagHelpers;
    using Microsoft.CodeAnalysis.CSharp;

    [OutputElementHint("div")]
    public class AlertTagHelper : BootstrapTagHelper {
        [HtmlAttributeNotBound]
        [HtmlAttributeMinimizable]
        public bool Dismissable { get; set; }

        public AlertContext Context { get; set; }

        [HtmlAttributeNotBound]
        [HtmlAttributeMinimizable]
        public bool DisableLinkStyling { get; set; }

        protected override async Task BootstrapProcessAsync(TagHelperContext context, TagHelperOutput output) {
            output.TagName = "div";
            output.AddCssClass("alert");
            output.AddCssClass("alert-" + Context.ToString().ToLower());
            output.Attributes.Add("role", "attribute");
            if (Dismissable)
                output.PreContent.SetHtmlContent(
                                                 $"<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"{Ressources.CloseIconText}\"><span aria-hidden=\"true\">&times;</span></button>");
            if (!DisableLinkStyling) {
                var content = await output.GetChildContentAsync(true);
                output.Content.SetHtmlContent(Regex.Replace(content.GetContent(), "<a( [^>]+)?>", AddLinkStyle));
            }

        }

        private string AddLinkStyle(Match match) {
            if (match.ToString().Contains("class=\""))
                return match.ToString().Replace("class=\"", "class=\"alert-link ");
            return "<a class=\"alert-link\"" + match.ToString().Substring(2);

        }
    }

}