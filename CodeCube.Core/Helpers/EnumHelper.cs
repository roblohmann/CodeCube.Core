using System;

namespace CodeCube.Core.Helpers
{
    /// <summary>
    /// Helper class with enum methods.
    /// </summary>
    public static class EnumHelper
    {
        /// <summary>
        /// Try to parse a string value to the provided enum.
        /// </summary>
        /// <typeparam name="TEnum">The type of enum which the string should be parsed into.</typeparam>
        /// <param name="value">The string value to parse.</param>
        /// <param name="defaultValue">The default enum value to return if the value can't be parsed. Can be NULL</param>
        /// <returns>If parsing succeeds, then the parsed enum value will be returned. Otherwise the defaultvalue will be returned.</returns>
        public static TEnum? TryParseEnum<TEnum>(string value, TEnum? defaultValue) where TEnum : struct
        {
            if (string.IsNullOrWhiteSpace(value)) return defaultValue;

            if (Enum.TryParse(value, out TEnum result))
            {
                return result;
            }

            return defaultValue;
        }
    }
}