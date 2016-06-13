namespace BootstrapTagHelpers.Grid {
    using Microsoft.AspNetCore.Razor.TagHelpers;

    [OutputElementHint("div")]
    public class Lg11TagHelper : SizedColTagHelper {
        protected override int Size => 11;
        protected override string Type => "lg";
    }
}