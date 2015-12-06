namespace BootstrapTagHelpers.Grid {
    using Microsoft.AspNet.Razor.TagHelpers;

    [OutputElementHint("div")]
    public class Xs6TagHelper : SizedColTagHelper {
        protected override int Size => 6;
        protected override string Type => "xs";
    }
}