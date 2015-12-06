namespace BootstrapTagHelpers {
    using System.Collections.Generic;
    using Microsoft.AspNet.Razor.TagHelpers;

    public class TableTagHelper : BootstrapTagHelper {
        public const string StrippedAttributeName = AttributePrefix + "stripped";
        public const string CondensedAttributeName = AttributePrefix + "condensed";
        public const string BorderedAttributeName = AttributePrefix + "bordered";
        public const string ResponsiveAttributeName = AttributePrefix + "responsive";
        public const string HoverAttributeName = AttributePrefix + "hover";

        [HtmlAttributeName(StrippedAttributeName)]
        [HtmlAttributeNotBound]
        [HtmlAttributeMinimizable]
        public bool Stripped { get; set; }

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
            if (Stripped)
                classes.Add("table-stripped");
            if (Condensed)
                classes.Add("table-condensed");
            if (Bordered)
                classes.Add("table-bordered");
            if (Hover)
                classes.Add("table-hover");
            if (Responsive) {
                output.PreElement.Append("<div class=\"table-responsive\">");
                output.PostElement.Prepend("</div>");
            }
            output.AddCssClass(classes);
        }
    }
}