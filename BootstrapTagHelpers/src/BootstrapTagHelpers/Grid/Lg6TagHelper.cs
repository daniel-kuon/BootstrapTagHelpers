namespace BootstrapTagHelpers.Grid {
    using Microsoft.AspNet.Razor.TagHelpers;

    [OutputElementHint("div")]
    public class Lg6TagHelper : SizedColTagHelper {
        protected override int Size => 6;
        protected override string Type => "lg";
    }
}