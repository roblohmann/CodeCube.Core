using Xunit;
using CodeCube.Core.Extensions;

namespace CodeCube.Core.Tests
{
    public class EnumExtensionsTests
    {
        private enum TestEnum
        {
            Red = 0,
            Blue = 1,
        }

        [Fact]
        public void ToEnumShouldParseEqualString()
        {
            const string test = "Red";
            TestEnum? result = test.TryParseEnum<TestEnum>();
            Assert.Equal(TestEnum.Red, result);
        }

        [Fact]
        public void ToEnumShouldParseWrongCaseString()
        {
            const string test = "blue";
            TestEnum? result = test.TryParseEnum<TestEnum>();
            Assert.Equal(TestEnum.Blue, result);
        }

        [Fact]
        public void ToEnumShouldBeNullForInvalidString()
        {
            const string test = "orange";
            TestEnum? result = test.TryParseEnumOptional<TestEnum>();
            Assert.False(result.HasValue);
        }
    }
}
