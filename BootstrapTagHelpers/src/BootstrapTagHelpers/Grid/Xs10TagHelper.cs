namespace BootstrapTagHelpers.Grid {
    using Microsoft.AspNet.Razor.TagHelpers;

    [OutputElementHint("div")]
    public class Xs10TagHelper : SizedColTagHelper {
        protected override int Size => 10;
        protected override string Type => "xs";
    }
}