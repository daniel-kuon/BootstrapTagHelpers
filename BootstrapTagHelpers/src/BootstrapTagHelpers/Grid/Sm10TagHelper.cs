namespace BootstrapTagHelpers.Grid {
    using Microsoft.AspNetCore.Razor.TagHelpers;

    [OutputElementHint("div")]
    public class Sm10TagHelper : SizedColTagHelper {
        protected override int Size => 10;
        protected override string Type => "sm";
    }
}