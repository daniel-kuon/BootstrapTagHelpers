using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using BootstrapTagHelpers.Attributes;

namespace BootstrapTagHelpers.Extensions {
    public static class EnumExtensions {
        public static string GetDescription<T>(this T enumerationValue) where T : struct {
            return
                enumerationValue.GetAttribute<DisplayValueAttribute, T>()?
                                .Name ?? enumerationValue.ToString();
        }

        public static string GetDisplayValue<T>(this T enumerationValue) where T : struct {
            return
                enumerationValue.GetAttribute<DefaultValueAttribute, T>()?
                                .Value?.ToString() ?? enumerationValue.ToString();
        }

        public static T GetAttribute<T, TS>(this TS enumerationValue) where T : Attribute where TS : struct {
            Type type = enumerationValue.GetType();
            if (!type.GetTypeInfo().IsEnum)
                throw new ArgumentException("EnumerationValue must be of Enum type", "enumerationValue");
            return
                type.GetMember(enumerationValue.ToString())
                    .FirstOrDefault()?
                    .GetCustomAttribute<T>();
        }

        public static IEnumerable<T> GetAttributes<T, TS>(this TS enumerationValue) where T : Attribute where TS : struct {
            Type type = enumerationValue.GetType();
            if (!type.GetTypeInfo().IsEnum)
                throw new ArgumentException("EnumerationValue must be of Enum type", "enumerationValue");
            return
                type.GetMember(enumerationValue.ToString())
                    .FirstOrDefault()?
                    .GetCustomAttributes<T>();
        }
    }
}