namespace HTTP
{
    internal class HttpClient
    {
        private static readonly System.Net.Http.HttpClient client = new()
        {
            BaseAddress = new Uri("https://jsonplaceholder.typicode.com/")
        };

        public static async Task<string> Get(string path)
        {
            return await client.GetStringAsync(path);
        }

        public static async Task<HttpResponseMessage> GetResponse(string path)
        {
            return await client.GetAsync(path);
        }
    }
}
