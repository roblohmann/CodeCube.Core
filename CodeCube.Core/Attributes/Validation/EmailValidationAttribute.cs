using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace CodeCube.Core.Attributes.Validation
{
    /// <summary>
    /// Attribute to validate email address.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class EmailValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            try
            {
                var emailaddress = new MailAddress(value.ToString());

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
