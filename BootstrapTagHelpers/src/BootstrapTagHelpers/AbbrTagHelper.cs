﻿namespace BootstrapTagHelpers {
    using Microsoft.AspNet.Razor.TagHelpers;

    [HtmlTargetElement("abbr", Attributes = InitialismAttributeName)]
    public class AbbrTagHelper : BootstrapTagHelper {
        public const string InitialismAttributeName = AttributePrefix + "initialism";

        [HtmlAttributeName(InitialismAttributeName)]
        [HtmlAttributeNotBound]
        [HtmlAttributeMinimizable]
        public bool Initialism { get; set; }


        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            if (Initialism)
                output.AddCssClass("initialism");
        }
    }
}