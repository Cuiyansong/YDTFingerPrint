using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace YDT.WinForm.Common
{
    /// <summary>
    /// Finger Extensions
    /// </summary>
    public static class FingerExtensions
    {
        /// <summary>
        /// Gets the text.
        /// </summary>
        /// <param name="range">The range.</param>
        /// <returns></returns>
        public static string GetText(this Finger range)
        {
            return range.GetAttachedData<string>(RangeAttachData.Text);
        }
    }

    /// <summary>
    /// AttachData Extensions
    /// </summary>
    public static class AttachDataExtensions
    {
        public static object GetAttachedData(
            this ICustomAttributeProvider provider, object key)
        {
            var attributes = (FingerDescriptionAttribute[])provider.GetCustomAttributes(
                typeof(FingerDescriptionAttribute), false);
            return attributes.First(a => a.Key.Equals(key)).Value;
        }

        public static T GetAttachedData<T>(
            this ICustomAttributeProvider provider, object key)
        {
            return (T)provider.GetAttachedData(key);
        }

        public static object GetAttachedData(this Enum value, object key)
        {
            return value.GetType().GetField(value.ToString()).GetAttachedData(key);
        }

        public static T GetAttachedData<T>(this Enum value, object key)
        {
            return (T)value.GetAttachedData(key);
        }
    }
}
