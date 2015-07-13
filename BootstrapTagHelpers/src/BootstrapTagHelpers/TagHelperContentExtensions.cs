namespace BootstrapTagHelpers {
    using Microsoft.AspNet.Razor.Runtime.TagHelpers;

    public static class TagHelperContentExtensions {

        public static void Prepend(this TagHelperContent content, string value) {
            if (content.IsEmpty)
                content.SetContent(value);
            else
                content.SetContent(value + content.GetContent());
        } 
    }
}