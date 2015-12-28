using System;
using System.Linq;
using System.Reflection;

namespace BootstrapTagHelpers.Extensions {
    public static class MemberInfoExtensions {
        public static bool HasCustomAttribute<T>(this MemberInfo memberInfo) {
            return memberInfo.GetCustomAttributes(typeof (T), true).Any();
        }
        public static bool HasCustomAttribute(this MemberInfo memberInfo, Type attributeType) {
            return memberInfo.GetCustomAttributes(attributeType, true).Any();
        }
    }
}