using System.Text.RegularExpressions;

namespace CodeCube.Core
{
    public sealed class RegularExpressions
    {
        /// <summary>
        /// Regular expression to replace HTML.
        /// </summary>
        public static Regex Html = new Regex("<.*?>", RegexOptions.Multiline);

        /// <summary>
        /// Regex for an url
        /// </summary>
        public static Regex Url = new Regex(@"http\://[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,4}(/\S*)?", RegexOptions.Singleline);

        /// <summary>
        /// Regex for an username in an twitter message
        /// </summary>
        public static Regex TwitterUserName = new Regex(@"@[a-zA-Z0-9\-\.]+", RegexOptions.Singleline);

        ///<summary>
        /// Regex to get the id of an image.
        ///</summary>
        public static readonly Regex IdOfAnImage = new Regex("<img .*?id=\"([a-z0-9]{8}-[a-z0-9]{4}-[a-z0-9]{4}-[a-z0-9]{4}-[a-z0-9]{12})\".*?/>", RegexOptions.IgnoreCase);

        ///<summary>
        /// Regex to get the width from the style attribute of an image.
        ///</summary>
        public static readonly Regex StyleWidthOfAnImage = new Regex("<img.*?style=.*?[ ;\"]width: ?([0-9]+)px( ! important)?;.*?\".*?/>", RegexOptions.Singleline | RegexOptions.IgnoreCase);
        ///<summary>
        /// Regex to get the height from the style attribute of an image.
        ///</summary>
        public static readonly Regex StyleHeightOfAnImage = new Regex("<img.*?style=.*?[ ;\"]height: ?([0-9]+)px( ! important)?;.*?\".*?/>", RegexOptions.Singleline | RegexOptions.IgnoreCase);

        ///<summary>
        /// Regex to filter the styleattribute.
        ///</summary>
        public static readonly Regex StyleAttribute = new Regex("style=(.+?)\"", RegexOptions.IgnoreCase);

        ///<summary>
        /// Regext to filter the sourceattribute
        ///</summary>
        public static readonly Regex SourceAttribute = new Regex("src=(.+?)\"", RegexOptions.IgnoreCase);

        ///<summary>
        /// Regex to filter the idattribute
        ///</summary>
        public static readonly Regex IdAttribute = new Regex("id=\"([a-zA-Z0-9].+?)\"", RegexOptions.IgnoreCase);

        ///<summary>
        /// Regex to clean all non word characters
        ///</summary>
        public static readonly Regex CleanNonWordCharactersRegex = new Regex(@"[^\w ]+", RegexOptions.IgnoreCase);

        ///<summary>
        /// The regex for vimeo videos.
        ///</summary>
        public static readonly Regex VimeoVideoRegex = new Regex(@"vimeo\.com/(?:.*#|.*/videos/)?([0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Multiline);

        ///<summary>
        /// The regex for youtube videos.
        ///</summary>
        public static readonly Regex YoutubeVideoRegex = new Regex(@"youtu(?:\.be|be\.com)/(?:(.*)v(/|=)|(.*/)?)([a-zA-Z0-9-_]+)", RegexOptions.IgnoreCase);

        /// <summary>
        /// The regex for an emailaddress
        /// <see cref="https://docs.microsoft.com/en-us/dotnet/standard/base-types/how-to-verify-that-strings-are-in-valid-email-format"/>
        /// </summary>
        public const string EmailAddress = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";

        ///<summary>
        /// Youtube video url.
        ///</summary>
        public const string YoutubeVideoUrl = "http://www.youtube.com/watch?v={0}";

        ///<summary>
        /// Vimeo video url.
        ///</summary>
        public const string VimeoVideoUrl = "http://www.vimeo.com/{0}";
    }
}
