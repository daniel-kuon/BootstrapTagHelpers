namespace BootstrapTagHelpers.Grid {
    using Microsoft.AspNet.Razor.TagHelpers;

    [OutputElementHint("div")]
    public class Md12TagHelper : SizedColTagHelper {
        protected override int Size => 12;
        protected override string Type => "md";
    }
}