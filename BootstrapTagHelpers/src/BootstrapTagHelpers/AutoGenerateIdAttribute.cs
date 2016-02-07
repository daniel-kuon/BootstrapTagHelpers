using System;
using System.Linq;
using System.Reflection;
using BootstrapTagHelpers.Extensions;

namespace BootstrapTagHelpers {

    /// <summary>
    /// Can genreate a random Id (Random Guid) if the decoraed string property is null or empty
    /// </summary>
    [AttributeUsage(AttributeTargets.Field|AttributeTargets.Property)]
    public class AutoGenerateIdAttribute : Attribute {
        private string _id;
        public string Prefix { get; set; }

        public string Id => _id ?? (_id = Prefix + Guid.NewGuid().ToString("N"));

        public AutoGenerateIdAttribute() {
        }

        public AutoGenerateIdAttribute(string prefix) {
            Prefix = prefix;
        }

        public static void GenerateIds(object target) {
            if (target == null)
                throw new ArgumentNullException(nameof(target));
            foreach (PropertyInfo property in target.GetType().GetProperties().Where(pI=>pI.HasCustomAttribute<AutoGenerateIdAttribute>())) {
                if (property.PropertyType != typeof (string))
                    throw new Exception("Decorated property must be a string");
                if (string.IsNullOrEmpty((string)property.GetValue(target)))
                    property.SetValue(target,property.GetCustomAttribute<AutoGenerateIdAttribute>().Id);
            }
        }
    }
}