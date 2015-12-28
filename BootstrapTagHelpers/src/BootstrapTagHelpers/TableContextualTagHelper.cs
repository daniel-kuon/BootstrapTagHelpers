using Microsoft.AspNet.Razor.TagHelpers;

namespace BootstrapTagHelpers {
    [HtmlTargetElement("tr", Attributes =ContextualStateAttributeName )]
    [HtmlTargetElement("td", Attributes =ContextualStateAttributeName )]
    [HtmlTargetElement("th", Attributes =ContextualStateAttributeName )]
    public class TableContextualTagHelper:BootstrapTagHelper{
        public const string ContextualStateAttributeName = AttributePrefix + "contextual-state";

        [HtmlAttributeName(ContextualStateAttributeName)]
        public BootstrapTableContextualState? ContextualState { get; set; }

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            if (ContextualState.HasValue)
                output.AddCssClass(ContextualState.Value.ToString().ToLower());
        }
    }

}