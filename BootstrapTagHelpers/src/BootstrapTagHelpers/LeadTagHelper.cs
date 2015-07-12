namespace BootstrapTagHelpers {
    using Microsoft.AspNet.Razor.Runtime.TagHelpers;

    [TargetElement("lead")]
    public class LeadTagHelper : BootstrapTagHelper {

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.TagName = "p";
            output.AddCssClass("lead");
        }
    }
}