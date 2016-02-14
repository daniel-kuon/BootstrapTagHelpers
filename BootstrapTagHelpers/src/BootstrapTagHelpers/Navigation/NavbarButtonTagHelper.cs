namespace BootstrapTagHelpers.Navigation {
    using System;

    using BootstrapTagHelpers.Extensions;

    using Microsoft.AspNet.Razor.TagHelpers;

    [HtmlTargetElement("button", ParentTag = "navbar")]
    [HtmlTargetElement("input", ParentTag = "navbar")]
    public class NavbarButtonTagHelper : BootstrapTagHelper {

        [CopyToOutput]
        public string Type { get; set; }

        protected override bool CopyAttributesIfBootstrapIsDisabled => true;

        /// <summary>
        ///     Synchronously executes the <see cref="T:Microsoft.AspNet.Razor.TagHelpers.TagHelper" /> with the given
        ///     <paramref name="context" /> and
        ///     <paramref name="output" />.
        /// </summary>
        /// <param name="context">Contains information associated with the current HTML tag.</param>
        /// <param name="output">A stateful HTML element used to generate an HTML tag.</param>
        public override void Process(TagHelperContext context, TagHelperOutput output) {
            if (output.TagName.Equals("button", StringComparison.CurrentCultureIgnoreCase)
                || this.Type != null && (this.Type.Equals("button", StringComparison.CurrentCultureIgnoreCase) || this.Type.Equals("submit", StringComparison.CurrentCultureIgnoreCase)
                                    || this.Type.Equals("reset", StringComparison.CurrentCultureIgnoreCase)))
                base.Process(context, output);
        }

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.AddCssClass("navbar-btn");
        }
    }

}