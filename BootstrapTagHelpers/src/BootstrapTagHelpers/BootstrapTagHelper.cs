namespace BootstrapTagHelpers
{
    using System.Linq;

    using Microsoft.AspNet.Razor.Runtime.TagHelpers;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    public abstract class BootstrapTagHelper : TagHelper { 

        public const string AttributePrefix="b-";
        public const string DisableBootstrapAttributeName = AttributePrefix + "disable-bootstrap";

        /// <summary>
        /// If set, bootstrap tag helpers will not be applied
        /// </summary>
        [HtmlAttributeName(DisableBootstrapAttributeName)]
        public bool DisableBootstrap { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output) {
            if (!context.IsSet(() => DisableBootstrap))
                BootstrapProcess(context, output);
        }

        protected abstract void BootstrapProcess(TagHelperContext context, TagHelperOutput output);

    }

}