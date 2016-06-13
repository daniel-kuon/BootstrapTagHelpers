namespace BootstrapTagHelpers.Grid {
    using Microsoft.AspNetCore.Razor.TagHelpers;

    [OutputElementHint("div")]
    public class Xs4TagHelper : SizedColTagHelper {
        protected override int Size => 4;
        protected override string Type => "xs";
    }
}