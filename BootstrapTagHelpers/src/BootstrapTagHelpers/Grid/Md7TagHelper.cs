namespace BootstrapTagHelpers.Grid {
    using Microsoft.AspNet.Razor.TagHelpers;

    [OutputElementHint("div")]
    public class Md7TagHelper : SizedColTagHelper {
        protected override int Size => 7;
        protected override string Type => "md";
    }
}