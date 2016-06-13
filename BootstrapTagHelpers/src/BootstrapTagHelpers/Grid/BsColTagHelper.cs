using BootstrapTagHelpers.Extensions;

namespace BootstrapTagHelpers.Grid {
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Razor.TagHelpers;

    [OutputElementHint("div")]
    public class BsColTagHelper : BootstrapTagHelper {
        [HtmlAttributeName("xs-size")]
        public int XsSize { get; set; }

        [HtmlAttributeName("sm-size")]
        public int SmSize { get; set; }

        [HtmlAttributeName("md-size")]
        public int MdSize { get; set; }

        [HtmlAttributeName("lg-size")]
        public int LgSize { get; set; }

        [HtmlAttributeName("xs-push")]
        public int XsPush { get; set; }

        [HtmlAttributeName("sm-push")]
        public int SmPush { get; set; }

        [HtmlAttributeName("md-push")]
        public int MdPush { get; set; }

        [HtmlAttributeName("lg-push")]
        public int LgPush { get; set; }

        [HtmlAttributeName("xs-pull")]
        public int XsPull { get; set; }

        [HtmlAttributeName("sm-pull")]
        public int SmPull { get; set; }

        [HtmlAttributeName("md-pull")]
        public int MdPull { get; set; }

        [HtmlAttributeName("lg-pull")]
        public int LgPull { get; set; }

        [HtmlAttributeName("xs-offset")]
        public int XsOffset { get; set; }

        [HtmlAttributeName("sm-offset")]
        public int SmOffset { get; set; }

        [HtmlAttributeName("md-offset")]
        public int MdOffset { get; set; }

        [HtmlAttributeName("lg-offset")]
        public int LgOffset { get; set; }


        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.TagName = "div";
            var classes = new List<string>();
            if (XsSize > 0 && XsSize <= 12)
                classes.Add("col-xs-" + XsSize);
            if (SmSize > 0 && SmSize <= 12)
                classes.Add("col-sm-" + SmSize);
            if (MdSize > 0 && MdSize <= 12)
                classes.Add("col-md-" + MdSize);
            if (LgSize > 0 && LgSize <= 12)
                classes.Add("col-lg-" + LgSize);

            if (XsOffset > 0 && XsOffset <= 12)
                classes.Add("col-xs-offset-" + XsOffset);
            if (SmOffset > 0 && SmOffset <= 12)
                classes.Add("col-sm-offset-" + SmOffset);
            if (MdOffset > 0 && MdOffset <= 12)
                classes.Add("col-md-offset-" + MdOffset);
            if (LgOffset > 0 && LgOffset <= 12)
                classes.Add("col-lg-offset-" + LgOffset);

            if (XsPull > 0 && XsPull <= 12)
                classes.Add("col-xs-pull-" + XsPull);
            if (SmPull > 0 && SmPull <= 12)
                classes.Add("col-sm-pull-" + SmPull);
            if (MdPull > 0 && MdPull <= 12)
                classes.Add("col-md-pull-" + MdPull);
            if (LgPull > 0 && LgPull <= 12)
                classes.Add("col-lg-pull-" + LgPull);

            if (XsPush > 0 && XsPush <= 12)
                classes.Add("col-xs-push-" + XsPush);
            if (SmPush > 0 && SmPush <= 12)
                classes.Add("col-sm-push-" + SmPush);
            if (MdPush > 0 && MdPush <= 12)
                classes.Add("col-md-push-" + MdPush);
            if (LgPush > 0 && LgPush <= 12)
                classes.Add("col-lg-push-" + LgPush);

            if (classes.Any())
                output.AddCssClass(classes);
        }
    }
}