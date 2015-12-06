namespace BootstrapTagHelpers.Grid {
    using Microsoft.AspNet.Razor.TagHelpers;

    [OutputElementHint("div")]
    public class Lg1TagHelper : SizedColTagHelper {
        protected override int Size => 1;
        protected override string Type => "lg";
    }
}