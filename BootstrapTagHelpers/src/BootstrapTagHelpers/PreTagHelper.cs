﻿namespace BootstrapTagHelpers {
    using Microsoft.AspNet.Razor.TagHelpers;

    [HtmlTargetElement("pre", Attributes = ScrollableAttributeName)]
    public class PreTagHelper : BootstrapTagHelper {
        public const string ScrollableAttributeName = AttributePrefix + "scrollable";

        [HtmlAttributeName(ScrollableAttributeName)]
        [HtmlAttributeNotBound]
        [HtmlAttributeMinimizable]
        public bool Scrollable { get; set; }


        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            if (Scrollable)
                output.AddCssClass("pre-scrollable");
        }
    }
}