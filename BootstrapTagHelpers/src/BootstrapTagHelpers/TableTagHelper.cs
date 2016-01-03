using BootstrapTagHelpers.Extensions;

namespace BootstrapTagHelpers {
    using System.Collections.Generic;
    using Microsoft.AspNet.Razor.TagHelpers;

    public class TableTagHelper : BootstrapTagHelper {
        public const string StripedAttributeName = AttributePrefix + "striped";
        public const string CondensedAttributeName = AttributePrefix + "condensed";
        public const string BorderedAttributeName = AttributePrefix + "bordered";
        public const string ResponsiveAttributeName = AttributePrefix + "responsive";
        public const string HoverAttributeName = AttributePrefix + "hover";

        [HtmlAttributeName(StripedAttributeName)]
        [HtmlAttributeNotBound]
        [HtmlAttributeMinimizable]
        public bool Striped { get; set; }

        [HtmlAttributeName(CondensedAttributeName)]
        [HtmlAttributeNotBound]
        [HtmlAttributeMinimizable]
        public bool Condensed { get; set; }

        [HtmlAttributeName(BorderedAttributeName)]
        [HtmlAttributeNotBound]
        [HtmlAttributeMinimizable]
        public bool Bordered { get; set; }

        [HtmlAttributeName(ResponsiveAttributeName)]
        [HtmlAttributeNotBound]
        [HtmlAttributeMinimizable]
        public bool Responsive { get; set; }

        [HtmlAttributeName(HoverAttributeName)]
        [HtmlAttributeNotBound]
        [HtmlAttributeMinimizable]
        public bool Hover { get; set; }

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            var classes = new List<string> {"table"};
            if (Striped)
                classes.Add("table-striped");
            if (Condensed)
                classes.Add("table-condensed");
            if (Bordered)
                classes.Add("table-bordered");
            if (Hover)
                classes.Add("table-hover");
            if (Responsive) {
                output.PreElement.AppendHtml("<div class=\"table-responsive\">");
                output.PostElement.PrependHtml("</div>");
            }
            output.AddCssClass(classes);
        }
    }
}