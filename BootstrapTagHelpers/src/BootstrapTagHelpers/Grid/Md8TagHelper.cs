namespace BootstrapTagHelpers.Grid {
    using Microsoft.AspNetCore.Razor.TagHelpers;

    [OutputElementHint("div")]
    public class Md8TagHelper : SizedColTagHelper {
        protected override int Size => 8;
        protected override string Type => "md";
    }
}