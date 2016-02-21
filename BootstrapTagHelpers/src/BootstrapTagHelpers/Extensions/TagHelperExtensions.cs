namespace BootstrapTagHelpers.Extensions {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Razor.TagHelpers;

    public static class TagHelperExtensions {

        public static TagHelperContent ToTagHelperContent(this TagHelper tagHelper) {
            return ToTagHelperContent(tagHelper, (TagHelperContent) null);
        }

        public static TagHelperContent ToTagHelperContent(this TagHelper tagHelper, TagHelperContent content) {
            return ToTagHelperContent(tagHelper, tagHelper.GetTagName(), content);
        }

        public static TagHelperContent ToTagHelperContent(this TagHelper tagHelper, string tagName) {
            return ToTagHelperContent(tagHelper, tagName, (TagHelperContent) null);
        }

        public static TagHelperContent ToTagHelperContent(this TagHelper tagHelper, string tagName, TagHelperContent content) {
            var context = new TagHelperContext(new List<IReadOnlyTagHelperAttribute>(), new Dictionary<object, object>(), Guid.NewGuid().ToString("N"));
            return ToTagHelperContent(tagHelper, tagName, content, context);
        }

        public static TagHelperContent ToTagHelperContent(TagHelper tagHelper, TagHelperContext context) {
            return ToTagHelperContent(tagHelper, tagHelper.GetTagName(), context);
        }

        public static TagHelperContent ToTagHelperContent(TagHelper tagHelper, string tagName, TagHelperContext context) {
            return ToTagHelperContent(tagHelper, tagName, null, context);
        }

        public static TagHelperContent ToTagHelperContent(TagHelper tagHelper, TagHelperContent content, TagHelperContext context) {
            return ToTagHelperContent(tagHelper, tagHelper.GetTagName(), content, context);
        }

        public static TagHelperContent ToTagHelperContent(TagHelper tagHelper, string tagName, TagHelperContent content, TagHelperContext context) {
            var output = new TagHelperOutput(tagName, new TagHelperAttributeList(), b => new Task<TagHelperContent>(() => content));
            tagHelper.Process(context, output);
            if (content != null && !output.IsContentModified)
                output.Content.SetContent(content);
            return output.ToTagHelperContent();
        }

        public static string GetTagName(this ITagHelper tagHelper) {
            return tagHelper.GetType().GetCustomAttributes<HtmlTargetElementAttribute>().FirstOrDefault(a => a.Tag != "*")?.Tag
                   ?? Regex.Replace(tagHelper.GetType().Name.Replace("TagHelper", ""), "([A-Z])", "-$1").Trim('-').ToLower();
        }
    }
}