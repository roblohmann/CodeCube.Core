using Xunit;

namespace CodeCube.Core.Tests
{
    public class RegularExpressionsTests
    {
        [Fact]
        public void Html_MatchesTags()
        {
            Assert.Equal("Hello", RegularExpressions.Html.Replace("<p>Hello</p>", string.Empty));
        }

        [Theory]
        [InlineData("see http://example.com/path?x=1 now", "http://example.com/path?x=1")]
        [InlineData("http://example.org", "http://example.org")]
        public void Url_FindsUrl(string input, string expected)
        {
            Assert.Equal(expected, RegularExpressions.Url.Match(input).Value);
        }

        [Fact]
        public void TwitterUserName_FindsUserName()
        {
            Assert.Equal("@rob-l", RegularExpressions.TwitterUserName.Match("hi @rob-l!").Value);
        }

        [Fact]
        public void IdOfAnImage_ExtractsGuid()
        {
            const string html = "<img class=\"x\" id=\"d3b07384-d9a0-4c9e-a4b8-2f1e1c3a5c11\" />";

            var match = RegularExpressions.IdOfAnImage.Match(html);

            Assert.True(match.Success);
            Assert.Equal("d3b07384-d9a0-4c9e-a4b8-2f1e1c3a5c11", match.Groups[1].Value);
        }

        [Fact]
        public void StyleWidthAndHeightOfAnImage_ExtractPixels()
        {
            const string html = "<img style=\"width: 120px; height: 80px;\" />";

            Assert.Equal("120", RegularExpressions.StyleWidthOfAnImage.Match(html).Groups[1].Value);
            Assert.Equal("80", RegularExpressions.StyleHeightOfAnImage.Match(html).Groups[1].Value);
        }

        [Fact]
        public void CleanNonWordCharactersRegex_RemovesPunctuation()
        {
            Assert.Equal("Hello world", RegularExpressions.CleanNonWordCharactersRegex.Replace("Hello, world!", string.Empty));
        }

        [Theory]
        [InlineData("https://vimeo.com/123456789", "123456789")]
        [InlineData("https://vimeo.com/channels/staffpicks/videos/987654", "987654")]
        public void VimeoVideoRegex_ExtractsVideoId(string url, string expectedId)
        {
            Assert.Equal(expectedId, RegularExpressions.VimeoVideoRegex.Match(url).Groups[1].Value);
        }

        [Theory]
        [InlineData("https://www.youtube.com/watch?v=dQw4w9WgXcQ", "dQw4w9WgXcQ")]
        [InlineData("https://youtu.be/dQw4w9WgXcQ", "dQw4w9WgXcQ")]
        public void YoutubeVideoRegex_ExtractsVideoId(string url, string expectedId)
        {
            Assert.Equal(expectedId, RegularExpressions.YoutubeVideoRegex.Match(url).Groups[4].Value);
        }

        [Theory]
        [InlineData("user@example.com", true)]
        [InlineData("not an email", false)]
        public void EmailAddress_Matches(string input, bool expected)
        {
            Assert.Equal(expected, RegularExpressions.EmailAddress.IsMatch(input));
        }
    }
}
