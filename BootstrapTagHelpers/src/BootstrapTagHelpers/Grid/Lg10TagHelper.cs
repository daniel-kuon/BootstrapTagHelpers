namespace BootstrapTagHelpers.Grid {
    using Microsoft.AspNet.Razor.TagHelpers;

    [OutputElementHint("div")]
    public class Lg10TagHelper : SizedColTagHelper {
        protected override int Size => 10;
        protected override string Type => "lg";
    }
}