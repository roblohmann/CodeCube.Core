using CodeCube.Core.Helpers;
using Xunit;

namespace CodeCube.Core.Tests
{
    public class RegexUtilitiesTests
    {
        [Theory]
        [InlineData("user@example.com")]
        [InlineData("first.last@example.co.uk")]
        [InlineData("user+tag@example.com")]
        [InlineData("user@bücher.example")] // IDN domain is normalized
        public void IsValidEmail_ReturnsTrue_ForValidAddresses(string email)
        {
            Assert.True(RegexUtilities.IsValidEmail(email));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("plainaddress")]
        [InlineData("@example.com")]
        [InlineData("user@")]
        [InlineData("user..name@example.com")]
        [InlineData("user@exam ple.com")]
        public void IsValidEmail_ReturnsFalse_ForInvalidAddresses(string? email)
        {
            Assert.False(RegexUtilities.IsValidEmail(email!));
        }

        [Fact]
        public void IsValidEmail_ReturnsFalse_ForInvalidIdnDomain()
        {
            // a label longer than 63 characters is rejected by IdnMapping (ArgumentException)
            var email = "user@" + new string('a', 70) + ".com";

            Assert.False(RegexUtilities.IsValidEmail(email));
        }
    }
}
