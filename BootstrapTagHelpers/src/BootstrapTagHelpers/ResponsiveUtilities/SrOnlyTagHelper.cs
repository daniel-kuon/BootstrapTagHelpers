﻿using Microsoft.AspNet.Razor.TagHelpers;

namespace BootstrapTagHelpers.ResponsiveUtilities {
    [HtmlTargetElement("SrOnly")]
public class SrOnlyTagHelper:BootstrapTagHelper {
        private const string FocusableAttributeName=AttributePrefix + "focusable";

        [HtmlAttributeName(FocusableAttributeName)]
        public bool Focusable { get; set; }

        

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.TagName = "div";
            output.AddCssClass("sr-only");
            if (context.IsSet(()=>Focusable))
                output.AddCssClass("sr-only-focusable");
        }
    }

}