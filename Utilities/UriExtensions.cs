namespace SpecflowGroupExcercise.Utilities
{
    public static class UriExtensions
    {
        public static Uri AddRelativePath(this Uri baseUrl, string pathToAdd)
        {
            var absoluteUrl = !baseUrl.AbsoluteUri.EndsWith("/")
            ? baseUrl.AbsoluteUri + "/"
            : baseUrl.AbsoluteUri;
            var formattedPartToAdd = pathToAdd.TrimStart('/');
            return new Uri(Path.Combine(absoluteUrl, formattedPartToAdd));
        }

        public static string AddRelativePath(this string baseUrl, string pathToAdd)
        {
            var absoluteUrl = !baseUrl.EndsWith("/")
                ? baseUrl + "/"
                : baseUrl;
            var formattedPartToAdd = pathToAdd.TrimStart('/');
            return new string(Path.Combine(absoluteUrl, formattedPartToAdd));
        }

        public static string PathToUrl(this string path)
        {
            return path.Replace("\\", "/");
        }
    }
}
