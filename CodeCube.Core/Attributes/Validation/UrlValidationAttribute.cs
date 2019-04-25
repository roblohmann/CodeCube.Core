using System;
using System.ComponentModel.DataAnnotations;

namespace CodeCube.Core.Attributes.Validation
{
    /// <summary>
    /// Attribute to validate if the value is a valid URL.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class UrlValidationAttribute : RegularExpressionAttribute
    {
        public UrlValidationAttribute() : base(@"(http|https)://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?")
        {
        }
    }
}
