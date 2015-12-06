namespace BootstrapTagHelpers.Grid {
    using Microsoft.AspNet.Razor.TagHelpers;

    [OutputElementHint("div")]
    public class Xs7TagHelper : SizedColTagHelper {
        protected override int Size => 7;
        protected override string Type => "xs";
    }
}