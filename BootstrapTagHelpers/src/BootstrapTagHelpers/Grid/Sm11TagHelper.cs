namespace BootstrapTagHelpers.Grid {
    using Microsoft.AspNet.Razor.TagHelpers;

    [OutputElementHint("div")]
    public class Sm11TagHelper : SizedColTagHelper {
        protected override int Size => 11;
        protected override string Type => "sm";
    }
}