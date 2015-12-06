namespace BootstrapTagHelpers {
    using Microsoft.AspNet.Razor.TagHelpers;

    [HtmlTargetElement("dl", Attributes = HorizonzalAttributeName)]
    public class DlTagHelper : BootstrapTagHelper {
        private const string HorizonzalAttributeName = AttributePrefix + "horizontal";

        [HtmlAttributeName(HorizonzalAttributeName)]
        [HtmlAttributeNotBound]
        [HtmlAttributeMinimizable]
        public bool Horizontal { get; set; }


        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            if (Horizontal)
                output.AddCssClass("dl-horizontal");
        }
    }
}