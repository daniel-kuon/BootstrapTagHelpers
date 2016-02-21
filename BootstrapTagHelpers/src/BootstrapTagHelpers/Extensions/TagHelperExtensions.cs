namespace BootstrapTagHelpers.Extensions {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Razor.TagHelpers;

    public static class TagHelperExtensions {

        public static async Task<TagHelperContent> ToTagHelperContentAsync(this ITagHelper tagHelper) {
            return await ToTagHelperContentAsync(tagHelper, (TagHelperContent) null);
        }

        public static async Task<TagHelperContent> ToTagHelperContentAsync(this ITagHelper tagHelper, TagHelperContent content) {
            return await ToTagHelperContentAsync(tagHelper, tagHelper.GetTagName(), content);
        }

        public static async Task<TagHelperContent> ToTagHelperContentAsync(this ITagHelper tagHelper, string tagName) {
            return await ToTagHelperContentAsync(tagHelper, tagName, (TagHelperContent) null);
        }

        public static async Task<TagHelperContent> ToTagHelperContentAsync(this ITagHelper tagHelper, string tagName, TagHelperContent content) {
            var context = new TagHelperContext(new List<IReadOnlyTagHelperAttribute>(), new Dictionary<object, object>(), Guid.NewGuid().ToString("N"));
            return await ToTagHelperContentAsync(tagHelper, tagName, content, context);
        }

        public static async Task<TagHelperContent> ToTagHelperContentAsync(this ITagHelper tagHelper, TagHelperContext context) {
            return await ToTagHelperContentAsync(tagHelper, tagHelper.GetTagName(), context);
        }

        public static async Task<TagHelperContent> ToTagHelperContentAsync(this ITagHelper tagHelper, string tagName, TagHelperContext context) {
            return await ToTagHelperContentAsync(tagHelper, tagName, null, context);
        }

        public static async Task<TagHelperContent> ToTagHelperContentAsync(this ITagHelper tagHelper, TagHelperContent content, TagHelperContext context) {
            return await ToTagHelperContentAsync(tagHelper, tagHelper.GetTagName(), content, context);
        }

        public static async Task<TagHelperContent> ToTagHelperContentAsync(this ITagHelper tagHelper, string tagName, TagHelperContent content, TagHelperContext context) {
            var output = new TagHelperOutput(tagName, new TagHelperAttributeList(), b => new Task<TagHelperContent>(() => content));
            await tagHelper.ProcessAsync(context, output);
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