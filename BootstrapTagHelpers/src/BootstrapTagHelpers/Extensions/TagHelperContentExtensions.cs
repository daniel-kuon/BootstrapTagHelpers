using Microsoft.AspNet.Html.Abstractions;
using Microsoft.AspNet.Razor.TagHelpers;

namespace BootstrapTagHelpers.Extensions {
    public static class TagHelperContentExtensions {

        public static void Prepend(this TagHelperContent content, string value) {
            if (content.IsEmpty)
                content.SetContent(value);
            else
                content.SetContent(value + content.GetContent());
        }

        public static void PrependHtml(this TagHelperContent content, string value) {
            if (content.IsEmpty)
                content.SetHtmlContent(value);
            else
                content.SetHtmlContent(value + content.GetContent());
        }

        public static void Prepend(this TagHelperContent content, IHtmlContent value) {
            if (content.IsEmpty)
                content.SetContent(value);
            else {
                string currentContent = content.GetContent();
                content.SetContent(value);
                content.AppendHtml(currentContent);
            }
        }

    }
}