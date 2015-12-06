namespace BootstrapTagHelpers {
    using Microsoft.AspNet.Razor.TagHelpers;

    [OutputElementHint("div")]
    public class JumbotronTagHelper : BootstrapTagHelper {

        [HtmlAttributeNotBound]
        [HtmlAttributeMinimizable]
        public bool FullWidth { get; set; }


        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.TagName = "div";
            output.AddCssClass("jumbotron");
            if (FullWidth) {
                output.PreContent.SetHtmlContent(@"<div class=""container"">");
                output.PostContent.SetHtmlContent(@"</div>");
            }
        }
    }
}