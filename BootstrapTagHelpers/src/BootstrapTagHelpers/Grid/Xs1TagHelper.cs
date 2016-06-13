namespace BootstrapTagHelpers.Grid {
    using Microsoft.AspNetCore.Razor.TagHelpers;

    [OutputElementHint("div")]
    public class Xs1TagHelper : SizedColTagHelper {
        protected override int Size => 1;
        protected override string Type => "xs";
    }
}