using System;
using System.ComponentModel;

namespace CodeCube.Core.Extensions
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Function to read the description attributes value of an Enum.
        /// If no description attribute is found, the value will be used.
        /// </summary>
        /// <param name="value">The enum value.</param>
        /// <returns>The description.</returns>
        public static string ToDescription(this Enum value)
        {
            var attributes = (DescriptionAttribute[])value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }
    }
}
