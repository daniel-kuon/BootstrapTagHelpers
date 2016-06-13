using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace BootstrapTagHelpers.Extensions {
    using System;
    using System.Collections.Generic;

    public static class TagHelperContentExtensions {

        /// <summary>
        /// Prepends <see cref="value"/> to the current contens of <see cref="content"/>
        /// </summary>
        public static void Prepend(this TagHelperContent content, string value) {
            if (content.IsEmptyOrWhiteSpace)
                content.SetContent(value);
            else
                content.SetContent(value + content.GetContent());
        }

        /// <summary>
        /// Prepends <see cref="value"/> to the current contens of <see cref="content"/> without encoding it
        /// </summary>
        public static void PrependHtml(this TagHelperContent content, string value) {
            if (content.IsEmptyOrWhiteSpace)
                content.SetHtmlContent(value);
            else
                content.SetHtmlContent(value + content.GetContent());
        }

        /// <summary>
        /// Prepends <see cref="value"/> to the current contens of <see cref="content"/>
        /// </summary>
        public static void Prepend(this TagHelperContent content, IHtmlContent value) {
            if (content.IsEmptyOrWhiteSpace)
                content.SetHtmlContent(value);
            else {
                string currentContent = content.GetContent();
                content.SetHtmlContent(value);
                content.AppendHtml(currentContent);
            }
        }

        /// <summary>
        /// Prepends <see cref="output"/> to the current contens of <see cref="content"/>
        /// </summary>
        public static void Prepend(this TagHelperContent content, TagHelperOutput output) {
            content.Prepend(output.ToTagHelperContent());
        }


        /// <summary>
        /// Appends <see cref="output"/> to the current contens of <see cref="content"/>
        /// </summary>
        public static void Append(this TagHelperContent content, TagHelperOutput output) {
            content.AppendHtml(output.ToTagHelperContent());
        }

        /// <summary>
        /// Converts the contents of <see cref="content"/> to a <see cref="string"/> and writes it back to <see cref="content"/>
        /// </summary>
        /// <param name="content"></param>
        public static void Render(this TagHelperContent content) {
            content.SetHtmlContent(content.GetContent());
        }

        /// <summary>
        /// Wraps <see cref="builder"/> around <see cref="content"/>. <see cref="TagBuilder.InnerHtml"/> will be ignored.
        /// </summary>
        public static void Wrap(this TagHelperContent content,TagBuilder builder) {
            builder.TagRenderMode=TagRenderMode.StartTag;
            Wrap(content, builder, new TagBuilder(builder.TagName) {TagRenderMode = TagRenderMode.EndTag});
        }

        /// <summary>
        /// Wraps <see cref="contentStart"/> and <see cref="contentEnd"/> around <see cref="content"/>
        /// </summary>
        public static void Wrap(TagHelperContent content, IHtmlContent contentStart, IHtmlContent contentEnd) {
            content.Prepend(contentStart);
            content.AppendHtml(contentEnd);
        }

        /// <summary>
        /// Wraps <see cref="contentStart"/> and <see cref="contentEnd"/> around <see cref="content"/>
        /// </summary>
        public static void Wrap(TagHelperContent content, string contentStart, string contentEnd) {
            content.Prepend(contentStart);
            content.Append(contentEnd);
        }

        /// <summary>
        /// Wraps <see cref="contentStart"/> and <see cref="contentEnd"/> around <see cref="content"/> without encoding it
        /// </summary>
        public static void WrapHtml(TagHelperContent content, string contentStart, string contentEnd) {
            content.PrependHtml(contentStart);
            content.AppendHtml(contentEnd);
        }

        /// <summary>
        /// Merges multiple TagHelperContents into a single one
        /// </summary>
        public static TagHelperContent ToSingleTagHelperContent(this IEnumerable<TagHelperContent> contents) {
            if (contents == null)
                throw new ArgumentNullException(nameof(contents));
            var content=new DefaultTagHelperContent();
            foreach (var tagHelperContent in contents) {
                content.AppendHtml(tagHelperContent);
            }
            return content;
        }
    }
}