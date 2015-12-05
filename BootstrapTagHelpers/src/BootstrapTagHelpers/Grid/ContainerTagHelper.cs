using Microsoft.AspNet.Razor.TagHelpers;

namespace BootstrapTagHelpers.Grid {
    public class ContainerTagHelper:BootstrapTagHelper{

        public bool Fluid { get; set; }

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.TagName = "div";
            output.AddCssClass(context.IsSet(()=> Fluid) ? "container-fluid": "container");
        }
    }
}