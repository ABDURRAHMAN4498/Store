namespace StoreApp.Infrastructe.Extensions
{
    public static class HttpRequestExtansion
    {
        public static string PathAndQuery(this HttpRequest request)
        {
            // gelen requstin bir querystring içeriyor mu ?
            return request.QueryString.HasValue
            //içeriyorsa endpoint ile birleştir 
            ? $"{request.Path}{request.QueryString}"
            //içermiyorsa olduğu gibi geri dönder
            :request.Path.ToString();
        }
    }
}