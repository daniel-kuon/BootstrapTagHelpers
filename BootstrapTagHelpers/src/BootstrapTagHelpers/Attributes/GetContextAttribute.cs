namespace BootstrapTagHelpers.Attributes {
    using System;
    using System.Linq;
    using System.Reflection;

    using BootstrapTagHelpers.Extensions;

    using Microsoft.AspNetCore.Razor.TagHelpers;

    [AttributeUsage(AttributeTargets.Property)]
    public class ContextAttribute : Attribute {

        public ContextAttribute() {
        }

        public ContextAttribute(string key) {
            this.Key = key;
        }

        /// <summary>
        ///     If true, context items which type inherits from the actual property type will be used if no context item with
        ///     matching type is found
        /// </summary>
        public bool UseInherited { get; set; } = true;

        /// <summary>
        ///     If true, context item will be removed once after it is assigned to the decorated property
        /// </summary>
        public bool RemoveContext { get; set; }

        /// <summary>
        ///     Loads context using this key instead of default one
        /// </summary>
        public string Key { get; set; }

        public static void SetContexts(object target, TagHelperContext context) {
            if (target == null)
                throw new ArgumentNullException(nameof(target));
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            foreach (var propertyInfo in target.GetType().GetProperties(BindingFlags.Instance|BindingFlags.Static|BindingFlags.Public|BindingFlags.NonPublic).Where(pI => pI.HasCustomAttribute<ContextAttribute>())) {
                var attr = propertyInfo.GetCustomAttribute<ContextAttribute>();
                if (string.IsNullOrEmpty(attr.Key)) {
                    var contextItem = context.GetContextItem(propertyInfo.PropertyType, attr.UseInherited);
                    if (contextItem!=null)
                        propertyInfo.SetValue(target, contextItem);
                    if (attr.RemoveContext)
                        context.RemoveContextItem(propertyInfo.PropertyType, attr.UseInherited);
                } else {
                    propertyInfo.SetValue(target, context.GetContextItem(propertyInfo.PropertyType, attr.Key));
                    if (attr.RemoveContext)
                        context.RemoveContextItem(attr.Key);
                }
            }
        }
    }
}