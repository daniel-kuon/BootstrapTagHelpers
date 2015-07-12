namespace BootstrapTagHelpers.Grid {
    using Microsoft.AspNet.Razor.Runtime.TagHelpers;

    public class ContainerTagHelper:BootstrapTagHelper{

        public bool Fluid { get; set; }

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.TagName = "div";
            output.AddCssClass(this.IsSet(()=>this.Fluid,context)? "container-fluid": "container");
        }
    }
}