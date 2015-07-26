namespace BootstrapTagHelpers {
    using Microsoft.AspNet.Razor.Runtime.TagHelpers;

    [TargetElement("tr", Attributes =ContextualStateAttributeName )]
    [TargetElement("td", Attributes =ContextualStateAttributeName )]
    [TargetElement("th", Attributes =ContextualStateAttributeName )]
    public class TableContextualTagHelper:BootstrapTagHelper{
        public const string ContextualStateAttributeName = AttributePrefix + "contextual-state";

        [HtmlAttributeName(ContextualStateAttributeName)]
        public BootstrapTaleContextualState? ContextualState { get; set; }

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            if (ContextualState.HasValue)
                output.AddCssClass(ContextualState.Value.ToString().ToLower());
        }
    }

}