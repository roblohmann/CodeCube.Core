using System;
using System.ComponentModel.DataAnnotations;

namespace CodeCube.Core.Attributes.Validation
{
    /// <summary>
    /// Attribute to validate if the value provided is an integer.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class IntegerValidationAttribute : RegularExpressionAttribute
    {
        public IntegerValidationAttribute() : base(@"^\d+$")
        {
        }
    }
}
