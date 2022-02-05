using Microsoft.AspNetCore.Http;

namespace DiplomCovid19.Helpers {

    public static class UrlExtensions {

        public static string PathAndQuery(this HttpRequest request) =>
            request.QueryString.HasValue
                ? $"{request.Path}{request.QueryString}"
                : request.Path.ToString();

        public static string ReturnUrlFromSession(this HttpContext context) {
            string url = context.Session.GetString("returnUrl");
            return url;
        }
            
    }
}
