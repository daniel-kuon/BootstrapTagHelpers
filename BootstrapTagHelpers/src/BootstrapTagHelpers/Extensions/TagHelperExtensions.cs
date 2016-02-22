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

        public static async Task<TagHelperContent> ToTagHelperContentAsync(this ITagHelper tagHelper, Options options) {
            return await ToTagHelperContentAsync(
                                                 tagHelper,
                                                 options.TagName ?? tagHelper.GetTagName(),
                                                 options.Content,
                                                 options.Context ?? new TagHelperContext(new List<IReadOnlyTagHelperAttribute>(), new Dictionary<object, object>(), Guid.NewGuid().ToString("N")),
                                                 options.Attributes ?? new List<TagHelperAttribute>(),
                                                 options.TagMode);
        }

        public static async Task<TagHelperContent> ToTagHelperContentAsync(this ITagHelper tagHelper, TagHelperContent content) {
            return await ToTagHelperContentAsync(tagHelper, new Options {Content = content});
        }

        public static async Task<TagHelperContent> ToTagHelperContentAsync(this ITagHelper tagHelper, string tagName) {
            return await ToTagHelperContentAsync(tagHelper, new Options {TagName = tagName});
        }

        public static async Task<TagHelperContent> ToTagHelperContentAsync(this ITagHelper tagHelper, TagHelperContext context) {
            return await ToTagHelperContentAsync(tagHelper, new Options {Context = context});
        }

        public static async Task<TagHelperContent> ToTagHelperContentAsync(this ITagHelper tagHelper, IEnumerable<TagHelperAttribute> attributes) {
            return await ToTagHelperContentAsync(tagHelper, new Options {Attributes = attributes});
        }

        public static async Task<TagHelperContent> ToTagHelperContentAsync(
            this ITagHelper tagHelper, string tagName, TagHelperContent content, TagHelperContext context, IEnumerable<TagHelperAttribute> attributes, TagMode tagMode) {
            var output = new TagHelperOutput(tagName, new TagHelperAttributeList(attributes), b => new Task<TagHelperContent>(() => content)) {TagMode = tagMode};
            await tagHelper.ProcessAsync(context, output);
            if (content != null && !output.IsContentModified)
                output.Content.SetContent(content);
            return output.ToTagHelperContent();
        }

        public static string GetTagName(this ITagHelper tagHelper) {
            return tagHelper.GetType().GetCustomAttributes<HtmlTargetElementAttribute>().FirstOrDefault(a => a.Tag != "*")?.Tag
                   ?? Regex.Replace(tagHelper.GetType().Name.Replace("TagHelper", ""), "([A-Z])", "-$1").Trim('-').ToLower();
        }

        public static async Task<TagHelperContent> ToTagHelperContentAsync(this IEnumerable<ITagHelper> tagHelpers) {
            return await ToTagHelperContentAsync(tagHelpers, new Options());
        }

        public static async Task<TagHelperContent> ToTagHelperContentAsync(this IEnumerable<ITagHelper> tagHelpers, TagHelperContent content) {
            return await ToTagHelperContentAsync(tagHelpers, new Options() {Content = content});
        }

        public static async Task<TagHelperContent> ToTagHelperContentAsync(this IEnumerable<ITagHelper> tagHelpers, string tagName) {
            return await ToTagHelperContentAsync(tagHelpers, new Options() {TagName = tagName});
        }

        public static async Task<TagHelperContent> ToTagHelperContentAsync(this IEnumerable<ITagHelper> tagHelpers, TagHelperContext context) {
            return await ToTagHelperContentAsync(tagHelpers, new Options() {Context = context});
        }

        public static async Task<TagHelperContent> ToTagHelperContentAsync(this IEnumerable<ITagHelper> tagHelpers, IEnumerable<TagHelperAttribute> attributes) {
            return await ToTagHelperContentAsync(tagHelpers, new Options() {Attributes = attributes});
        }

        public static async Task<TagHelperContent> ToTagHelperContentAsync(this IEnumerable<ITagHelper> tagHelpers, Options options) {
            var output = new DefaultTagHelperContent();
            foreach (var tagHelper in tagHelpers) {
                output.Append(await tagHelper.ToTagHelperContentAsync(options));
            }
            var f = new List<TagHelper>();
            return output;
        }

        public static async Task<TagHelperContent> ToTagHelperContentAsync(
            this IEnumerable<ITagHelper> tagHelpers, string tagName, TagHelperContent content, TagHelperContext context, IEnumerable<TagHelperAttribute> attributes, TagMode tagMode) {
            return await ToTagHelperContentAsync(
                                                 tagHelpers, new Options() {
                                                                               TagMode = tagMode,
                                                                               Attributes = attributes as IList<TagHelperAttribute> ?? attributes.ToList(),
                                                                               TagName = tagName,
                                                                               Content = content,
                                                                               Context = context
                                                                           });
        }

        public class Options {
            public string TagName { get; set; }

            public TagMode TagMode { get; set; }

            public TagHelperContent Content { get; set; }

            public TagHelperContext Context { get; set; }

            public IEnumerable<TagHelperAttribute> Attributes { get; set; }
        }
    }
}