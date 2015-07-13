namespace BootstrapTagHelpers {
    using System.Collections.Generic;

    using Microsoft.AspNet.Razor.Runtime.TagHelpers;

    [TargetElement("ul",Attributes = AttributePrefix + "unstyled")]
    [TargetElement("ul",Attributes = AttributePrefix + "inline")]
    [TargetElement("ol",Attributes = AttributePrefix + "unstyled")]
    [TargetElement("ol",Attributes = AttributePrefix + "inline")]
    public class ListTagHelper:BootstrapTagHelper {

        [HtmlAttributeName(AttributePrefix+"unstyled")]
        public bool Unstyled { get; set; }

        [HtmlAttributeName(AttributePrefix+"inline")]
        public bool Inline { get; set; }
        
        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            if (context.IsSet(()=>Unstyled))
                output.AddCssClass("list-unstyled");
            if (context.IsSet(()=>Inline))
                output.AddCssClass("list-inline");
        }
    }

    public class TableTagHelper : BootstrapTagHelper {

        [HtmlAttributeName(AttributePrefix + "stripped")]
        public bool Stripped { get; set; }

        [HtmlAttributeName(AttributePrefix + "condensed")]
        public bool Condensed { get; set; }

        [HtmlAttributeName(AttributePrefix + "bordered")]
        public bool Bordered { get; set; }

        [HtmlAttributeName(AttributePrefix + "responsive")]
        public bool Responsive { get; set; }

        [HtmlAttributeName(AttributePrefix + "hover")]
        public bool Hover { get; set; }

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            var classes = new List<string>() { "table"};
        }
    }
}