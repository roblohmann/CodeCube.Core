using CodeCube.Core.Attributes.Validation;
using Xunit;

namespace CodeCube.Core.Tests
{
    public class ValidationAttributeTests
    {
        [Theory]
        [InlineData("user@example.com", true)]
        [InlineData("Rob <rob@example.com>", true)]
        [InlineData("not-an-email", false)]
        public void EmailValidation_Works(string value, bool expected)
        {
            Assert.Equal(expected, new EmailValidationAttribute().IsValid(value));
        }

        [Theory]
        [InlineData("123", true)]
        [InlineData("0", true)]
        [InlineData("12a", false)]
        [InlineData("-1", false)]
        [InlineData("1.5", false)]
        public void IntegerValidation_Works(string value, bool expected)
        {
            Assert.Equal(expected, new IntegerValidationAttribute().IsValid(value));
        }

        [Theory]
        [InlineData("http://example.com", true)]
        [InlineData("https://www.example.com/path?x=1&y=2", true)]
        [InlineData("example", false)]
        [InlineData("ftp://example.com", false)]
        public void UrlValidation_Works(string value, bool expected)
        {
            Assert.Equal(expected, new UrlValidationAttribute().IsValid(value));
        }
    }
}
