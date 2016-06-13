namespace BootstrapTagHelpers.Grid {
    using Microsoft.AspNetCore.Razor.TagHelpers;

    [OutputElementHint("div")]
    public class Lg8TagHelper : SizedColTagHelper {
        protected override int Size => 8;
        protected override string Type => "lg";
    }
}