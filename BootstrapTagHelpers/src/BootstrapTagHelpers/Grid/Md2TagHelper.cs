namespace BootstrapTagHelpers.Grid {
    using Microsoft.AspNetCore.Razor.TagHelpers;

    [OutputElementHint("div")]
    public class Md2TagHelper : SizedColTagHelper {
        protected override int Size => 2;
        protected override string Type => "md";
    }
}