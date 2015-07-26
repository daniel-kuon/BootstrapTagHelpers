namespace BootstrapTagHelpers {
    using System.Collections.Generic;

    using Microsoft.AspNet.Razor.Runtime.TagHelpers;

    public class TableTagHelper : BootstrapTagHelper {
        public const string StrippedAttributeName = AttributePrefix + "stripped";
        public const string CondensedAttributeName = AttributePrefix + "condensed";
        public const string BorderedAttributeName = AttributePrefix + "bordered";
        public const string ResponsiveAttributeName = AttributePrefix + "responsive";
        public const string HoverAttributeName = AttributePrefix + "hover";

        [HtmlAttributeName(StrippedAttributeName)]
        public bool Stripped { get; set; }

        [HtmlAttributeName(CondensedAttributeName)]
        public bool Condensed { get; set; }

        [HtmlAttributeName(BorderedAttributeName)]
        public bool Bordered { get; set; }

        [HtmlAttributeName(ResponsiveAttributeName)]
        public bool Responsive { get; set; }

        [HtmlAttributeName(HoverAttributeName)]
        public bool Hover { get; set; }

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            var classes = new List<string>() { "table"};
            if (context.IsSet(()=>Stripped))
                classes.Add("table-stripped");
            if (context.IsSet(()=>Condensed))
                classes.Add("table-condensed");
            if (context.IsSet(()=>Bordered))
                classes.Add("table-bordered");
            if (context.IsSet(()=>Hover))
                classes.Add("table-hover");
            if (context.IsSet(()=>Responsive)) {
                output.PreElement.Append("<div class=\"table-responsive\">");
                output.PostElement.Prepend("</div>");
            }
            output.AddCssClass(classes);
        }
    }

}