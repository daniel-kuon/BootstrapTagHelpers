namespace BootstrapTagHelpers.Grid {
    using Microsoft.AspNet.Razor.TagHelpers;

    [OutputElementHint("div")]
    public class Sm1TagHelper : SizedColTagHelper {
        protected override int Size => 1;
        protected override string Type => "sm";
    }
}